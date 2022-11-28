alter table clientsaccounts
	add constraint fkClientID foreign key(clientID) references clientsinfo(idcard)