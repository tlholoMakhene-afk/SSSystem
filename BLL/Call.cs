using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BLL
{
    public class Call
    {
        private string caller;
        private string description;
        private string phoneNumber;
        private DateTime callDate;
        private string duration;

        StoredProcedures SP = new StoredProcedures();
        public Call(string caller, string description, string phoneNumber, DateTime callDate, string duration)
        {
            this.Caller = caller;
            this.Descrption = description;
            this.PhoneNumber = phoneNumber;
            this.CallDate = callDate;
            this.Duration = duration;
        }

        public Call()
        {

        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }


        public DateTime CallDate
        {
            get { return callDate; }
            set { callDate = value; }
        }


        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Descrption
        {
            get { return description; }
            set { description = value; }
        }


        public string Caller
        {
            get { return caller; }
            set { caller = value; }
        }

        public DataTable CallRetrive()
        {
            return SP.RetieveCalls();
        }

    }
}
