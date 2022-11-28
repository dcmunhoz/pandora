create sequence s_fin_test;

create extension if not exists "uuid-ossp";

create table users(
	id uuid default uuid_generate_v4(),
	username varchar(16) not null,
	password  varchar(16) not null,
	email	  varchar(255) not null,
	name	  varchar(100) not null,
	last_name varchar(100) not null,
	creation_date timestamp default now()	
);

alter table users 
add constraint pk_user primary key(id);