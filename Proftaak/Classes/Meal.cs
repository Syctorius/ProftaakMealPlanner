using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak.Classes
{
    class Meal
    {
        private int _id;
        private string _name;
        private string _description;
        private string _url;
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Url { get => _url; set => _url = value; }

        public Meal(int Id, string Name)
        {
            _id = Id;
           _name = Name;
        }
        public Meal(int _id, string _name, string _description)
        {
            _id = Id;
            _name = Name;
            _description = Description;
        }
        public Meal(int _id, string _name, string _description, string _url)
        {

             Id=_id;
            Name =_name;
            Description = _description;

            Url = _url;

        }

        
    }

    
}
