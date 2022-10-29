create sequence s_fin_test;

create table fin_test(
	seqtest integer default nextval('s_fin_test'),
	username varchar(16) not null,
	password varchar(16) not null,
	lastupdate timestamp default now()
);


select * from fin_test a;

insert into fin_test(username, password)
values('daniel', '1234');


update fin_test 
set username = 'biririr'
where seqtest = 10;
