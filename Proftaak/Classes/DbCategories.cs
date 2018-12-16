using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak.Classes
{
    class DbCategories
    {

        public List<Category> Categories = new List<Category>();
        public DbCategories()
        {
            DbClass db = new DbClass();
            SqlDataReader rows = db.ReadSQL("select * from dbo.Category");
            int idColumn = rows.GetOrdinal("Id");
            int characteristicColumn = rows.GetOrdinal("Characteristic");
            int imageColumn = rows.GetOrdinal("Image");
            while (rows.Read())
            {
                IDataRecord record = rows;
                Category cat = new Category(Id: (int)record[idColumn], Characteristic: (string)record[characteristicColumn], Image:(string) record[imageColumn]);
                Categories.Add(cat);
                // Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
            }
        }

       
    }
}
