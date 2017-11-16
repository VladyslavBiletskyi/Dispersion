using System;
using System.Windows.Forms;

namespace Dispersion.Forms
{
    public partial class SetColumnCountForm : Form
    {
        public SetColumnCountForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.ColumnCount = Convert.ToInt32(numericUpDown1.Value);
            Close();
        }
    }
}
