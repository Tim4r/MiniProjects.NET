using Dapper;
using Mushroom_picking.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Mushroom_picking.Connection
{
    internal static class DataAccess
    {
        public static List<Mushroom> Global_Mushrooms = new List<Mushroom>();
        private static readonly string search_Query = $"dbo.Mushroom_GetByName @{nameof(Mushroom.NameMushroom)}";
        //private static readonly string edit_Query = $"dbo.Edit_People @{nameof(Mushroom.DefaultPeople)}";

        public static bool LogIn(string username, string password)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
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

        public static List<Mushroom> DataTableView()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
            {
                var Mushrooms = connection.Query<Mushroom>("SELECT * FROM Mushrooms").ToList();
                Global_Mushrooms = Mushrooms.ToList();
                return Mushrooms;
            }
        }

        public static List<Mushroom> SearchMushroom(string nameofMushroom)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
            {
                var SearchMushroom = new Mushroom
                {
                    NameMushroom = nameofMushroom
                };
                var OutPut = connection.Query<Mushroom>(search_Query, SearchMushroom).ToList();
                return OutPut;
            }
        }

        public static bool DeletePeople(int selected_ID)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
            {
                var StackParametrs = new DynamicParameters();
                StackParametrs.Add("deleteID", selected_ID);
                StackParametrs.Add("resultDelete", dbType: DbType.Boolean, direction: ParameterDirection.Output);
                connection.Query<bool>("DeleteMushroom", StackParametrs, commandType: CommandType.StoredProcedure);

                bool ResultDelete = StackParametrs.Get<bool>("resultDelete");
                return ResultDelete;
            }
        }

        public static void InsertMushroom(string mushroomName, string kingdomName, string departmentName, string genusName, string typeName, string edibility, int weight, int cost)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
            {
                //connection.Query<Mushroom>("dbo.Create_Mushroom @NameMushroom, @NameKingdom, @NameDepartment, @NameGenus, @NameType, @Edibility, @Weight, @Cost", new { NameMushroom = mushroomName, NameKingdom = kingdomName, NameDepartment = departmentName, NameGenus = genusName, NameType = typeName, Edibility = edibility, Weight = weight, Cost = cost }).ToList();
                List<Mushroom> Local_Mushrooms = new List<Mushroom>();
                Local_Mushrooms.Add(new Mushroom { NameMushroom = mushroomName, NameKingdom = kingdomName, NameDepartment = departmentName, NameGenus = genusName, NameType = typeName, Edibility = edibility, Weight = weight, Cost = cost });
                connection.Execute("dbo.Create_Mushroom @NameMushroom, @NameKingdom, @NameDepartment, @NameGenus, @NameType, @Edibility, @Weight, @Cost", Local_Mushrooms);
            }
        }

        public static void DeleteDataTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
            {
                connection.Query<Mushroom>("DELETE FROM Mushrooms");
            }
        }

        public static void InsertUpdateDataTable()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("MushroomsDB")))
            {
                connection.Execute("dbo.Create_Mushroom @NameMushroom, @NameKingdom, @NameDepartment, @NameGenus, @NameType, @Edibility, @Weight, @Cost", Global_Mushrooms);
            }
        }
    }
}
