using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dispersion.Dto;
using Dispersion.Forms;

namespace Dispersion
{
    public partial class MainForm : Form
    {
        public static int ColumnCount = 1;
        private readonly List<Experiment> experimentResults;

        public MainForm()
        {
            InitializeComponent();
            experimentResults = new List<Experiment>();
            using (SetColumnCountForm columnCount = new SetColumnCountForm())
            {
                columnCount.ShowDialog();
                for (var i = 0; i < ColumnCount; i++)
                {
                    experimentDataGridView.Columns.Add("F" + (i + 1), "F" + (i + 1));
                    groupValuesGridView.Columns.Add("F" + (i + 1), "F" + (i + 1));
                }
                groupValuesGridView.Rows.Add();
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (experimentDataGridView.Rows.Count > experimentResults.Count)
            {
                experimentResults.Add(new Experiment
                {
                    Number = experimentResults.Count + 1,
                    Results = new double[ColumnCount].ToList()
                });
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var experiment = experimentResults[e.RowIndex];
            experiment.Results[e.ColumnIndex] = GetColumnValue(e.ColumnIndex, e.RowIndex);
            RecomputeGroup(e.ColumnIndex);
        }

        private void RecomputeGroup(int columnIndex)
        {
            double result = 0;
            for (int i = 0; i < experimentDataGridView.RowCount; i++)
            {
                result += GetColumnValue(columnIndex, i);
            }
            groupValuesGridView[columnIndex, 0].Value = result / (experimentDataGridView.RowCount - 1);
        }

        private double GetColumnValue(int columnIndex, int rowIndex)
        {
            double result = 0;
            try
            {
                result = Double.Parse((string)experimentDataGridView[columnIndex, rowIndex].Value);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (experimentDataGridView.RowCount < 2)
            {
                MessageBox.Show("Слишком мало данных!");
                return;
            }
            double averageSum = CalculateAveregeSum();
            double totalAmountOfSquaresOfDeviations =
                TotalAmountOfSquaresOfDeviations(averageSum);
            double factorSumOfTheSquaresOfGroupAverageDeviations =
                FactorSumOfTheSquaresOfGroupAverageDeviations(averageSum);

            double residualAmount = totalAmountOfSquaresOfDeviations - factorSumOfTheSquaresOfGroupAverageDeviations;


            double factorDispersion = (factorSumOfTheSquaresOfGroupAverageDeviations
                                       / (experimentDataGridView.ColumnCount - 1));

            double residualDispersion = (residualAmount
                                         / experimentDataGridView.ColumnCount * (experimentDataGridView.RowCount - 1 - 1));

            dispersionResult.Text = $"S заг = {totalAmountOfSquaresOfDeviations}," +
                                    $" S факт = {factorSumOfTheSquaresOfGroupAverageDeviations}," +
                                    $" S зал = {residualAmount}, факторная дисперсия^2 = {factorDispersion}," +
                                    $"\nостаточная дисперсия^2 = {residualDispersion}, \n";

            var fCriteria = factorDispersion < residualDispersion
                ? residualDispersion / factorDispersion
                : factorDispersion / residualDispersion;

            dispersionResult.Text += $"Fспост = {fCriteria} ";

            var tableCriteria = FisherTable.Table[experimentDataGridView.RowCount-2][experimentDataGridView.ColumnCount - 1];
            dispersionResult.Text += $"Fкр = {tableCriteria}, ";

            dispersionResult.Text += $"Влияние {(fCriteria < tableCriteria ? "не" : "")}значительное";
        }

        private double CalculateAveregeSum()
        {
            double result = 0;
            for (int i = 0; i < groupValuesGridView.ColumnCount; i++)
            {
                result += (double)groupValuesGridView[i, 0].Value;
            }
            result /= groupValuesGridView.ColumnCount;
            return result;
        }

        private double TotalAmountOfSquaresOfDeviations(double averageSum)
        {
            double result = 0;

            foreach (var experiment in experimentResults)
            {
                foreach (double res in experiment.Results)
                {
                    if (res == 0)
                    {
                        continue;
                    }
                    result += Math.Pow((res - averageSum), 2);
                }
            }

            return result;
        }

        private double FactorSumOfTheSquaresOfGroupAverageDeviations(double averageSum)
        {
            double result = 0;

            for (int i = 0; i < groupValuesGridView.ColumnCount; i++)
            {
                result += (experimentDataGridView.RowCount - 1) *
                          Math.Pow((double)groupValuesGridView[i, 0].Value - averageSum, 2);
            }
            return result;
        }
    }
}
