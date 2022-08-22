using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQLDataAccess.Model
{
    class DataAccess
    {
        public static List<Person> People = new List<Person>();
        private static readonly string search_Query = $"dbo.People_GetByLastName @{nameof(Person.Last_Name)}";
        public bool LogIn(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var StackParametrs = new DynamicParameters();
                StackParametrs.Add("Parametr_username", username);
                StackParametrs.Add("Parametr_password", password);
                StackParametrs.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                connection.Query<bool>("Authorization", StackParametrs, commandType: CommandType.StoredProcedure);

                bool newID = StackParametrs.Get<bool>("Result");
                return newID;
            }
        }
        public List<Person> DataTableView()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {    
                var People = connection.Query<Person>("SELECT ID, First_Name, Last_Name, Email_Address, Phone_Number FROM People").ToList();
                return People;
            }
        }
        public List<Person> SearchPeople(string lastName)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var SearchPerson = new Person
                {
                    Last_Name = lastName
                };
                var OutPut = connection.Query<Person>(search_Query, SearchPerson).ToList();
                return OutPut;
            }
        }
    }
}
