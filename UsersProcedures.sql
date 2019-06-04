use StoreDB;

select * from products;
go
alter procedure addNewEmployee
(
@name_employee varchar(100),
@surname_employee varchar(100),
@post varchar(100),
@log varchar(100),
@pass varchar (100),
@salary double precision
)
as begin
begin try
insert into employee (name_employee,surname_employee, post,empl_login,empl_passw, salary)
values (@name_employee, @surname_employee,@post, @log, @pass, @salary);
end try
		begin catch
		print error_message()
		end catch
end

go
alter procedure selectProducts
as select id_product, name_product, price, description_product,ammount,
 (select name_cat from categories where products.id_cat = categories.id_cat), 
(select name_producer from producer where products.id_producer = producer.id_producer) from products;

go
alter procedure selectEmployee
as select id_employee, name_employee, surname_employee, post, empl_login, empl_passw, salary 
from employee;



go
alter procedure deleteEmployeeId(@id int)
as
begin
begin try
 delete from delivery where id_employee = @id;
 delete from employee where id_employee = @id;
end try
begin catch
print error_message()
end catch
end

 go
alter procedure updateEmployeeId
(@id int,@name_employee varchar(100),
 @surname_employee varchar(100), 
 @post varchar(100), 
 @empl_login varchar(100), 
 @empl_passw varchar(100), 
 @salary float )
as begin
update employee set name_employee = @name_employee, surname_employee = @surname_employee, post = @post,
empl_login = @empl_login, empl_passw = @empl_passw, salary = @salary where id_employee = @id; 
end

go
alter procedure deleteAllEmployee
as
begin
begin try
 delete from delivery;
 delete from employee;
end try
begin catch 
print error_message()
end catch
end

go
alter procedure updatePriceProduct
(
@id int,
@price float
)
as
begin
 update products set price = @price where products.id_product = @id;
end

go
alter procedure getAllCat
as begin
select id_cat, name_cat  from categories;
end

go
alter procedure updateCategory(@id int , @newname varchar(30))
as begin
begin try
 update categories set name_cat = @newname where id_cat = @id;
 end try
 begin catch
 print error_message()
 end catch
 end
 
 go
alter procedure setDiscountCategory(@id int ,@discount int)
as
begin
update products set price = (price * @discount) /100 where id_cat = @id;
end;

go
alter procedure getAllProducers
as
begin 
select * from producer;
end;

go
alter procedure addNewProduct
(
@nameP varchar(30),
@price float,
@idP int,
@idC int,
@desc varchar(50),
@am int 
)
as 
begin
begin try
insert into products(name_product, price, id_producer, id_cat, description_product, ammount)
values (@nameP,@price,@idP,@idC,@desc,@am);
end try
begin catch
print error_message();
end catch
end

go
alter procedure deleteProductId(@id int)
as begin
begin tran
delete from delivery where id_product = @id;
delete from sales where id_product = @id;
delete from products where id_product = @id;
  IF (@@error <> 0)
        ROLLBACK
commit;
end

go
alter procedure getAllSales
as 
begin
select id_sales,date_sales,id_product, 
(select name_product from products where products.id_product = sales.id_product), 
ammount,sum_sales 
from sales;
end;

go
alter procedure getAllUsers
as
begin
select empl_login, empl_passw,post from employee
end;


go
alter procedure getAllDelivery
as  select id_delivery,id_producer, (select name_producer from producer where  producer.id_producer = delivery.id_producer),
id_employee,  ( select empl_login from employee where delivery.id_employee = employee.id_employee),id_product, (select name_product from products where products.id_product = delivery.id_product),
ammount, sum_delivery, date_delivery from delivery;



select * from products;
execute buySelectedProduct 3,136
go
alter procedure buySelectedProduct(@id int, @am int)
 as begin 
 begin tran
 begin try
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
 end try
 begin catch
 print error_message()
 rollback;
 end catch
 commit;
 END

 go
 alter procedure filtrProduct(@id int)
 as begin 
 select id_product, name_product, price, description_product,ammount, 
 (select name_cat from categories where products.id_cat = categories.id_cat),
  (select name_producer from producer where products.id_producer = producer.id_producer)
  from products where id_cat = @id;
  end;

  go
  alter procedure getAllEmplLogPass
  as begin
  select empl_login, empl_passw, post from employee;
  end
  
  go
  alter procedure startDelivery
  (
  @id int,
  @price float,
  @idP int,
  @log varchar(10),
  @am int
  )
  as
  BEGIN
  begin tran
  declare @idE int;
  SET @idE = (select id_employee from employee where empl_login = @log);
  declare @sD float;
  SET @sD = @price * @am;
  declare @nd date;
  set @nd = GETDATE();
  insert into delivery (id_producer,id_employee,id_product,ammount,sum_delivery,date_delivery)
  values(@idP,@idE,@id,@am,@sD,@nd);
  update products set ammount = ammount + @am where id_product = @id;
  IF (@@error <> 0)
        ROLLBACK  
  commit;
  END