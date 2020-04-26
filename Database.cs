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

                logger.LogInformation("inserting sample users...");

                logger.LogInformation("inserting user 0..");

                var laura = Database.CreateUser(new User { Name = "Laura", Age = 21, Location = "Malibu", Sporty = true });
                var adele = Database.CreateUser(new User { Name = "Adele", Age = 27, Location = "San Diego", Sporty = true });
                var lucia = Database.CreateUser(new User { Name = "Lucia", Age = 16, Location = "New York", Sporty = false });

                w6.Models.Users.CurrentUserId = adele.Id;

                logger.LogInformation("inserted sample users.");

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

                var id = cnn.ExecuteScalar<int>(@"
                    insert into Users (Name, Age, Location, Sporty)
                    values (@Name, @Age, @Location, @Sporty);
                    
                    select last_insert_rowid()", user);

                return GetUser(id);
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
