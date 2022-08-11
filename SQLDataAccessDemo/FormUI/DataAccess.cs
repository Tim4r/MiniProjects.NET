using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace FormUI
{
    public class DataAccess
    {
        public List<Person> GetPeople(string lastName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //var output = connection.Query<Person>($"select * from People where LastName = '{ lastName }'").ToList();
                var OutPut = connection.Query<Person>("dbo.Peoplex_GetByLastName @LastName", new { LastName = lastName }).ToList();
                return OutPut;
            } 
        }

        public void InsertPerson(string firstName, string lastName, string emailAdress, string phoneNumber)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                //connection.Query<Person>("dbo.Insert_Person @FirstName, @LastName, @EmailAdress, @PhoneNumber", new { FirstName = firstName, LastName = lastName, EmailAdress = emailAdress, PhoneNumber = phoneNumber }).ToList();
                List<Person> people = new List<Person>();

                people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAdress, PhoneNumber = phoneNumber });

                connection.Execute("dbo.Insert_Person @FirstName, @LastName, @EmailAddress, @PhoneNumber", people);
            }
        }
    }
}
