#creating tables
#LOCATION 

CREATE TABLE LOCATIONS (
location_id int auto_increment  NOT NULL primary key,
location_name varchar(30) not null unique,
location_country varchar(30) not null,
short_location_country varchar(5) not null,
location_county varchar(30) not null,
short_location_county varchar(5) not null
);

describe locations;

commit;

/*alter table locations
add constraint unique_location_name unique(location_name);*/

##drop table locations;

#1
insert into locations
values(default, 'Alba Iulia', 'Romania', 'RO', 'Alba', 'AB');
#2
insert into locations
values(default, 'Arad', 'Romania', 'RO', 'Arad', 'AR');
#3
insert into locations
values(default, 'Pitesti', 'Romania', 'RO', 'Arges', 'AG');
#4
insert into locations
values(default, 'Bacau', 'Romania', 'RO', 'Bacau', 'BC');
#5
insert into locations
values(default, 'Oradea', 'Romania', 'RO', 'Bihor', 'BH');
#6
insert into locations
values(default, 'Bistrita', 'Romania', 'RO', 'Bistrita-Nasaud', 'BN');
#7
insert into locations
values(default, 'Botosani', 'Romania', 'RO', 'Botosani', 'BT');
#8
insert into locations
values(default, 'Brasov', 'Romania', 'RO', 'Brasov', 'BV');
#9
insert into locations
values(default, 'Targu Mures', 'Romania', 'RO', 'Mures', 'MS');
#10
insert into locations
values(default, 'Timisoara', 'Romania', 'RO', 'Timis', 'TM');

select * from locations;

#END LOCATION 

#SUPPLY_PLACES

CREATE TABLE SUPPLY_PLACES (
supply_place_id int auto_increment  not null primary key,
supply_place_name varchar(30) not null,
supply_place_address varchar(50) not null,
location_id int not null,
constraint fk_locations 
    foreign key (location_id) 
    references locations(location_id),
constraint unique_supply_place_name_address unique(supply_place_name, supply_place_address)
);

ALTER table supply_places 
modify supply_place_name varchar(65);

#select @row_number := @row_number +1 from dual;

insert into supply_places
values (default, 'Sunrise Stock', 'Strada Chimiei 6', 8);
insert into supply_places
values (default, 'Totally Stocked', 'Strada Principala 34', 2);
insert into supply_places
values (default, 'Material n More', 'Strada Mărăsesti 102', 1);
insert into supply_places
values (default, 'Supplium', 'Strada Nucului 28', 7);
insert into supply_places
values (default, 'Sunside Trading', 'Strada Marchian 11', 3);
insert into supply_places
values (default, 'HomeSweets Kft.', 'Strada Orizontului 2', 4);
insert into supply_places
values (default, 'SciTech', 'Strada Transilvaniei 131', 6);
insert into supply_places
values (default, 'Office Supplies', 'Strada Zăvoiului 11', 9);
insert into supply_places
values (default, 'Food Geenie', 'Strada Traian 95', 5);
insert into supply_places
values (default, 'Meat and Eat', 'Strada Sulfinei 4', 10);

select * from supply_places;

#drop table supply_places;
#END SUPPLY_PLACES

#SUPPLIERS
CREATE TABLE SUPPLIERS (
supplier_id int auto_increment not null primary key,
supplier_name varchar(50) not null,
supplier_phone_int varchar(15) not null,
supplier_email varchar(35) not null, 
supplier_address varchar(50) not null,
location_id int not null,
constraint fk_supplier_locations 
    foreign key (location_id) 
    references locations(location_id),
constraint unique_supplier unique(supplier_phone_int, supplier_email)
);

/*alter table suppliers
add constraint unique_supplier_phonenum_email unique(supplier_phone_int, supplier_email);*/

select * from suppliers;

#drop table suppliers;

