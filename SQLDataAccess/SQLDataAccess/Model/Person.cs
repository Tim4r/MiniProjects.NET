using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess.Model
{
    public class Person
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }

        public string FullInfo
        {
            get
            {
                return $"{ First_Name } { Last_Name } ({ Email_Address })";
            }
        }

        public IEnumerable<Person> DefaultPeople { get; internal set; }
    }
}
