using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Installation:MaintInstall
    {
        private int installationID;
        private int contractID;

        public int ContractID
        {
            get { return contractID; }
            set { contractID = value; }
        }

        public int InstallationID
        {
            get { return installationID; }
            set { installationID = value; }
        }

        public Installation()
        {

        }

        public Installation(int installationID, DateTime startDate, DateTime endDate, int contractID)
            :base(startDate,endDate)
        {
            this.InstallationID = installationID;
            this.ContractID = contractID;
        }

        public static List<Installation> installation(int ID)
        {
            dbConnection db = new dbConnection();
            List<Installation> list = new List<Installation>();
            string select = "Select * from tblContractInstallation Where ContractID ='" + ID + "'";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Installation(int.Parse(item["InstallationID"].ToString()), DateTime.Parse(item[0].ToString()), DateTime.Parse(item[1].ToString()), int.Parse(item[2].ToString())));
            }
            return list;
        }

        public static List<Installation> Requiredinstallation(DateTime d1, DateTime d2)
        {
            dbConnection db = new dbConnection();
            
            List<Installation> list = new List<Installation>();
            string select = "Select * from tblContractInstallation Where InstallationStartDate = '" + d1 + "' And InstallationEndDate='" + d2 + "'";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Installation(Convert.ToInt32(item["InstallationID"].ToString()), Convert.ToDateTime(item[0].ToString()), Convert.ToDateTime(item[1].ToString()), Convert.ToInt32(item[2].ToString())));
            }
            return list;
        }
    }
}
