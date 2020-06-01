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


insert into Macchine (Name, UserId)
values ('Alfa', 1)



insert into Macchine (Name, UserId)
values ('BMW', 1)

create table Macchine
(
    Name                                varchar identity primary key not null,
    UserID                              datetime not null
)
