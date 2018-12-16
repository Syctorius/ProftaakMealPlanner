using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak
{
    public partial class StartScherm : Form
    {
        public StartScherm()
        {
            InitializeComponent();
           ;
        }

        private void Startknop_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FiltersScherm Filters = new FiltersScherm();
            Filters.Show();
        }
    }
}
