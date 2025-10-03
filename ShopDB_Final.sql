
CREATE DATABASE ShopDB_Final;
GO
USE ShopDB_Final;
GO

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);

CREATE TABLE Categories (
    CategoryId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    ImagePath NVARCHAR(255)
);

-- Seed dữ liệu
INSERT INTO Users (Username, PasswordHash, Role) VALUES 
('admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Admin'),
('user1', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Member'); -- 123456

INSERT INTO Categories (Name) VALUES ('Giày'),('Áo'),('Laptop'),('Điện thoại'),('Phụ kiện');

INSERT INTO Products (CategoryId, Name, Price, ImagePath) VALUES
(1, 'Giày Sneaker Trắng', 1200000, '/images/products/shoes1.jpg'),
(1, 'Giày Nike Air', 2500000, '/images/products/shoes2.jpg'),
(2, 'Áo Thun Nam', 250000, '/images/products/shirt1.jpg'),
(2, 'Áo Khoác Hoodie', 500000, '/images/products/shirt2.jpg'),
(3, 'Laptop Dell Inspiron', 15000000, '/images/products/laptop1.jpg'),
(3, 'Laptop Asus Gaming', 22000000, '/images/products/laptop2.jpg'),
(4, 'iPhone 14 Pro', 25000000, '/images/products/phone1.jpg'),
(4, 'Samsung Galaxy S23', 20000000, '/images/products/phone2.jpg'),
(5, 'Tai Nghe Bluetooth', 1200000, '/images/products/accessory1.jpg'),
(5, 'Balo Laptop', 800000, '/images/products/accessory2.jpg');
