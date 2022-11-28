create table employeelogs(
	id int not null identity primary key,
	idEmployee int not null,
	transaction_type varchar(100) not null,
	transaction_date smalldatetime not null,
	source_table varchar(100) not null
);