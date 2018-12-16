using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proftaak.Classes;

namespace Proftaak.UserControls
{
    public partial class CategorySelection : UserControl
    {

        DbCategories cat = new DbCategories();
        List<int> selectedCategories = new List<int>();
        public CategorySelection()
        {
            InitializeComponent();
            int top = 0;
            foreach (Category c in cat.Categories)
            {

                CheckBox chk = new CheckBox();
                chk.Text = c.Characteristic;
                chk.Name = "chk" + c.Id;
                chk.Left = 10;
                chk.Top = top;
                // chk.Click += new EventHandler(ShowMessage);
                this.Controls.Add(chk);
                top = top + 20;
            }


        }
    }
}
