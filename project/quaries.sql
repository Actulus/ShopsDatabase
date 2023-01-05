--1. Melyek azok a termékek, amelyek 50%-os akcióval rendelkeznek? (Mi a termék neve és az akciós ára?) 
select product_name as name, discount_price_per_piece as "FINAL PRICE"
from products p join discount d
on p.discount_id = d.discount_id
where d.percentage = 50;

--2. Melyek azok az alkalmazottak, akik a Kauflandnál dolgoznak? 
select emp_name as name
from employees e join shops s
on e.shop_id = s.shop_id 
where s.shop_name = 'Kaufland';

--3. Melyik az a vásárló, aki a legtöbb számlával rendelkezik? (Hany szamlaja van?)
select c.customer_name, count(bill_id) 
from bills b join customers c
on b.customer_id = c.customer_id
group by b.customer_id, c.customer_name
order by count(bill_id) desc
fetch first row only;

--4. Melyik fizetõeszközzel vásároltak a legtöbbet? 
select pt.payment_type_name, count(*)
from bills b join payment_type pt
on b.payment_type_id = pt.payment_type_id
group by b.payment_type_id, pt.payment_type_name;

--5. Melyik termékbõl vásároltak a legtöbbet? 
select p.product_name, count(op.quantity)
from order_products op join products p
on op.product_id = p.product_id
group by op.product_id, p.product_name
order by count(op.quantity) desc
fetch first row only;

--6. Melyik szakosztályon belül dolgoznak a legkevesebben? Hanyan es kik ezek a szemelyek?
with a as (select d.department_id as dept_id, count(e.emp_id) as c,
        listagg (e.emp_name, ', ') within group (order by e.emp_name) as employees
from departments d join employees e
on d.department_id = e.department_id
group by d.department_id
order by count(e.emp_id) asc)
select dept_id, c, employees 
from a
where c = (select c from a order by c asc fetch first row only)
order by dept_id;

--7. Melyik alkalmazott keres a legtöbbet?
select emp_name, emp_salary 
from employees
where emp_salary = (select emp_salary from employees order by emp_salary desc fetch first row only);

--8. Melyik alkalmazott keres a legkevesebbet?
select emp_name, emp_salary
from employees
where emp_salary = (select emp_salary from employees order by emp_salary asc fetch first row only);

--9. Egy adott kategóriába tartozó termékek egy cellában, vesszõvel elválasztva. (Listagg)
select c.category_name, listagg(p.product_name, ', ') within group (order by p.product_name)
from categories c join products p
on c.category_id = p.category_id
group by c.category_name;

--10. Melyek azok a termékek, amelyek a legnagyobb akcióval rendelkeznek? 
select * from products;
select * from discount;

select p.product_name, d.percentage 
from products p join discount d 
on p.discount_id = d.discount_id
where d.percentage = (select max(d.percentage) 
                        from products p join discount d 
                        on p.discount_id = d.discount_id);

--11. Melyik üzlet található meg a legtöbb helyen? (uzlet neve, hanyszor)
select * from shops;

select shop_name, count(*)
from shops
group by shop_name
having count(*) = (select count(*)
                    from shops 
                    group by shop_name
                    order by count(*) desc
                    fetch first row only);

--12. Kik azok a vásárlók, akiknek van ‘a’ betû a nevükben?
select * 
from customers
where customer_name like '%a%'
order by customer_id;

--13. Melyik kategóriából vásároltak a legkevesebbet? 
select c.category_name, count(p.product_name)
from order_products op
join products p 
on op.product_id = p.product_id
join categories c
on p.category_id = c.category_id
group by c.category_name
order by count(p.product_name) asc
fetch first row only;

--14. Van-e olyan alkalmazott, aki vásárló is? 
select * 
from employees e join customers c
on e.emp_name = c.customer_name;

--15. Melyik a legutoljára elõállított számla?
select max(bill_datetime) from bills;

--16. Hány számlát állítottak eddig elõ?
select count(*) from bills;

--17. A Marketing es HR reszlegen dolgozo alkalmazottak. (union)
(select e.emp_name, d.department_name
from departments d join employees e
on d.department_id = e.department_id
where d.department_name = 'Marketing')
union 
(select e.emp_name, d.department_name
from departments d join employees e
on d.department_id = e.department_id
where d.department_name = 'HR');

--18. Kik azok akik 4000 felett keresnek? (with clause)
with higher_salaries as (select emp_name, emp_salary
                        from employees 
                        where emp_salary > 4000)
select * 
from higher_salaries
order by emp_salary asc;


--19. Ki fizetett a legtöbbet egy vásárlás alkalmával?
select c.customer_name, b.total
from bills b join customers c
on b.customer_id = c.customer_id
where total = (select max(total) from bills);

--20. Melyik boltban adták el a legtöbb árut?
select s.shop_name, count(op.product_id)
from shops s 
join bills b
on s.shop_id = b.shop_id
join order_products op
on op.bill_id = b.bill_id
group by s.shop_name
order by count(op.product_id)
fetch first row ONLY;

--JSON
select json_object(
    'location_id' is location_id,
    'location_name' is location_name,
    'location_country' is location_country,
    'short_location_country' is short_location_country,
    'location_county' is location_county,
    'short_location_county' is short_location_county
)
from locations;

select json_object(
    'category_id' is category_id,
    'category_name' is category_name
)
from categories;

--21.Termekek es kategoriaik, ahol az atlagara a termeknek nagyobb mint a kategoriaban szereplo termekek
--atlagara, illetve hogy hanyat vettek belole. Termek nev es kategoria nev szerint rendezve. 
select * from products;
select * from categories;

SELECT AVG(normal_price_per_piece) 
FROM products p left join categories c
on p.category_id = c.category_id
where p.category_id = c.category_id;
--group by c.category_id, c.category_name;
 
 select * from products;
select * from order_products;

SELECT p.product_name, c.category_name,
    (SELECT AVG(normal_price_per_piece) FROM products p WHERE p.category_id = c.category_id) AS avg_price,
    (SELECT COUNT(*) FROM order_products op WHERE op.product_id = p.product_id) AS num_sold
FROM products p
INNER JOIN categories c ON p.category_id = c.category_id
WHERE p.normal_price_per_piece > (SELECT AVG(normal_price_per_piece) FROM products)
GROUP BY p.product_id, c.category_id, p.product_name, c.category_name
ORDER BY c.category_name ASC, p.product_name ASC;