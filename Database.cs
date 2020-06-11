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
                        ID                                 int not null 
                        Nome                               varchar identity primary key not null,
                        Cognome                            varchar not null,
                        Inserimento                        datetime not null, 
                        Documento                          varchar,
                        Servizi                            varchar,
                        Tutore                             varchar,
                        Tessera Sanitaria                  varchar,
                        Codice STP                         varchar, 
                        Dimissione                         bit not null
                    )");
                logger.LogInformation("created tables.");
            }
        }
    }

    public class Utente
    {
       public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime Inserimento{ get; set; }
        public string Documento{ get; set; }
        public string Servizi{ get; set; }
        public string Tutore{ get; set; }
        public string Sanitaria { get; set; }
        public string STP {get ; set; }
        public bool Dimissione{ get; set; }
    }

    public static class Repository
    {
        public static Utente GetUser(string name)
        {
            using (var cnn = Database.SimpleDbConnection())
            {
                cnn.Open();

                return cnn.Query<Utente>(@"
                    select *
                    from Users
                    where Name = @Nome", new { Nome = name })
                          .FirstOrDefault();
            }
        }

        public static Utente CreateUser(Utente user)
        {
            using (var cnn = Database.SimpleDbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    insert into Users (Id, Nome, Cognome, Inserimento, Documento, Servizi, Tutore, Sanitaria, STP, Dimissione)
                    values (@ID, @Nome, @Cognome, @Inserimento, @Documento, @Servizi, @tutore, @Sanitaria, @STP, @Dimissione)", user);

                return GetUser(user.Nome);
            }
        }

        public static Utente SaveUser(Utente user)
        {
            using (var cnn = Database.SimpleDbConnection())
            {
                cnn.Open();

                cnn.Execute(@"
                    update Users
                    set Age = @Age, Sporty = @Sporty
                    where Name = @Name", user);

                return GetUser(user.Nome);
            }
        }
    }
}
