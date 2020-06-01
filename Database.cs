using System;
using System.Linq;
using System.Data.SQLite;
using System.IO;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using w6.Models;

namespace w6
{
    public class Database 
    {
        public static List<Persona> Persone = new List<Persona>()
                                                {
                                                        new Persona { Id = 1, Nome = "Enrico", Cognome = "Sada", Inserimento = new System.DateTime(2016,11,12), Documento = "Carta Identita AX465684",Servizi = "Comune di Ancona", Tutore = "Paolo Bori", Sanitario = "Tessera sanitaria", Dimissione = false, },
                                                        new Persona { Id = 2, Nome = "Luca", Cognome = "Rossi", Inserimento = new System.DateTime(2019,05,06), Documento = "Carta Identita AL458975",Servizi = "Comune di Falconara", Tutore = "Andrea Gissi", Sanitario = "Tessera sanitaria", Dimissione = false,},
                                                };
    }
}


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
