select *
from Users


select *
from Macchine 


select Users.*
from Users
join Macchine on (Users.Id = Macchine.UserID)
where Macchine.Name = 'BMW'


select Sum(Age)
from Users
where Age > 18


update Users
SET Id = 1
WHERE Name = 'Luca'


DELETE FROM Users
WHERE Name = 'Adele'


ALTER TABLE Users
ADD COLUMN Id INT


-- add an user
insert into Users (Name, Age, Sporty)
values ('Adele', 18, true)

insert into Users (Name, Age, Sporty)
values ('Luca', 21, true)


insert into Macchine (Name, UserId, Altro)
values ('Alfa3', 'SILVIA3', 1)



insert into Macchine (Name)
values ('BMW')

UPDATE MACCHINE
Set UserId = 'FRA'
WHERE ID = 5 OR ID = 7

WHERE Name = 'BMW' AND UserId = 'MARCO'


SELECT * FROM Macchine
LIMIT 2  OFFSET 5;


-- WHERE Name = 'BMW'
-- ORDER BY UserId ASC

DELETE FROM Macchine
WHERE Name = 'BMW' AND UserID = 'enrico'




PRAGMA table_info(Macchine)


PRAGMA foreign_keys = ON

PRAGMA foreign_keys

insert into Macchine (Name, UserId)
values ('ALFA', NULL)

SELECT * FROM Macchine

drop table Macchine

create table Macchine
(
    Id       integer PRIMARY KEY AUTOINCREMENT,
    Name     varchar not null,
    UserID   int NULL,
    FOREIGN KEY(UserID) REFERENCES Persona(Nome)
)


drop table Persona

create table Persona
(
    Nome int PRIMARY KEY
)

SELECT * FROM PERSONA

INSERT INTO Persona (Nome) VALUES (1);
INSERT INTO Persona (Nome) VALUES (5);
INSERT INTO Persona (Nome) VALUES (8);




DROP TABLE Macchine

ALTER TABLE Macchine
ADD COLUMN Altro INT UNIQUE

PRAGMA table_info(Macchine)

create table Persona
(
    Id int,
    Nome varchar,
    Cognome varchar,
    Inserimento datetime,
    Documento varchar,
    Servizi varchar,
    Tutore varchar,
    Sanitario varchar,
    Dimissione bit
)
