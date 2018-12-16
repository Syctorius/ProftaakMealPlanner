using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak.Classes
{
    class DbMeal
    {
        public List<Meal> Meals = new List<Meal>();
        public DbMeal()
        {
            DbClass db = new DbClass();
            SqlDataReader rows = db.ReadSQL("select * from dbo.Meal");
            int idColumn = rows.GetOrdinal("Id");
            int nameColumn = rows.GetOrdinal("name");
            int descriptionColumn = rows.GetOrdinal("meal desc");
            int urlColumn = rows.GetOrdinal("meal image");
            while (rows.Read())
            {
                IDataRecord record = rows;
                //Meal meal = new Meal(id: (int)record[idColumn], 
                //    name: (string)record[nameColumn], 
                //    description: (string)record[descriptionColumn],
                //    url: (string)record[urlColumn]

                //    );
                Meal meal = new Meal((int)record[idColumn], (string)record[nameColumn], (string)record[descriptionColumn], (string)record[urlColumn]);
                Meals.Add(meal);
                // Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
            }
        }
        public void FilterCategories(string FilterString)
        {
            Meals.Clear();
            DbClass db = new DbClass();
            SqlDataReader rows;
            if (FilterString == "")
            {
                 rows = db.ReadSQL("select * from dbo.Meal");
            }
            else
            {

             rows = db.ReadSQL("SELECT DISTINCT M.* FROM dbo.Meal M JOIN dbo.[Meal Category] MC ON (M.Id =MC.MealId) WHERE MC.CategoryId IN ( " + FilterString + ") ");
            }
            int idColumn = rows.GetOrdinal("Id");
            int nameColumn = rows.GetOrdinal("name");
            int descriptionColumn = rows.GetOrdinal("meal desc");
            int urlColumn = rows.GetOrdinal("meal image");
            while (rows.Read())
            {
                IDataRecord record = rows;
                Meal m = new Meal((int)record[idColumn], (string)record[nameColumn], (string)record[descriptionColumn], (string)record[urlColumn]);
                Meals.Add(m);
                // Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
            }
        }
    }
}
