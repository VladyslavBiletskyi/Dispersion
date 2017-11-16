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
    }
}
