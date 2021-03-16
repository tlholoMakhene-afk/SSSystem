using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class ComponentClass
    {
        private int compID;
        private string compName;
        private int quantity;
        private int typeID;
        private double compCost;
        private string serialNumber;
        private int supplierID;

        public int CompID
        {
            get { return compID; }
            set { compID = value; }
        }

        public string CompName
        {
            get { return compName; }
            set { compName = value == null ? string.Empty : value.Trim(); ; }
        }

        public double CompCost
        {
            get { return compCost; }
            set { compCost = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value == null ? string.Empty : value.Trim(); ; }
        }

        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }

        private int confID;

        public int ConfID
        {
            get { return confID; }
            set { confID = value; }
        }

        public ComponentClass()
        {

        }
        public ComponentClass(int compID, string compName, double CompCost, int quantity, int supplierID, string serialNumber, int typeID)
        {
            this.CompID = compID;
            this.CompName = compName;
            this.Quantity = quantity;
            this.TypeID = typeID;
            this.CompCost = compCost;
            this.ConfID = confID;
            this.SerialNumber = serialNumber;
            this.SupplierID = supplierID;
        }

        

        public List<ComponentClass> CompList()
        {
            dbConnection db = new dbConnection();
            List<ComponentClass> list = new List<ComponentClass>();
            string select = "Select * from tblComponent";
            foreach (DataRow item in db.Select(select).Rows)
            {
                ComponentClass comp = new ComponentClass();
                list.Add(new ComponentClass(int.Parse(item[0].ToString()),item[1].ToString(),double.Parse(item[2].ToString()),int.Parse(item[3].ToString()), int.Parse(item[4].ToString()),item[5].ToString(),int.Parse(item[6].ToString())));
            }
            return list;
        }

        public List<ComponentClass> CompOption(int option)
        {
            dbConnection db = new dbConnection();
            List<ComponentClass> list = new List<ComponentClass>();
            string select = @"Select * from tblComponent cmp inner join tblOptionComponent OC
on cmp.ComponentID=OC.ComponentID inner join tblOption OP on OC.OptionID=OP.OptionID
Where OP.OptionID='" + option + "'";
            foreach (DataRow item in db.Select(select).Rows)
            {
                ComponentClass comp = new ComponentClass();
                list.Add(new ComponentClass(int.Parse(item[0].ToString()),item[1].ToString(),double.Parse(item[2].ToString()),int.Parse(item[3].ToString()), int.Parse(item[4].ToString()),item[5].ToString(),int.Parse(item[6].ToString())));
            }
            return list;
        }
    }
}
