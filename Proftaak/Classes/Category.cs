using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak.Classes
{
    class Category
    {
        private int _id;
        private string _characteristic;
        private string _image;
        public string Characteristic { get => _characteristic; set => _characteristic = value; }
        public int Id { get => _id; set => _id = value; }
        public string Image
        {
            get => _image;
            set => _image = value;
        }

        public Category(int Id, string Characteristic, string Image)
        {
            _id = Id;
            _characteristic = Characteristic;
            _image = Image;
        }
    }
    
}
