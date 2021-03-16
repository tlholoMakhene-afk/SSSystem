using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Client : Person
    {
        private int clientID;
        private string clientIdentifier;

        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        public string ClientIdentifier
        {
            get { return clientIdentifier; }
            set { clientIdentifier = value == null ? string.Empty : value.Trim(); ;  }
        }

        public Client()
        {

        }

        public Client(int clientID, string name, string surname, string idNumber, string contactNumber, string email,string address, string surburb, string code, string clientIdentifier)
            : base(name, surname, idNumber, contactNumber, email, address, surburb, code)
        {
            this.ClientID = clientID;
            ClientIdentifier = clientIdentifier; 

        }
        

        public List<Client> ClientList()
        {
            dbConnection db = new dbConnection();
            List<Client> list = new List<Client>();
            string select = "Select * from tblCustomer";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Client(int.Parse(item[9].ToString()), item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), item[6].ToString(), item[7].ToString(), item[8].ToString()));
               
            }
            return list;
        }

        public static List<Client> SearchClient(string ID)
        {
            dbConnection db = new dbConnection();
            List<Client> list = new List<Client>();
            string select = "Select * from tblCustomer where IDNumber ='" + ID + "'";
            foreach (DataRow item in db.Select(select).Rows)
            {
                list.Add(new Client(int.Parse(item[9].ToString()), item[0].ToString(), item[1].ToString(), item[2].ToString(), item[3].ToString(), item[4].ToString(), item[5].ToString(), item[6].ToString(), item[7].ToString(), item[8].ToString()));
            }
            return list;
        }
    }
}
