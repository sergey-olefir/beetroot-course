create table Category (
Id int primary key identity (1, 1) not null,
Title varchar(30))

create table Products (
Id int primary key identity (1, 1) not null,
CategoryId int foreign key (CategoryId) references Category(Id) not null,
Title varchar(30) not null,
Price real not null)

create table Customer (
Id int primary key identity (1, 1) not null,
Name varchar(30) not null)

create table Orders (
Id int primary key identity (1, 1) not null,
CustomerId int foreign key references Customer(Id) not null,
DeliveryMethod varchar(30))


create table OrderItems (
Id int primary key identity (1, 1) not null,
OrderId int foreign key (OrderId) references Orders(Id),
ProductId int foreign key references Products(Id) not null,
Count int not null);