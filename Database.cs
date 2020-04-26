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
                        Id                                  integer primary key autoincrement,
                        Name                                varchar not null,
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
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public bool Sporty { get; set; }
    }

    public static class Database
    {
        public static User GetUser(int id)
        {
            using (var cnn = DatabaseInfo.DbConnection())
            {
                cnn.Open();

                return cnn.Query<User>(@"
                    select *
                    from Users
                    where Id = @Id", new { Id = id })
                          .FirstOrDefault();
            }
        }

        public static User CreateUser(User user)
        {
            using (var cnn = DatabaseInfo.DbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    insert into Users (Id, Name, Age, Location, Sporty)
                    values (@Id, @Name, @Age, @Location, @Sporty)", user);

                return GetUser(user.Id);
            }
        }

        public static User SaveUser(User user)
        {
            using (var cnn = DatabaseInfo.DbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    update Users
                    set Name = @Name, Age = @Age, Location = @Location, Sporty = @Sporty
                    where Id = @Id", user);

                return GetUser(user.Id);
            }
        }
    }
}
