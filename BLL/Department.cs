using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Department
    {
        private int departmentID;
        private string name;

        public Department(int departmentID, string name)
        {
            DepartmentID = departmentID;
            Name = name;
        }

        public Department()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value == null ? string.Empty : value.Trim(); ;  }
        }
        

        public int DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        public static List<Department> DepartmentList()
        {
            dbConnection db = new dbConnection();
            List<Department> list = new List<Department>();
            string select = "Select TOP (4)* from tblDepartment";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Department(int.Parse(item[0].ToString()), item[1].ToString()));
            }
            return list;
        }
        
    }
}
