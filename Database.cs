using System;
using System.Linq;
using System.Data.SQLite;
using System.IO;
using Dapper;
using Microsoft.Extensions.Logging;

namespace w6.Data
{
    public static class DatabaseInfo
    {
        private static string DbFile
        {
            get { return Path.Combine(Environment.CurrentDirectory, "mydb.sqlite"); }
        }

        public static SQLiteConnection DbConnection()
        {
            return new SQLiteConnection($"Data Source={DbFile}");
        }

        public static void Create(ILogger logger)
        {
            if (File.Exists(DbFile))
            {
                logger.LogInformation($"database '{DbFile}' already exists.");
                return;
            }

            logger.LogInformation($"creating database '{DbFile}'...");
            using (var cnn = DbConnection())
            {
                cnn.Open();

                logger.LogInformation("created database.");

                logger.LogInformation("creating tables...");
                cnn.Execute(
                    @"create table Users
                    (
                        Name                                varchar identity primary key not null,
                        Age                                 int not null,
                        Location                            varchar not null,
                        Sporty                              bit not null
                    )");
                logger.LogInformation("created tables.");
            }
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public bool Sporty { get; set; }
    }

    public static class Database
    {
        public static User GetUser(string name)
        {
            using (var cnn = DatabaseInfo.DbConnection())
            {
                cnn.Open();

                return cnn.Query<User>(@"
                    select *
                    from Users
                    where Name = @Name", new { Name = name })
                          .FirstOrDefault();
            }
        }

        public static User CreateUser(User user)
        {
            using (var cnn = DatabaseInfo.DbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    insert into Users (Name, Age, Location, Sporty)
                    values (@Name, @Age, @Location, @Sporty)", user);

                return GetUser(user.Name);
            }
        }

        public static User SaveUser(User user)
        {
            using (var cnn = DatabaseInfo.DbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    update Users
                    set Age = @Age, Location = @Location, Sporty = @Sporty
                    where Name = @Name", user);

                return GetUser(user.Name);
            }
        }
    }
}
