using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak
{
    class ProductManager
    {
        private int 
            budget;
        private int maxcal;

   public enum Category
        {
            Vegetarian,
            Vegan,
            Lactose,
            Beef,
            Chicken,
            LactoseFree
        }

        public List<Category> Categories = new List<Category>();

        public void addCategoryType(Category aCategory)
        {
            Categories.Add(aCategory);
        }

        public void CategoryType(Category aCategory)
        {
            Categories.Remove(aCategory);
        }
    }
}
