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
                    dataGridView1.Columns.Add("F" + (i + 1), "F" + (i + 1));
                }
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > experimentResults.Count)
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
            experiment.Results[e.ColumnIndex] = Double.Parse((string)dataGridView1[e.ColumnIndex, e.RowIndex].Value);
        }
    }
}
