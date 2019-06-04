create database StoreDB;
use storeDB;

select * from producer;
insert into producer(name_producer, country,city) values ('Дняпроўскi збан','РБ','Гомель');
insert into producer(name_producer, country,city) values ('Идеал','РБ','Минск');
insert into producer (name_producer, country,city) values ('Кстати','РБ','Гродно');
insert into producer(name_producer, country,city) values ('Бабушкины деликатесы','РБ','Могилёв');
insert into producer(name_producer, country,city) values ('Белорусская кофейня','РБ','Витебск');
insert into producer(name_producer, country,city) values ('Вкус рыбы','РБ','Речица');
insert into producer(name_producer, country,city) values ('Коммунарка','РБ','Минск');
insert into producer(name_producer, country,city) values ('Трайпл','РБ','Брест');
insert into producer(name_producer, country,city) values ('МяскоВит','РБ','Минск');
insert into producer(name_producer, country,city) values ('ТворожкоМорожко','РФ','Смоленск');
insert into producer(name_producer, country,city) values ('Хлебный Дар','РФ','Москва');
insert into producer(name_producer, country,city) values ('Ферма','РБ','Минская область');
insert into producer(name_producer, country,city) values ('Хозяйственная Ферма','РФ','Московская область');
insert into producer(name_producer, country,city) values ('Соусный мир','Украина','Киев');

select * from categories;

insert into categories(id_cat, name_cat) values(0, 'молочные продукты');
insert into categories(id_cat, name_cat) values(1, 'соки,напитки');
insert into categories(id_cat, name_cat) values(2, 'мясо');
insert into categories(id_cat, name_cat) values(3, 'рыба');
insert into categories(id_cat, name_cat) values(4, 'чай, кофе');
insert into categories(id_cat, name_cat) values(5, 'конфеты');
insert into categories(id_cat, name_cat) values(6, 'печенье');
insert into categories(id_cat, name_cat) values(7, 'зерновые');
insert into categories(id_cat, name_cat) values(8, 'фрукты');
insert into categories(id_cat, name_cat) values(9, 'овощи');
insert into categories(id_cat, name_cat) values(11, 'соусы');
insert into categories(id_cat, name_cat) values(12, 'хлебобулочные изделия');


select * from products;
insert into products(name_product,price, id_producer, id_cat, description_product,ammount) values('Хлеб', 1, 11,12, 'Нормальный хлеб', 50);
insert into products(name_product,price, id_producer, id_cat, description_product,ammount) values('Батон', 1.2, 11,12, 'Нормальный батон', 30);

create table products
(
id_product int Identity(1,1) primary key,
name_product varchar(100),
price double precision,
id_producer int,
id_cat int,
description_product varchar(100),
ammount int
);

create table producer
(
id_producer int Identity(1,1) primary key,
name_producer varchar(100),
country varchar(100),
city varchar(20) 
);

create table employee
(
id_employee int Identity(1,1) primary key,
name_employee varchar(100),
surname_employee varchar(100),
post varchar(100),
empl_login varchar(100),
empl_passw varchar(100),
salary double precision
);

create table sales
(
id_sales int Identity(1,1) primary key,
date_sales date,
id_product int,
ammount int,
sum_sales double precision
);

create table categories
(
id_cat int primary key,
name_cat varchar(100)
);

create table delivery
(
id_delivery int  Identity(1,1) primary key,
id_producer int,
id_employee int,
id_product int,
ammount int,
sum_delivery double precision
);

go
create procedure addNewEmployee
(
@name_employee varchar(100),
@surname_employee varchar(100),
@post varchar(100),
@log varchar(100),
@pass varchar (100),
@salary double precision
)
as
insert into employee (name_employee,surname_employee, post,empl_login,empl_passw, salary)
values (@name_employee, @surname_employee,@post, @log, @pass, @salary);

select * from employee;
select * from products;
drop procedure selectProducts;

create procedure selectProducts
as select id_product, name_product, price, description_product,ammount, (select name_cat from categories where products.id_cat = categories.id_cat), (select name_producer from producer where products.id_producer = producer.id_producer) from products;

select * from employee;

