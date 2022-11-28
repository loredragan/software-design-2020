create table clientsinfo (
	idcard int not null identity primary key,
	name varchar(100) not null,
	cnp bigint not null,
	age int not null,
	adress varchar(100) not null
);