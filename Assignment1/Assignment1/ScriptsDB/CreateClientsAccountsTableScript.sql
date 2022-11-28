create table clientsaccounts(
	id int not null identity primary key,
	type varchar(100) not null,
	amount float not null,
	creation_date date not null,
	clientID int not null
);