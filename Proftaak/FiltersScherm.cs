using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Proftaak.Classes;

namespace Proftaak
{
    public partial class FiltersScherm : Form
    {
        private readonly CheckBox[] _box = new CheckBox[4];
        List<string> Category = new List<string>();
        ProductManager pdmanager = new ProductManager();


        private DbCategories cat;
        public FiltersScherm()
        {
            InitializeComponent();
            listBox2.Items.Clear();
            DbMeal Meal = new DbMeal();
            foreach (Meal m in Meal.Meals)
            {
                listBox2.Items.Add(m.Name);
            }
            // Dynamically Load Categories in Panel
            cat = new DbCategories();
            int top = 0;
            //Font f = new Font();
            foreach (Category c in cat.Categories)
            {

                CheckBox chk = new CheckBox();
                PictureBox pic = new PictureBox();
                chk.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
          
                chk.Text = c.Characteristic;
                chk.Name = "chk" + c.Id;
                chk.Left = 10;
                chk.Top = top+20;
                chk.Size = new System.Drawing.Size(140, 30);
                pic.Name = "pic" + c.Id;
                chk.Tag = c.Id;
                object O = ResourceImages.ResourceManager.GetObject(c.Image.Trim()); //.Chicken;//ResourceImages.ResourceManager.GetObject(c.Image);
                pic.Image = (Image) O;
                pic.Left = 150;
                pic.Top = top;
                pic.Size = new System.Drawing.Size(50, 50);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                panel1.Controls.Add(chk);
                panel1.Controls.Add(pic);
                top = top + 50;

            }


        }

        private string ShowSelected()
        {
            string selected = "";
            foreach (Control control in panel1.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox c = (CheckBox) control;
                    if (c.Checked)
                    {
                        if (selected == "")
                        {
                            selected = (string)c.Tag.ToString();
                        }
                        else
                        {
                            selected =  selected + ","+ (string)c.Tag.ToString();
                        }
                     
                    }
                }
                 
            }

            return selected;
           
        }

        private void FiltersScherm_Load(object sender, EventArgs e)
        {
            // FilterDataGridView.DataSource = GetFilterData();



        }
    
        
        private void MakeFilterCheckbox()
        {
            
            DataTable dtFilters = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", con))
                {
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader["Characteristic"].ToString());
                    }
                   

                }
            }



        }
        private DataTable GetFilterData()
        {
            try
            {
                DataTable dtFilters = new DataTable();
                string connString = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", con))
                    {
                        con.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        

                        dtFilters.Load(reader);
                        
                    }
                }
                return dtFilters;
            }
            catch (Exception e)
            {   
                    //log exception
                return null;
            }


            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
           // this.Hide();
            //Zoekresultaten zoek= new Zoekresultaten();
           // zoek.Show();
            string sel =ShowSelected();
            DbMeal Meal = new DbMeal();
            Meal.FilterCategories(sel);
            listBox2.Items.Clear();
            foreach (Meal m in Meal.Meals)
            {
                listBox2.Items.Add(m.Name);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowSelected();
        }
        /*  public List<string> GetAllStudents(string filter)
{


string query = "SELECT S.* FROM Student S";

conn.Open();
SqlCommand cmd = new SqlCommand(query, conn);


using (SqlDataReader reader = cmd.ExecuteReader())
{
while (reader.Read())
{
Name = reader.GetString(1)
Category.Add(student);
}
}

// Sluit de verbinding en geef de lijst van studenten
// terug als resultaat van de methode.
conn.Close();
return students;
}
*/
    }
}
