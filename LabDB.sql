CREATE DATABASE LabDB;
GO
USE LabDB;
GO

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100)
);

INSERT INTO Customers (Name, Email) VALUES 
('John Doe', 'john.doe@tdtu.com'),
('Jane Smith', 'jane.smith@tdtu.com'),
('Trung Pham', 'trung.pham@tdtu.com');

CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(50) NOT NULL
);
INSERT INTO Users VALUES ('admin', '123456');