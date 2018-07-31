--create table Mediciness (
--	ID INT PRIMARY KEY IDENTITY (1,1),
--	NAME VARCHAR(50),
--	MANUFACTURER VARCHAR(50),
--	PRICE money,
--	AMOUNT INT,
--	WITHPRESCRIPTION BIT,
--);

--create table Prescriptions (
--	ID INT PRIMARY KEY IDENTITY (1,1),
--	CustomerName VARCHAR(50),
--	PESEL INT,
--	PrescriptionNumber INT,	
--);

--CREATE TABLE Orders ( 
--Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
--MedicineID int NOT NULL,
--PrescriptionID int NOT NULL,
--Date DATETIME,
--Amount int,
--);



--ALTER TABLE Orders
--ADD CONSTRAINT FK_Orders_Mediciness 
--FOREIGN KEY (MedicineID)
--REFERENCES Mediciness (ID);

--ALTER TABLE Orders
--ADD CONSTRAINT FK_Orders_Prescriptions 
--FOREIGN KEY (PrescriptionID)
--REFERENCES Prescriptions (ID);

--INSERT INTO [dbo].[Mediciness]
--           ([NAME]
--           ,[MANUFACTURER]
--           ,[PRICE]
--           ,[AMOUNT]
--           ,[WITHPRESCRIPTION])
--     VALUES
--           ('ibuprom','wqerw','6.99','120',0)

--Alter table Mediciness alter column Price Decimal(5,2)
--select WITHPRESCRIPTION from Mediciness where ID = 1;

select * from Mediciness;