insert into suppliers
values (default, 'Horea Anghelescu', '0722748649', 'horea_anghelescu@gmail.com', 'Strada Stirbei Voda nr. 87', 1);
insert into suppliers
values (default, 'Teofil Iliescu', '0724269171', 'teofil_iliescu@gmail.com', 'Bulevardul 1 Decembrie 1918 nr.11', 2);
insert into suppliers
values (default, 'Narcisa Gheorghe', '0236461128', 'narcisa_gheorghe@yahoo.com', 'Strada Spitalului nr. 7', 3);
insert into suppliers
values (default, 'Mircea Petrescu', '0248723100', 'mirceapetrescu@gmail.com', 'Strada Barboi nr. 8', 4);
insert into suppliers
values (default, 'Dionisie Ciobanu', '0722900745', 'dionisie-ciobanu@gmail.com', 'Strada Faleza Sud Bl.36, Sc.A, Ap.2', 5);
insert into suppliers
values (default, 'Violeta Gheorghe', '0729014396', 'violetagheorghe@yahoo.com', 'Bulevardul Magheru 26, Bl.Casata, Ap.33', 6);
insert into suppliers
values (default, 'Emilian Ionescu', '0745977447', 'emilian_ionescu@yahoo.com', 'Strada Constructorilor nr. 11', 7);
insert into suppliers
values (default, 'Rebeca Stan', '0269523553', 'rebecastan99@gmail.com', 'Strada Vasile Alecsandri, Bl.G1, Ap.5', 8);
insert into suppliers
values (default, 'Luca Grigorescu', '0721672531', 'luca_grigorescu78@yahoo.com', 'Strada Traian nr. 117', 9);
insert into suppliers
values (default, 'Delia Bălan', '0788648979', 'deliabalan00@gmail.com', 'Strada Gh.Doja 4', 10);

#END SUPPLIERS

/*select * 
from suppliers s1 join supply_places s2
on s1.location_id = s2.location_id
order by s1.location_id;*/

#SUPPLYING
CREATE TABLE SUPPLYING(
supplying_id int auto_increment not null primary key,
supplying_date date not null,
supplying_time time not null,
supplying_place_id int not null,
supplier_id int not null,
constraint fk_supply_place_id
    foreign key (supplying_place_id) 
    references supply_places(supply_place_id),
constraint fk_supplier_id 
    foreign key (supplier_id) 
    references suppliers(supplier_id)
);

#drop table supplying;

#foreign key inserting
/*insert into tablename
select s1.supplier_name, s1.supplier_id
from suppliers s1 join supply_places s2
on s1.location_id = s2.location_id;*/

#date and time
#insert into tablename values(date_format(to_char(sysdate, 'MM:DD:YY HH24:MI'), 'MM:DD:YY HH24:MI'), to_char(sysdate, 'HH24:MI'));


set @row_number = 0;
insert into supplying
select @row_number := @row_number +1 , date_format(sysdate(), '%Y-%m-%d'), convert(sysdate(), time), s2.supply_place_id, s1.supplier_id
from suppliers s1 join supply_places s2
on s1.location_id = s2.location_id;

ALTER TABLE supplying AUTO_INCREMENT = 1;

/*insert into supplying 
values (default, date_format(to_char(sysdate, 'MM:DD:YY HH24:MI'), 'MM:DD:YY HH24:MI'), to_char(sysdate, 'HH24:MI'), 30, 67);
insert into supplying 
values (default, date_format(to_char(sysdate, 'MM:DD:YY HH24:MI'), 'MM:DD:YY HH24:MI'), to_char(sysdate, 'HH24:MI'), 30, 61);*/

select * from supplying;
#END SUPPLYING

#DEPARTMENTS
CREATE TABLE DEPARTMENTS(
department_id int auto_increment  not null primary key,
department_name varchar(30) not null unique
);

select * from departments;

/*alter table departments 
add constraint unique_dep_name_man unique(department_name, manager_id);*/

#random data
/*select location_id from locations order by rand()  limit 1;*/

/*insert into departments 
select @row_number := @row_number +1, 'Sales associate', location_id, 100 
from ( select location_id from locations 
order by rand()  
limit 1);*/

