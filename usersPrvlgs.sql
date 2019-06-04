use StoreDB;

--client
-- client qwe123

grant execute on getAllUsers to [client] with grant option
grant execute on getAllCat to [client] with grant option
grant execute on selectProducts to [client] with grant option
grant execute on buySelectedProduct to [client] with grant option
grant execute on filtrProduct to [client] with grant option

--employee
--empl qwe123
grant execute on selectProducts to [empl] with grant option
grant execute on getAllCat to [empl] with grant option
grant execute on addNewProduct to [empl] with grant option
grant execute on getAllProducers to [empl] with grant option
grant execute on startDelivery to [empl] with grant option

--admin
--adm qwe123
grant execute on selectProducts to [adm] with grant option
grant execute on addNewEmployee to [adm] with grant option
grant execute on selectEmployee to [adm] with grant option
grant execute on deleteEmployeeId to [adm] with grant option
grant execute on updateEmployeeId to [adm] with grant option
grant execute on deleteAllEmployee to [adm] with grant option
grant execute on updatePriceProduct to [adm] with grant option
grant execute on getAllCat to [adm] with grant option
grant execute on updateCategory to [adm] with grant option
grant execute on setDiscountCategory to [adm] with grant option
grant execute on addNewProduct to [adm] with grant option
grant execute on getAllProducers to [adm] with grant option
grant execute on deleteProductId to [adm] with grant option
grant execute on getAllSales to [adm] with grant option
grant execute on getAllDelivery to [adm] with grant option



