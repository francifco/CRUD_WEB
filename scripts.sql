

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

use EvaluacionFrancis;
select * from book