create procedure selectEmployee
as select id_employee, name_employee, surname_employee, post, empl_login, empl_passw, salary from employee;

create procedure deleteEmployeeId(@id int)
as delete from employee where id_employee = @id;


create procedure updateEmployeeId(@id int,@name_employee varchar(100), @surname_employee varchar(100), @post varchar(100), @empl_login varchar(100), @empl_passw varchar(100), @salary float )
as update employee set name_employee = @name_employee, surname_employee = @surname_employee, post = @post,
empl_login = @empl_login, empl_passw = @empl_passw, salary = @salary where id_employee = @id; 

create procedure deleteAllEmployee
as delete from employee;

create procedure updatePriceProduct
(
@id int,
@price float
)
as update products set price = @price where products.id_product = @id;

create procedure getAllCat
as select id_cat, name_cat  from categories;

create procedure updateCategory(@id int , @newname varchar(30))
as update categories set name_cat = @newname where id_cat = @id;

create procedure setDiscountCategory(@id int ,@discount int)
as update products set price = (price * @discount) /100 where id_cat = @id;

create procedure getAllProducers
as select * from producer;

create procedure addNewProduct
(
@nameP varchar(30),
@price float,
@idP int,
@idC int,
@desc varchar(50),
@am int 
)
as insert into products(name_product, price, id_producer, id_cat, description_product, ammount)
values (@nameP,@price,@idP,@idC,@desc,@am);

create procedure deleteProductId(@id int)
as delete from products where id_product = @id;

drop procedure getAllSales;
create procedure getAllSales
as select id_sales,date_sales,id_product, (select name_product from products where products.id_product = sales.id_product), ammount,sum_sales from sales;
getAllSales
select * from products;
select * from sales
insert into sales(date_sales,id_product,ammount,sum_sales) values('12.12.2016',2,1,1);

drop table delivery;
drop procedure getAllUsers
create procedure getAllUsers
as select empl_login, empl_passw,post from employee


drop procedure getAllDelivery;

create procedure getAllDelivery
as  select id_delivery,id_producer, (select name_producer from producer where  producer.id_producer = delivery.id_producer),
id_employee,  ( select empl_login from employee where delivery.id_employee = employee.id_employee),id_product, (select name_product from products where products.id_product = delivery.id_product),
ammount, sum_delivery from delivery;
 
 select * from delivery;
  select * from employee;
  select * from producer;
  select * from products;

 insert into delivery(id_producer,id_employee, id_product, ammount, sum_delivery) values (10,10,3,20,40);

 drop procedure buySelectedProduct;

 create procedure buySelectedProduct(@id int, @am int)
 as 
 declare @amm int;
 SET @amm = (select ammount from products where id_product = @id);
 if @amm >@am
 BEGIN
 update products set ammount = ammount - @am where id_product = @id;
  declare @s int;
 declare @date date;
 declare @p float;
 SET @p = (select price from products where id_product = @id);
 SET @s = @am * @p;
 SET @date = GETDATE();
 insert into sales(date_sales,id_product,ammount,sum_sales) values
 (@date, @id,@am,@s);
 END


 delete from sales;

 select * from sales;

 create procedure filtrProduct(@id int)
 as select id_product, name_product, price, description_product,ammount, 
 (select name_cat from categories where products.id_cat = categories.id_cat),
  (select name_producer from producer where products.id_producer = producer.id_producer)
  from products where id_cat = @id;


  drop procedure getAllEmplLogPass
  create procedure getAllEmplLogPass (@l varchar(10) , @p varchar(10))
  as select empl_login, empl_passw, post from employee;


  select * from delivery;
  delete from delivery;

  create procedure startDelivery
  (
  @id int,
  @price float,
  @idP int,
  @log varchar(10),
  @am int
  )
  as
  BEGIN
  declare @idE int;
  SET @idE = (select id_employee from employee where empl_login = @log);
  declare @sD float;
  SET @sD = @price * @am;
  END
  insert into delivery (id_producer,id_employee,id_product,ammount,sum_delivery)
  values(@idP,@idE,@id,@am,@sD);
  update products set ammount = ammount + @am;