insert into departments 
values (default, 'Inventory management');
insert into departments 
values (default, 'Marketing');
insert into departments 
values (default, 'Logistics');
insert into departments 
values (default, 'HR');
insert into departments 
values (default, 'Finance');
insert into departments 
values (default, 'Advertisement');
insert into departments 
values (default, 'Security');
insert into departments 
values (default, 'Customer Service');
insert into departments 
values (default, 'Production');
insert into departments 
values (default, 'Technical');
insert into departments
values (default, 'Accounting');

select * from departments;

#drop table departments;
#END DEPARTMENTS

commit; 
#POSITIONS

CREATE TABLE POSITIONS(
position_id int auto_increment not null primary key,
position_name varchar(30) not null,
department_id int not null,
constraint fk_position_department_id
foreign key (department_id) 
    references departments(department_id),
constraint unique_pos unique(position_name, department_id)    
);

insert into positions 
select @row_number := @row_number +1, 'Cashier', department_id
from departments
where department_name like 'Accounting';
insert into positions 
select @row_number := @row_number +1, 'Leadership Training', department_id
from departments
where department_name like 'HR';
insert into positions 
select @row_number := @row_number +1, 'Insurance', department_id
from departments
where department_name like 'HR';
insert into positions 
select @row_number := @row_number +1, 'Advertising Creative', department_id
from departments
where department_name like 'Marketing';
insert into positions 
select @row_number := @row_number +1, 'Security Guard', department_id
from departments
where department_name like 'Security';
insert into positions 
select @row_number := @row_number +1, 'Engineer', department_id
from departments
where department_name like 'Technical';
insert into positions 
select @row_number := @row_number +1, 'IT Coordinator', department_id
from departments
where department_name like 'Technical';
insert into positions 
select @row_number := @row_number +1, 'Social Media Management', department_id
from departments
where department_name like 'Marketing';
insert into positions
select @row_number := @row_number +1, 'Manager', department_id
from departments;

select * from positions;

#drop table positions; 

#END POSITIONS

#SHOPS

CREATE TABLE SHOPS(
shop_id int auto_increment not null primary key,
shop_name varchar(20) not null,
shop_address varchar(40) not null,
location_id int not null,
department_id int not null,
constraint fk_shops_department_id
    foreign key (department_id) 
    references departments(department_id),
constraint fk_shop_location_id
    foreign key (location_id) 
    references locations(location_id),
constraint unique_loc_dep unique(shop_name, shop_address, location_id, department_id)
);

/*insert into shops 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments)
select @row_number := @row_number +1, 'Kaufland', 'Strada Maior Georgescu 4', location_id, department_id 
from ( select location_id, department_id
from loc, dep
order by rand()  
limit 1);*/

insert into shops 
select @row_number := @row_number +1, 'Kaufland', 'Strada Frunzei 30', t1.li, t1.di 
from ( select l.location_id as li, d.department_id as di, d.department_name as dn
from locations l
cross join departments d) as t1
where t1.li = 1;

/*insert into shops 
values (@row_number := @row_number +1, 'Kaufland', 'Strada Maior Georgescu 4', 4, 201 );
;*/

select * from shops;

#drop table shops;

#END SHOPS

#EMPLOYEES

