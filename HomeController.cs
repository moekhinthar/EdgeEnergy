using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EdgeEnergy_MVC.Models;

namespace EdgeEnergy_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CategoryList categoryList = new CategoryList();
            categoryList.ListBox1 = new List<Category>();
            categoryList.ListBox2 = new List<Category>();
            categoryList.ListBox1 = GetCatData();

            return View(categoryList);
        }

        public List<Category> GetCatData()
        {
            List<Category> categorylist = new List<Category>();

            var consumed = from nodes in System.Xml.Linq.XElement.Load(Server.MapPath(@"/Categories.xml")).Elements("List") select nodes;

            foreach (var b in consumed)
            {
                string s = b.Element("ID").Value.Trim();
                string t = b.Element("Name").Value.Trim();
                categorylist.Add(new Category { CatId = s, CatName = t });
            }

            return categorylist;
        }

        [HttpPost]
        public ActionResult Index(CategoryList categorylist)
        {
            string SelectedCategoryName = "";
            
            categorylist.ListBox1 = GetCatData().Where(m => !categorylist.SelectedCategoryName.Contains(m.CatName)).ToList();
            categorylist.ListBox2 = GetCatData().Where(m => categorylist.SelectedCategoryName.Contains(m.CatName)).ToList();
            
            foreach (string item in categorylist.SelectedCategoryName)
            {
                SelectedCategoryName = SelectedCategoryName + item + ",";
            }

            ViewBag.SelectedCategoryName = SelectedCategoryName;

            return View(categorylist);
        }
    }
}