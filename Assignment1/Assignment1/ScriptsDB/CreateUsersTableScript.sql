create table users(
	id int not null identity primary key,
	username varchar(100) not null,
	password varchar(100) not null
);