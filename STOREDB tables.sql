use StoreDB;

create table products
(
id_product int Identity(1,1) primary key,
name_product varchar(100) not null,
price double precision not null,
id_producer int not null,
id_cat int not null,
description_product varchar(100) not null,
ammount int not null
);

create table producer
(
id_producer int Identity(1,1) primary key ,
name_producer varchar(100) not null,
country varchar(100) not null,
city varchar(20) not null 
);

create table employee
(
id_employee int Identity(1,1) primary key ,
name_employee varchar(100) not null,
surname_employee varchar(100) not null,
post varchar(100) not null,
empl_login varchar(100) not null,
empl_passw varchar(100) not null,
salary double precision not null
);

create table sales
(
id_sales int Identity(1,1) primary key,
date_sales date not null,
id_product int not null,
ammount int not null,
sum_sales double precision not null
);

create table categories
(
id_cat int primary key not null,
name_cat varchar(100) not null
);

create table delivery
(
id_delivery int  Identity(1,1) primary key,
id_producer int not null,
id_product int not null,
ammount int not null,
sum_delivery double precision not null,
date_delivery date not null
);

select * from delivery
delete from delivery