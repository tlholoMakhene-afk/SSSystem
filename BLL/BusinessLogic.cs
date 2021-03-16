using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BLL;
using DAL;

namespace BLL
{
    public class BusinessLogic
    {
        StoredProcedures SPs = new StoredProcedures();

        public bool LogCall(Call call)
        {
            return SPs.RecordCall(call);
        }

        #region Employee Method

        //Update
        public bool EmployeeUpdate(Employee employee)
        {
            return SPs.UpdateEmployee(employee);
        }

        public bool EmployeeAdd(Employee employee)
        {
            return SPs.AddEmployee(employee);
        }

        
        #endregion 

        #region Clients

        public bool AddClient(Client client)
        {
            return SPs.AddClient(client);
        }

        public bool AddNew(Client client, Contract contract)
        {
            return SPs.AddNew(client, contract);
        }

        #endregion

        #region Maintenance

        //Update
        public bool ScheduleMaintenance(Maintenance maint)
        {
            return SPs.ScheduleMaintenance(maint);
        }

        public bool MaintUpdate(Maintenance maintenance)
        {
            return SPs.UpdateMaintenance(maintenance);
        }

        public bool AddMaintenace(Maintenance maint)
        {
            return SPs.AddMaintenance(maint);
        }

        //public bool addproduct(Product products)
        //{
        //    return SPs.Addproduct(products);

        //}

        public bool ScheduleEmployee(Employee employee, Installation instal)
        {
            return SPs.ScheduleAdd(employee, instal);
        }

        public bool ScheduleEmployeeMaint(Employee employee, Maintenance maint)
        {
            return SPs.MaintScheduleAdd(employee, maint);
        }


        #endregion

        #region Contract

        public bool AddContract(Contract contract)
        {
            return SPs.AddContract(contract);
        }

        public bool ContractUpdate(Contract contract)
        {
            return SPs.UpdateContract(contract);
        }

        #endregion

        #region Product

        public bool ProductUpdate(Product product)
        {
            return SPs.UpdateProduct(product);
        }

        #endregion

        #region Installatiobn

        public bool InstalUpdate(Installation instal)
        {
            return SPs.UpdateInstallation(instal);
        }

        #endregion

        #region
        #endregion

        #region users

        //Update
        public bool UserUpdate(Users user)
        {
            return SPs.UpdateUser(user);
        }

        public bool NewUserAdd(Users user)
        {
            return SPs.AddUser(user);
        }

        #endregion

        
        

        public bool ClientUpdate(Client client)
        {
            return SPs.UpdateClient(client);
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