CREATE TABLE EMPLOYEES(
emp_id int auto_increment not null primary key,
emp_name varchar(50) not null,
emp_phone_num varchar(15) not null unique,
emp_email varchar(35) not null unique,
location_id int not null,
emp_address varchar(50) not null,
shop_id int not null,
department_id int not null,
emp_position varchar(15) not null,
emp_salary int not null,
constraint fk_emp_shop_id
    foreign key (shop_id) 
    references shops(shop_id),
constraint fk_emp_department_id
    foreign key (department_id) 
    references departments(department_id),
constraint fk_emp_location_id
    foreign key (location_id) 
    references locations(location_id),
constraint unique_emps unique(emp_name, emp_phone_num, emp_email, emp_address)
);

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Lena Csorba', '0721508599', 'csorbalena@gmail.com', t1.location_id, 'BD. Rebreanu Liviu nr. 2/1 sc. B ap. 18', t1.shop_id, t1.department_id, t1.position_id, 2000
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand()
limit 1) as t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Mircea Bartha', '0745617158', 'mirceabartha89@gmail.com', location_id, 'BD. Rebreanu Liviu nr. 2/1 sc. B ap. 18', shop_id, department_id, position_id, 2000
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand()
limit 1) as t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Szandra Fábián', '0234542820', 'szandrafabian99@gmail.com', location_id, 'Strada Bucuresti 106', shop_id, department_id, position_id, 1800
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand()
limit 1) t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Mihail Czinege', '0230522677', 'mihail_czinege@yahoo.com', location_id, 'Strada Fratii Golesti 22', shop_id, department_id, position_id, 2200
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand() 
limit 1) t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Ferdinánd Horváth', '0213207024', 'ferdi_horvath28@yahoo.com', location_id, 'Strada Eroilor 6', shop_id, department_id, position_id, 2500
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand() 
limit 1) t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Eszter Pék', '0721254656', 'eszterpek23@yahoo.com', location_id, 'Strada Romulus 62', shop_id, department_id, position_id, 2500
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand() 
limit 1)t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Teofil Salamon', '0265773167', 'teo_salamon@yahoo.com', location_id, 'BD. 22 DECEMBRIE nr. 58', shop_id, department_id, position_id, 2000
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand() 
limit 1)t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Ildiko Vencel', '+40(259)415438', 'ildiko_vencel@gmail.com', location_id, 'Strada Vulcan 4', shop_id, department_id, position_id, 2800
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand() 
limit 1)t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id
            from shops)
select @row_number := @row_number +1, 'Lőrinc Oláh', '+40(266)371429', 'lolah43@gmail.com', location_id, ' Bulevardul Regina Elisabeta 7-9', shop_id, department_id, position_id, 2800
from ( select location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
order by rand() 
limit 1)t1;

insert into employees 
with loc as (select location_id
            from locations),  
    dep as (select department_id
            from departments),
    pos as (select position_id
            from positions),
    shop as (select shop_id, location_id
            from shops)
select @row_number := @row_number +1, 'Tiborc Pataki', '+40(727)944596', 'patakitiborc98@gmail.com', location_id, 'PŢA UNIRII bl. 6', shop_id, department_id, position_id, 2800
from ( select loc.location_id, department_id, position_id, shop_id
from loc, dep, pos, shop
where loc.location_id = shop.location_id
order by rand() 
limit 1)t1;

select * 
from employees e
join shops s
on e.shop_id = s.shop_id;


#drop table employees;
#END EMPLOYEES

#CATEGORIES

CREATE TABLE CATEGORIES(
category_id int auto_increment not null primary key,
category_name varchar(25) not null
);

#drop table categories;
select * from categories;

insert into categories 
values (default, 'Bevarages');
insert into categories 
values (default, 'Dairy');
insert into categories 
values (default, 'Cereals');
insert into categories 
values (default, 'Fruit and vegetables');
insert into categories 
values (default, 'Meat');
insert into categories 
values (default, 'Coffee and Tea');
insert into categories 
values (default, 'Bakery');
insert into categories 
values (default, 'Snacks');
insert into categories 
values (default, 'Electronics');
insert into categories 
values (default, 'Pet');

#END CATEGORIES

#DISCOUNT

CREATE TABLE DISCOUNT(
discount_id int auto_increment not null primary key,
start_date date,
end_date date,
percentage int,
constraint unique_discount_date unique(start_date, end_date, percentage)
);

insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 10);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 20);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 25);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 40);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 50);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 60);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 65);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 70);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 80);
insert into discount
values (@row_number := @row_number +1, date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y'), 90);

/*select date_format(sysdate(),'%m:%d:%y'), date_format(sysdate()+7, '%m:%d:%y') from dual;*/

#drop table discount; 
select * from discount;
#END DISCOUNT

#PRODUCTS

CREATE TABLE PRODUCTS(
product_id int auto_increment not null primary key,
product_name varchar(20) not null,
category_id int not null,
quantity int not null,
normal_price_per_piece int not null, 
discount_price_per_piece int, 
discount_id int,
constraint fk_prod_category_id
    foreign key (category_id) 
    references categories(category_id),
constraint fk_prod_discount_id
    foreign key (discount_id) 
    references discount(discount_id),
constraint unique_product unique(product_name, category_id),
constraint unique_product_discount unique(product_name, category_id, discount_id)
);

alter table products
drop constraint unique_product_discount;

insert into products
select @row_number := @row_number +1, 'Green Apple', c.category_id, 200, 2.5, 2.5 - (d.percentage * 2.5)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%Fruit%'
and d.percentage = 50;

insert into products
select @row_number := @row_number +1, 'Red Apple', c.category_id, 250, 3.0, 3.0 - (d.percentage * 3.0)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%Fruit%'
and d.percentage = 25;

insert into products
select @row_number := @row_number +1, 'Orange', c.category_id, 300, 5.50, 5.5 - (d.percentage * 5.5)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%Fruit%'
and d.percentage = 50;

insert into products
select @row_number := @row_number +1, 'Tomato', c.category_id, 300, 6.0, 6.0 - (d.percentage * 6.0)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%vegetable%'
and d.percentage = 10;

insert into products
select @row_number := @row_number +1, 'Pomelo', c.category_id, 150, 7.50, 7.5 - (d.percentage * 7.5)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%Fruit%'
and d.percentage = 20;

insert into products
select @row_number := @row_number +1, 'Mineral Water', c.category_id, 200, 2.0, null, null 
from categories c
where c.category_name like '%evarage%';

insert into products
select @row_number := @row_number +1, 'Coca Cola', c.category_id, 180, 3.5, null, null
from categories c
where c.category_name like '%evarage%';

insert into products
select @row_number := @row_number +1, 'Milk', c.category_id, 100, 5.0, 5.0 - (d.percentage * 5.0)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%airy%'
and d.percentage = 10;

insert into products
select @row_number := @row_number +1, 'Bread', c.category_id, 100, 5.0, null, null
from categories c 
where c.category_name like '%akery%';

insert into products
select @row_number := @row_number +1, 'Croissant', c.category_id, 80, 3.0, 3.0 - (d.percentage * 3.0)/100, d.discount_id 
from categories c join discount d
on 1=1
where c.category_name like '%akery%'
and d.percentage = 10;


insert into products
select @row_number := @row_number +1, 'Pain au Chocolate', 7, 85, 3.5, 3.5 - (90 * 3.5)/100, d.discount_id 
from discount d
where d.discount_id = (select discount_id from discount where percentage = 90 limit 1);

select * from products;
#drop table products;

describe employees;

/*select p.product_name, normal_price_per_piece, normal_price_per_piece - (d.percentage * normal_price_per_piece)/100, p.discount_price_per_piece
from products p join discount d
on p.discount_id = d.discount_id;*/

#END PRODUCTS

#CUSTOMERS

CREATE TABLE CUSTOMERS(
customer_id int auto_increment not null primary key,
customer_name varchar(30) not null,
customer_phone_num varchar(15) not null unique,
customer_email varchar(35) not null unique,
location_id int not null,
customer_adress varchar(30) not null,
constraint fk_customer_loc_id
    foreign key (location_id) 
    references locations(location_id),
constraint unique_customer unique(customer_name, customer_phone_num, customer_email, location_id, customer_adress)
);

alter table customers 
modify customer_adress varchar(50);

insert into customers
select @row_number := @row_number +1, 'Álmos Bartha', '+40(246)285017', 'almosbartha@gmail.com', location_id, 'Calea Plevnei 46'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Krisztina Somogyi', '0744583355', 'ksomogyi@gmail.com', location_id, 'Strada Lunca Mare 20'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'David Ionescu', '0213103127', 'davidionescu@gmail.com', location_id, 'Strada Cuza Voda Bl.44'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Beniamin Oláh', '0745625051', 'beniolah02@gmail.com', location_id, 'Strada Pictor Aman 7A'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Csilla Kováts', '+40(264)403330', 'cskovats18@gmail.com', location_id, 'Strada Badea Cartan 51'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Tatiana Morar', '0257279776', 'tmorar@gmail.com', location_id, 'STR. BRÂNDUŞELOR nr. 13'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Mihaela Barnutiu', '0253378165', 'mihabarnutiu87@gmail.com', location_id, 'STR. MARAMUREŞULUI nr. 4'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Rajmund Sárközi', '0374062555', 'rajmisarkozi22@gmail.com', location_id, 'STR. MARAMUREŞULUI nr. 4'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Elena Somoghi', '+40(261)759037', 'elenasomoghi28@gmail.com', location_id, 'STR. LUCEAFĂRUL nr. 4 ap. 12'
from (select location_id 
        from locations
        order by rand() 
        limit 1);
        
insert into customers
select @row_number := @row_number +1, 'Lidia Halmi', '+40(21)3151332', 'lidiahalmi@gmail.com', location_id, 'Strada Cercetatorilor 6'
from (select location_id 
        from locations
        order by rand() 
        limit 1);

insert into customers
select max(customer_id)+1, 'Lena Csorba','0721508599','csorbalena@gmail.com', 7,'BD. Rebreanu Liviu nr. 2/1 sc. B ap. 18'
from customers;

#drop table customers;
select * from customers;

commit;
#END CUSTOMERS

#PAYMENT_TYPE


CREATE TABLE PAYMENT_TYPE(
payment_type_id int auto_increment not null primary key,
payment_type_name varchar(10) not null
);

insert into payment_type
values (default, 'Cash');
insert into payment_type
values (default, 'Card');

#drop table payment_type;
select * from payment_type;
#END PAYMENT_TYPE

#ORDER_PRODUCTS

CREATE TABLE ORDER_PRODUCTS(
order_products_id int auto_increment not null primary key,
quantity int not null,
product_id int not null,
bill_id int not null
);

select * from products;

insert into order_products
select @row_number := @row_number +1, 2, product_id, bill_@row_number := @row_number +1 
from (select product_id, product_name, case when quantity >= 2
    then quantity - 2
    end 
        from products
        order by rand() 
        limit 1)
;

insert into order_products
select @row_number := @row_number +1, 3, product_id, bill_ids.currval 
from (select product_id, product_name, case when quantity >= 3
    then quantity - 3
    end 
        from products
        order by rand() 
        limit 1)
;

update products p 
set 
p.quantity = p.quantity - (select sum(op.quantity) from order_products op group by op.product_id)
where p.product_id in (select op.product_id from order_products op where p.product_id = op.product_id);

/*select sum(op.quantity), p.product_name
from order_products op join products p 
on op.product_id = p.product_id
group by p.product_id, p.product_name;*/

#drop table order_products;
select * 
from order_products op join products p 
on op.product_id = p.product_id;

commit;

#END ORDER_PRODUCTS

#BILLS

CREATE TABLE BILLS(
bill_id int auto_increment not null primary key,
bill_datetime varchar(14) not null,
location_id int not null,
payment_type_id int not null,
customer_id int not null,
employee_id int not null,
shop_id int not null,
total int not null,
constraint fk_bill_location_id
    foreign key (location_id) 
    references locations(location_id),    
constraint fk_bill_payment_type_id
    foreign key (payment_type_id) 
    references payment_type(payment_type_id),
constraint fk_bill_customer_id
    foreign key (customer_id) 
    references customers(customer_id),
constraint fk_bill_emp_id
    foreign key (employee_id) 
    references employees(emp_id),
constraint fk_bill_shop_id
    foreign key (shop_id) 
    references shops(shop_id),
constraint unique_bill unique(bill_datetime, location_id, payment_type_id, customer_id, employee_id, shop_id)
);

/*select to_char(sysdate, 'DD.MM.YY HH:MI') from dual;*/

insert into bills(bill_id, bill_datetime, location_id, payment_type_id, customer_id, employee_id, shop_id, total)
with loc as (select location_id
            from locations),  
    paytype as (select payment_type_id
            from payment_type),
    cust as (select customer_id
            from customers),
    emp as (select emp_id, shop_id
            from employees),
    shop as (select shop_id, shop_address, location_id
            from shops),
    prodsum as (select op.bill_id, op.product_id as pi, sum(op.quantity) as q,
        case when (sum(p.discount_price_per_piece)) is null then sum(p.normal_price_per_piece)
        else (sum(p.discount_price_per_piece)) end as fin
        from order_products op join products p
        on op.product_id = p.product_id
        group by op.bill_id, op.product_id, p.product_name
        )
select f.pb, to_char(sysdate, 'DD.MM.YY HH:MI'), f.loci, f.pi, f.ci, f.ei, f.shopi, f.t
from 
    (select d.loci, d.shoploci, d.shopi, d.shopa, d.pi, d.ci, d.ei, pr.pb, sum(pr.am) as t
    from ( select prodsum.bill_id as pb, sum(prodsum.q*prodsum.fin) as am
            from prodsum
            group by prodsum.bill_id
            order by rand()  
            limit 1) pr, 
        ( select loc.location_id as loci, shop.location_id as shoploci, shop.shop_address as shopa, shop.shop_id as shopi,  paytype.payment_type_id as pi, cust.customer_id as ci, emp.emp_id as ei
            from loc, paytype, cust, emp, shop 
            order by rand()  
            limit 1) d
            group by d.loci, d.shoploci, d.shopi, d.shopa, d.pi, d.ci, d.ei, pb, am) f
;
#order by rand() 
#limit 1;

#prodsum.bill_id, shop.location_id, shop.shop_address,shop.shop_id,  paytype.payment_type_id, cust.customer_id, emp.emp_id,  prodsum.q*prodsum.fin as total

/*select sum(case when (sum(p.discount_price_per_piece)) is null then sum(p.normal_price_per_piece)
        else (sum(p.discount_price_per_piece)) end) as fin
from order_products op join products p
on op.product_id = p.product_id
group by op.product_id, p.product_name, op.bill_id;*/

/*select op.bill_id, op.product_id, p.product_name, sum(op.quantity), sum(p.normal_price_per_piece) as norm, sum(p.discount_price_per_piece) as discount, 
        case when (sum(p.discount_price_per_piece)) is null then sum(op.quantity * p.normal_price_per_piece)
        else (sum( op.quantity * p.discount_price_per_piece)) end as fin
from order_products op join products p
on op.product_id = p.product_id
group by op.bill_id, op.product_id, p.product_name, op.quantity
order by op.bill_id;*/

/*select p.product_name, normal_price_per_piece as norm, normal_price_per_piece - (d.percentage * normal_price_per_piece)/100 as dis1, p.discount_price_per_piece as dis2, percentage
from products p join discount d
on p.discount_id = d.discount_id;*/

/*with b as (select op.bill_id, op.product_id as pi, sum(op.quantity) as q,
        case when (sum(p.discount_price_per_piece)) is null then sum(p.normal_price_per_piece)
        else (sum(p.discount_price_per_piece)) end as fin
        from order_products op join products p
        on op.product_id = p.product_id
        group by op.bill_id, op.product_id, p.product_name)
select bill_id, sum(q*fin)
from b
group by bill_id;*/

#drop table bills;
select * from bills;

commit;
#END BILLS

#PURGE 
/*Begin
for c in (select table_name from user_tables) loop
execute immediate ('#drop table "'||c.table_name||'" cascade constraints');
end loop;
End;
/
PURGE RECYCLEBIN;*/