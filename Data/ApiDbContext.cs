using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MVCFinAppAPI.Enums;
using MVCFinAppAPI.Models;
using MVCFinAppAPI.Utilities;

namespace MVCFinAppAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }
        //Add our first method to call a Postgres Function
        public List<HouseHold> GetAllHouseHoldData(IConfiguration configuration)
        {
            //1. I need an open connection string
            //var connString = NpgsqlConnection(configuration.GetConnectionString("DefauaultConnection"));
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            connString.Open();

            //2. I need an empty List in case there aren't any in the DB
            var allHouseholds = new List<HouseHold>();

            //3. this is where I tell npgsql what function to call
            using (var cmd = new NpgsqlCommand("getallhosueholddata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                //4. Here is where it is called and the data is stored into an NpgsqlDataReeader
                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                        allHouseholds.AddRange((List<HouseHold>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<HouseHold>)));
                    }
                }
                connString.Close();
            }
            return allHouseholds;
        }

        public List<FAUser> GetAllUsers(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<FAUser>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getalluserdata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                        var deserializedMyObjects = (List<FAUser>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<FAUser>));
                        //diff list type
                        allHouseHolds.AddRange(deserializedMyObjects);
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<BankAccount> GetAllBankAccounts(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<BankAccount>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getallbankaccountdata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<BankAccount>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<BankAccount>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<History> GetAllBankAccountHistory(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<History>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getallbankaccounthistory", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<History>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<History>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<Category> GetAllCategories(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<Category>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getallcategorydata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<Category>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Category>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<CategoryItem> GetAllCategoryItems(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<CategoryItem>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getallcategoryitemdata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<CategoryItem>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<CategoryItem>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<Invitation> GetAllInvitations(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<Invitation>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getallinvitationdata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<Invitation>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Invitation>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<Notification> GetAllNotifications(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<Notification>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getallnotificationdata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<Notification>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Notification>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }

        public List<Transaction> GetAllTransactions(IConfiguration configuration)
        {
            var connString = new NpgsqlConnection(DataHelper.GetConnectionString(configuration));
            //var connString = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
            connString.Open();

            // diff list type
            var allHouseHolds = new List<Transaction>();
            //diff function name
            using (var cmd = new NpgsqlCommand("getalltransactiondata", connString))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);

                    if (dataTable.Rows.Count > 0)
                    {
                        var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                        //diff list type
                        allHouseHolds.AddRange((List<Transaction>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<Transaction>)));
                    }
                }
                connString.Close();
            }

            return allHouseHolds;
        }
    }
}
