using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MaintInstall
    {
        public DateTime defaultdate = Convert.ToDateTime("2000-01-01");
        public DateTime startDate;
        public DateTime endDate;
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value == null ? string.Empty : value.Trim(); ;  }
        }
        
        
        public MaintInstall(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            if (StartDate == defaultdate)
            {
                this.Status = "Schedule Pending";
            }
            //if (EndDate < DateTime.Today)
            //{
            //    this.Status = "Completed";
            //}
            if (StartDate >DateTime.Today && EndDate <= DateTime.Today)
            {
                this.Status = "In progress";
            }
        }
        
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public MaintInstall()
        {

        }

        public override string ToString()
        {
            return string.Format("Start date:{0}\n New Line:{}",startDate,EndDate);
        }
    }
}
