using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Employee:Person
    {
        private int departmentID;
        private int employeeID;
        private int positionID;
        private double salary;

        public int PositionID
        {
            get { return positionID; }
            set { positionID = value; }
        }
        

        public Employee()
        {

        }
        public Employee(int empID, string name, string surname, string idNumber, string contactNumber, string email, double salary, int departmentID, int positionID ,string address, string surburb, string code)
            : base(name, surname, idNumber, contactNumber, email, address, surburb, code)
        {
           this.employeeID = empID;
           this.PositionID = positionID;
           this.DepartmentID = departmentID;
           this.Salary = salary;
        }

        public int DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public static List<Employee> EmpList(DateTime d1, DateTime d2)
        {
            dbConnection db = new dbConnection();
            List<Employee> list = new List<Employee>();
            string select = @"select * from tblEmployee emp inner join tblInstallationPersonnel IP
                              on emp.EmployeelID=IP.PersonnelID inner join tblContractInstallation CI on IP.InstallationID=CI.InstallationID
                              where CI.InstallationStartDate!='" + d1 + "' and CI.InstallationStartDate !='" + d2 + "' ";
            foreach (DataRow item in db.Select(select).Rows)
            {
                Employee emp = new Employee();

                list.Add(new Employee(Convert.ToInt32(item[0].ToString()), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), Convert.ToDouble(item[6].ToString()), int.Parse(item[7].ToString()), int.Parse(item[8].ToString()), item[9].ToString(), item[10].ToString(), item[11].ToString()));
            }

            return list;
        }
        public static List<Employee> EmpList()
        {
            dbConnection db = new dbConnection();
            List<Employee> list = new List<Employee>();
            string select = @"select * from tblEmployee emp inner join tblInstallationPersonnel IP
                              on emp.EmployeelID=IP.PersonnelID inner join tblContractInstallation CI on IP.InstallationID=CI.InstallationID";
            foreach (DataRow item in db.Select(select).Rows)
            {
                Employee emp = new Employee();

                list.Add(new Employee(Convert.ToInt32(item[0].ToString()), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), Convert.ToDouble(item[6].ToString()), int.Parse(item[7].ToString()), int.Parse(item[8].ToString()), item[9].ToString(), item[10].ToString(), item[11].ToString()));
            }

            return list;
        }

        public static List<Employee> FreeEmpl(DateTime d1, DateTime d2)
        {
            dbConnection db = new dbConnection();
            List<Employee> list = new List<Employee>();
            string select = @"select * from tblEmployee emp inner join tblPersonnelMaintenance IP on emp.EmployeelID=IP.PersonnelID inner join tblMaintenance CI on IP.MaintenanceID=CI.MaintenanceID
                              where CI.MaintenanceStartDate!='" + d1 + "' and CI.MaintenanceEndDate !='" + d2 + "' ";
            foreach (DataRow item in db.Select(select).Rows)
            {
                Employee emp = new Employee();

                list.Add(new Employee(Convert.ToInt32(item[0].ToString()), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), Convert.ToDouble(item[6].ToString()), int.Parse(item[7].ToString()), int.Parse(item[8].ToString()), item[9].ToString(), item[10].ToString(), item[11].ToString()));
            }

            return list;
        }

        public static List<Employee> SearchEmp(string ID)
        {
            dbConnection db = new dbConnection();
            List<Employee> list = new List<Employee>();
            string select = "Select * from tblEmployee where IDNumber ='" + ID + "' And PositionID = 2";

            foreach (DataRow item in db.Select(select).Rows)
            {
                Employee emp = new Employee();

                list.Add(new Employee(Convert.ToInt32(item[0].ToString()), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), Convert.ToDouble(item[6].ToString()), int.Parse(item[7].ToString()), int.Parse(item[8].ToString()), item[9].ToString(), item[10].ToString(), item[11].ToString()));
            }

            return list;
        }
    }
}
