using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Maintenance:MaintInstall
    {
        private int maintenaceID;
        private string description;
        public double cost;

        public int MaintenanceID
        {
            get { return maintenaceID; }
            set { maintenaceID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value == null ? string.Empty : value.Trim(); ; }
        }
        
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        
        private int contractID;

        public int ContractID
        {
            get { return contractID; }
            set { contractID = value; }
        }

        public Maintenance()
        {

        }

        public Maintenance(int maintenaceID, string description, DateTime startDate, DateTime endDate, double cost, int productID)
            :base(startDate,endDate)
        {
            this.MaintenanceID = maintenaceID;
            this.ContractID = productID;
            this.Description = description;
        }

        public List<Maintenance> SelectMaintenace(int ID)
        {
            dbConnection db = new dbConnection();
            List<Maintenance> list = new List<Maintenance>();
            string select = "Select * from tblMaintenance Where ContractID = '" + ID + "' ";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Maintenance(int.Parse(item[0].ToString()),item[1].ToString(),DateTime.Parse(item[2].ToString()),DateTime.Parse(item[3].ToString()),double.Parse(item[4].ToString()),int.Parse(item[5].ToString())));
            }
            return list;
        }

//        select emp.EmployeelID, emp.Names,emp.Surname,emp.IDNumber,emp.ContactNumber from tblEmployee emp inner join tblPersonnelMaintenance IP
//on emp.EmployeelID=IP.PersonnelID inner join tblMaintenance CI on IP.MaintenanceID=CI.MaintenanceID

        public List<Maintenance> RequiredinMaintenace(DateTime d1, DateTime d2)
        {
            dbConnection db = new dbConnection();

            List<Maintenance> list = new List<Maintenance>();
            string select = "Select * from tblMaintenance Where MaintenanceStartDate = '" + d1 + "' And MaintenanceEndDate ='" + d2 + "'";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Maintenance(int.Parse(item[0].ToString()),item[1].ToString(),DateTime.Parse(item[2].ToString()),DateTime.Parse(item[3].ToString()),double.Parse(item[4].ToString()),int.Parse(item[5].ToString())));
            }
            return list;
        }

        public override string ToString()
        {
            return string.Format("Description: {0} \t Cost :{}", description, cost);
        }

    }
}
