

create database EvaluacionFrancis




use EvaluacionFrancis;

create table client(
id int identity(1,1) primary key not null,
clientName varchar(50),
idIdenti varchar(50)
)


create table book(
id int identity(1,1) primary key not null,
bookName varchar(50),
tittle varchar(50),
edition varchar(50),
quality int
)

/*relacion cliente - libro*/
create table bookClient(
id int identity(1,1) primary key not null,
id_user int,
id_book int,
FOREIGN KEY (id_user) REFERENCES client(id),
FOREIGN KEY (id_book) REFERENCES book(id)
)

insert into book(bookName, tittle, edition, quality)
values('nacho','nacho','2016',15),
('Antillana','Ciencias sociales','2016',20),
('Susaeta','Lengua española','2015',10),
('Baldol','Baldol','2015',10)





