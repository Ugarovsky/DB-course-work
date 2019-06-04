use StoreDB;

GO
create procedure RandString (@r nvarchar(5) output)
as
begin
declare @s nvarchar(5)
SET @s = (
SELECT
	c1 AS [text()]
FROM
	(
	SELECT TOP (5) c1
	FROM
	  (
    VALUES
      ('A'), ('B'), ('C'), ('D'), ('E'), ('F'), ('G'), ('H'), ('I'), ('J'),
      ('K'), ('L'), ('M'), ('N'), ('O'), ('P'), ('Q'), ('R'), ('S'), ('T'),
      ('U'), ('V'), ('W'), ('X'), ('Y'), ('Z'), ('0'), ('1'), ('2'), ('3'),
      ('4'), ('5'), ('6'), ('7'), ('8'), ('9')	
	  ) AS T1(c1)
	ORDER BY ABS(CHECKSUM(NEWID()))
	) AS T2
FOR XML PATH('')
);
set @r = @s
end
GO
select * from products
select count(*) from products;
select * from categories;
select * from producer
go
alter procedure InsertRandValuesProducts
as begin
	declare @i int = 0
	while @i < 272
	begin
	declare @nP nvarchar(5) exec RandString @nP out
	declare @p int  = ROUND((RAND()* 100),0);
	declare @idP int = ROUND((RAND()* 13),1);
	declare @idC int = ROUND((RAND()* 11),0);
	declare @dP nvarchar(5) exec RandString @dP out
	declare @a int = ROUND((RAND()* 200),0);
	insert into products (name_product, price, id_producer,id_cat,description_product,ammount) values( @nP, @p,@idP, @idC, @dP, @a);
	set @i = @i +1
	end
	end
GO

InsertRandValuesProducts

drop index 

select id_cat from products;
create nonclustered index Products_index
on products(id_cat)
GO

create nonclustered index Products_idP_index
on products(id_product)
GO
create nonclustered index Products_nP_index
on products(name_product)
GO

create nonclustered index Products_pP_index
on products(price)
GO

select id_product from products;