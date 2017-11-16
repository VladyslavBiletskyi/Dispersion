using System.Collections.Generic;
using System.Windows.Forms;
using Dispersion.Dto;
using Dispersion.Forms;

namespace Dispersion
{
    public partial class MainForm : Form
    {
        public static int ColumnCount = 1;
        private List<Experiment> experimentResults;

        public MainForm()
        {
            InitializeComponent();
            using (SetColumnCountForm columnCount = new SetColumnCountForm())
            {
                columnCount.ShowDialog();
                dataGridView1.DataSource = experimentResults;
                for (var i = 0; i < ColumnCount; i++)
                {
                    dataGridView1.Columns.Add("F" + (i + 1), "F" + (i + 1));
                }
            }
        }

        private void DataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
