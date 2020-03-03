// Copyright (c) Dominic Ritz. All Rights Reserved.
// Licensed under the GNU GPL, Version 3.0 or any later version. See LICENSE in the project root for license information.

namespace Tklib.Db.Pgsql.Tests
{
    using System.Linq;
    using System.Threading.Tasks;
    using Npgsql;
    using NUnit.Framework;
    using Tklib.Db;
    using Tklib.Db.Pgsql;

    /// <summary>
    /// Tests for Tklib.Db.Pgsql.
    /// </summary>
    public class Tests
    {
        private readonly string dbName = "tk_dev";
        private PgsqlDatabase database;

        /// <summary>
        /// Sets up the test environment by creating a datbase with the default tables n stuff.
        /// Assumes there is a local postgres server with a postgresq user with either no auth or "postgres" as password.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var connection = new NpgsqlConnection("server=localhost;userid=postgres;password=postgres;");
            connection.Open();
            var command = new NpgsqlCommand($"DROP DATABASE IF EXISTS {dbName};CREATE DATABASE {dbName} WITH OWNER tk_user ENCODING 'UTF8';", connection);
            command.ExecuteNonQuery();
            connection.ChangeDatabase(dbName);
            command = new NpgsqlCommand(Properties.Resources.createTables, connection);
            command.ExecuteNonQuery();
            connection.Dispose();

            database = new PgsqlDatabase
            {
                ConnectionSettings = new DbsConnectionSettings("PostgreSQL dev env")
                {
                    Settings =
                {
                    new SingleDatabaseSetting
                    {
                        Setting = "Host",
                        Value = "127.0.0.0",
                        DisplayToUser = true,
                    },

                    new SingleDatabaseSetting
                    {
                        Setting = "Database",
                        Value = dbName,
                        DisplayToUser = true,
                    },
                    new SingleDatabaseSetting
                    {
                        Setting = "Username",
                        Value = "tk_user",
                        DisplayToUser = true,
                    },

                    new SingleDatabaseSetting
                    {
                        Setting = "Password",
                        Value = "tk_user01",
                        DisplayToUser = true,
                    },
                },
                },
            };
        }

        /// <summary>
        /// Empty testcase because the setup needs to be run.
        /// </summary>
        [Test]
        public void Test1()
        {
            var locoList = TestData.GetLocomotives();
            InsertTestData();

            database.Locomotives.Load();

            var combinedList = locoList.Zip(database.Locomotives.Collection);
            foreach (var (first, second) in combinedList)
            {
                Assert.That(first.Equals(second));
            }
        }

        private void InsertTestData()
        {
            foreach (var loco in TestData.GetLocomotives())
            {
                database.Locomotives.Save(loco);
            }
        }
    }
}