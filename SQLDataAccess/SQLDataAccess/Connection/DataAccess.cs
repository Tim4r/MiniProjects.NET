using Dapper;
using SQLDataAccess.Views;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SQLDataAccess.Model
{
    class DataAccess
    {
        public static List<Person> People = new List<Person>();
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
    }
}
