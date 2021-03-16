using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Category
    {
        public int categoryID;
        public string name;
        public string description;

        public string Description
        {
            get { return description; }
            set { description = value == null ? string.Empty : value.Trim(); ;  }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value == null ? string.Empty : value.Trim(); ;  }
        }
        

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public Category(int categoryID, string name, string description)
        {
            Description = description;
            Name = name;
            CategoryID = categoryID;
        }

        public Category()
        {
                
        }

        public List<Category> CategoryList()
        {
            dbConnection db = new dbConnection();
            List<Category> list = new List<Category>();
            string select = "Select * from tblProductCategory";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Category(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString()));
            }
            return list;
        }

        public string CategryDisplay
        {
            get { return name; }
        }
        public override string ToString()
        {
            return CategryDisplay;
        }
    }
}
