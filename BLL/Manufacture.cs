using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class Manufacture
    {
        private int manufactureID;
        private string name;

        public Manufacture(int manufactureID, string name)
        {
            ManufactureID = manufactureID;
            Name = name;
        }

        public Manufacture()
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public int ManufactureID
        {
            get { return manufactureID; }
            set { manufactureID = value; }
        }

        public override string ToString()
        {
            return string.Format("Manufacture Name: {0}", name);
        }
        
    }
}
