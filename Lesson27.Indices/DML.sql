insert into Category (Title)
values ('TV'), ('Smatphones'), ('Cars')

insert into Products (CategoryId, Title, Price)
values 
(1, 'LG', 1000), (1, 'Samsung', 2000),
(2, 'iPhnone', 1000), (2, 'Xaomi', 2000),
(3, 'Tesla', 1000), (3, 'BMW', 2000)

insert into Customer (Name)
values ('Serhii')

insert into Orders (CustomerId, DeliveryMethod)
values (1, 'Pick-up')

insert OrderItems (ProductId, OrderId, Count)
values 
(1, 1, 2),
(3, 1, 1)

select * from Products p
	inner join Category c on (c.Id = p.CategoryId)
where c.Title <> 'Smatphones'


select c.Title, p.Title, p.Price from Products p
	inner join Category c on (c.Id = p.CategoryId)
where c.Title != 'Smatphones'

select c.Name, o.DeliveryMethod, ct.Title, p.Title, p.Price, oi.Count, oi.Count * p.Price from Orders o
	inner join Customer c on (o.CustomerId = c.Id)
	inner join OrderItems oi on (oi.OrderId = o.Id)
	inner join Products p on (oi.ProductId = p.Id)
	inner join Category ct on (p.CategoryId = ct.Id)
where c.Name = 'Serhii'

select * from Orders o
	inner join Customer c on (o.CustomerId = c.Id)
	inner join OrderItems oi on (oi.OrderId = o.Id)
	inner join Products p on (oi.ProductId = p.Id)
	inner join Category ct on (p.CategoryId = ct.Id)
where c.Name = 'Serhii'