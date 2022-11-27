using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQLDataAccess.Model
{
    class DataAccess
    {
        public static List<Person> People = new List<Person>();
        private static readonly string search_Query = $"dbo.People_GetByLastName @{nameof(Person.Last_Name)}";
        private static readonly string edit_Query = $"dbo.Edit_People @{nameof(Person.DefaultPeople)}";
        
        public bool LogIn(string username, string password)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var StackParametrs = new DynamicParameters();
                StackParametrs.Add("Parametr_username", username);
                StackParametrs.Add("Parametr_password", password);
                StackParametrs.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                connection.Query<bool>("CheckAuthorization", StackParametrs, commandType: CommandType.StoredProcedure);

                bool newID = StackParametrs.Get<bool>("Result");
                return newID;
            }
        }
        public static List<Person> DataTableView()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {    
                var People = connection.Query<Person>("SELECT ID, First_Name, Last_Name, Email_Address, Phone_Number FROM People").ToList();
                return People;
            }
        }
        public static List<Person> SearchPeople(string lastName)
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
        public static void UpdatePeople(IEnumerable<Person> newPeople)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var EditPeople = new Person
                {
                    DefaultPeople = newPeople
                };
                connection.Query<Person>(edit_Query, EditPeople);
            }
        }
        public static bool DeletePeople(int selected_ID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                var StackParametrs = new DynamicParameters();
                StackParametrs.Add("deleteID", selected_ID);
                StackParametrs.Add("resultDelete", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                connection.Query<bool>("DeletePerson", StackParametrs, commandType: CommandType.StoredProcedure);

                bool ResultDelete = StackParametrs.Get<bool>("resultDelete");
                return ResultDelete;
            }
        }
        public static void Athorisation()
        {

        }
    }
}
