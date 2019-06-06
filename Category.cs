using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeEnergy_MVC.Models
{
    public class Category
    {
        public string CatId { get; set; }
        public string CatName { get; set; }
    }
    public class CategoryList
    {
        public List<Category> ListBox1 { get; set; }
        public List<Category> ListBox2 { get; set; }
        public string[] SelectedCategoryName { get; set; }
    }
}