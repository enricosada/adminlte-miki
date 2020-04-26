using System;
using System.Linq;
using System.Data.SQLite;
using System.IO;
using Dapper;
using Microsoft.Extensions.Logging;

namespace w6.Data
{
    public static class Database
    {
        private static string DbFile
        {
            get { return Path.Combine(Environment.CurrentDirectory, "mydb.sqlite"); }
        }

        public static SQLiteConnection SimpleDbConnection()
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
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();

                logger.LogInformation("created database.");

                logger.LogInformation("creating tables...");
                cnn.Execute(
                    @"create table Users
                    (
                        Name                                varchar identity primary key not null,
                        Age                                 int not null,
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
        public bool Sporty { get; set; }
    }

    public static class Repository
    {
        public static User GetUser(string name)
        {
            using (var cnn = Database.SimpleDbConnection())
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
            using (var cnn = Database.SimpleDbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    insert into Users (Name, Age, Sporty)
                    values (@Name, @Age, @Sporty)", user);

                return GetUser(user.Name);
            }
        }

        public static User SaveUser(User user)
        {
            using (var cnn = Database.SimpleDbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    update Users
                    set Age = @Age, Sporty = @Sporty
                    where Name = @Name", user);

                return GetUser(user.Name);
            }
        }
    }
}
