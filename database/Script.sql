create extension if not exists "uuid-ossp";

-- USERS
--
create table users(
	id uuid default uuid_generate_v4(),
	username	  varchar(16)  not null,
	password	  varchar(64)  not null,
	email		  varchar(255) not null,
	name		  varchar(100) not null,
	last_name	  varchar(100) not null,
	creation_date timestamp default now()	
);

alter table users 
add constraint pk_user primary key(id);

-- CATEGORIES
--

create table categories(
	id uuid 	default uuid_generate_v4(),
	description varchar(16) not null,
	id_parent 	uuid,
	id_user	 	uuid not null
);

alter table categories 
add constraint pk_categories primary key(id);
alter table categories 
add constraint fk_categories1 foreign key(id_parent) references categories(id);
alter table categories 
add constraint fk_categories2 foreign key(id_user) references users(id);