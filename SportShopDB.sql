USE SportShop
--Задание 1. Для базы данных «Спортивный магазин» из
--практического задания модуля «Триггеры, хранимые процедуры и пользовательские функции» выполните набор действий:
--1. Запретите пользователю с логином Марк получать информацию о продавцах
--2. Разрешите пользователю с логином Дэвид получать информацию только о продавцах
--3. Предоставьте полный доступ к базе данных пользователю
--с логином Ольга
--4. Предоставьте доступ только на чтение таблиц с информацией о продавцах, товарах в наличии пользователю с
--логином Константин.


go

-- 1
create login [MaxKhlv] with password = 'MaxKhlv';

create user UserMaxKhlv for login MaxKhlv;

grant select on SportShop. to UserMark;

deny select on SportShop.Sellers to UserMaxKhlv;



-- 2

create login Qrib with password = 'Qrib';

create user UserQrib for login Qrib;

grant select on SportShop.Sellers to UserQrib;

grant select on SportShop.Persons to UserKonstantin;

grant select on SportShop.Positions to UserKonstantin;

grant select on SportShop.Genders to UserKonstantin;



-- 3

create login Olga with password = 'Olga';

create user UserOlga for login Olga;

exec sp_addrolemember 'db_owner' , 'UserOlga';



-- 4

create login Konstantin with password = 'Konstantin';

create user UserKonstantin for login Konstantin;

grant select on SportShopDB.Sellers to UserKonstantin;

grant select on SportShopDB.Persons to UserKonstantin;

grant select on SportShopDB.Positions to UserKonstantin;

grant select on SportShopDB.Genders to UserKonstantin;

grant select on SportShopDB.Products to UserKonstantin;

grant select on SportShopDB.ProductTypes to UserKonstantin;

grant select on SportShopDB.Manufacturers to UserKonstantin;
