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
                var OutPut = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
                return OutPut;
            }
            //throw new NotImplementedException(); 
        }
    }
}
