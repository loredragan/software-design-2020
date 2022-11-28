create table clientsaccounts2(
	id int not null identity primary key,
	type varchar(100) not null,
	amount float not null,
	creation_date smalldatetime not null,
	clientID int not null
);