using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Contract : IComparable<Contract>
    {
        private int contractID;
        private string identifier;
        private DateTime signedDate;
        private double paymentMade;
        private int serviceLevelID;
        private int contactTypeID;
        private int clientID;
        private int optionID;
        private string contractStatus;
        public Contract(int contractID, string identifier, DateTime signedDatedouble, double paymentMade, int optionID, int serviceLevelID, int clientID, int contactTypeID, string status)
        {
            this.ContractID = contractID;
            this.Identifier = identifier;
            this.SignedDate = signedDate;
            this.PaymentMade = paymentMade;
            this.ServiceLevelID = serviceLevelID;
            this.ContactTypeID = contactTypeID;
            this.ClientID = clientID;
            this.OptionID = optionID;
            this.ContractStatus = status;
        }
        public Contract()
        {

        }
        public int CompareTo(Contract other)
        {
            //contractid sort if the contract status is the same

            if (this.contractStatus ==other.contractStatus)
            {
                return this.contractID.CompareTo(other.contractID);
            }
            //default to sort by contract status
            return other.contractStatus.CompareTo(this.contractStatus);
        }

        public int ContractID
        {
            get { return contractID; }
            set { contractID = value; }
        }

        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        public DateTime SignedDate
        {
            get { return signedDate; }
            set { signedDate = value; }
        }

        public double PaymentMade
        {
            get { return paymentMade; }
            set { paymentMade = value; }
        }

        public int OptionID
        {
            get { return optionID; }
            set { optionID = value; }
        }

        public int ServiceLevelID
        {
            get { return serviceLevelID; }
            set { serviceLevelID = value; }
        }

        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }
        

        public int ContactTypeID
        {
            get { return contactTypeID; }
            set { contactTypeID = value; }
        }

        public string ContractStatus
        {
            get { return contractStatus; }
            set { contractStatus = value == null ? string.Empty : value.Trim(); ; }
        }

        public static List<Contract> SearchContract(int ID)
        {
            dbConnection db = new dbConnection();
            List<Contract> list = new List<Contract>();
            string select = "Select * from tblContract where ClientID ='" + ID + "'";
            foreach (DataRow item in db.SelectContract(select).Rows)
            {
                list.Add(new Contract(int.Parse(item[0].ToString()), item[1].ToString(), DateTime.Parse(item[2].ToString()), double.Parse(item[3].ToString()), int.Parse(item["OptionID"].ToString()), int.Parse(item[5].ToString()), int.Parse(item[6].ToString()), int.Parse(item[7].ToString()), item[8].ToString()));
            }
            list.Sort();
            return list;
         
        }

        public static List<Contract> contracts()
        {
            dbConnection db = new dbConnection();
            List<Contract> list = new List<Contract>();
            string select = "Select * from tblContract";
            foreach (DataRow item in db.SelectContract(select).Rows)
            {
                Contract contr = new Contract();
                list.Add(new Contract(int.Parse(item[0].ToString()), item[1].ToString(), DateTime.Parse(item[2].ToString()), double.Parse(item[3].ToString()), int.Parse(item["OptionID"].ToString()), int.Parse(item[5].ToString()), int.Parse(item[6].ToString()), int.Parse(item[7].ToString()), item[8].ToString()));
            }
            return list;
        }

        public string Display
        {
            get { return @"Identifier :" + Identifier + "\t" + "Signed Date :" + SignedDate + "\t" + "Payement Made :" + PaymentMade; }
        }

        public override string ToString()
        {
            return Display;
        }
    }
}
