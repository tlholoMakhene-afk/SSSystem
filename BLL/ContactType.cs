using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class ContactType
    {
        private int typeID;
        private string type;
        private string description;

        public ContactType(int typeID, string type, string description)
        {
            TypeID = typeID;
            Type = type;
            Description = description;
        }
        public ContactType()
        {

        }

        public string Description
        {
            get { return description; }
            set { description = value == null ? string.Empty : value.Trim(); ; }
        }
        

        public string Type
        {
            get { return type; }
            set { type = value == null ? string.Empty : value.Trim(); ;  }
        }
        

        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }
        
    }
}
