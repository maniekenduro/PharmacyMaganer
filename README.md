# PharmacyManager

This little console program can be used for manage simly pharmacy shop. Functions:

- SellModule - adding medicines (from database) to bill, summary bill, confirming bill, update database by reduce some reduce medicine,
  adding presciption to database, adding confirmed order to order database,
- EditModule - adding new medicines to database, editing quantity, showing list of medicines from database
- Showlist - view of medicines list, orders list and prescriptions list.

This program require connection with database:
1. Create sql serwer with database Pharmacy,
2. Execute this commands
          create table Mediciness (
          ID INT PRIMARY KEY IDENTITY (1,1),
          NAME VARCHAR(50),
          MANUFACTURER VARCHAR(50),
          PRICE money,
          AMOUNT INT,
          WITHPRESCRIPTION BIT,
          );

          create table Prescriptions (
          ID INT PRIMARY KEY IDENTITY (1,1),
          CustomerName VARCHAR(50),
          PESEL INT,
          PrescriptionNumber INT,	
          );

          CREATE TABLE Orders ( 
          Id int NOT NULL IDENTITY (1,1) PRIMARY KEY,
          MedicineID int NOT NULL,
          PrescriptionID int NOT NULL,
          Date DATETIME,
          Amount int,
          );

          ALTER TABLE Orders
          ADD CONSTRAINT FK_Orders_Mediciness 
          FOREIGN KEY (MedicineID)
          REFERENCES Mediciness (ID);

3. Add few medicines by command (example):

          INSERT INTO [dbo].[Mediciness]
                     ([NAME]
                     ,[MANUFACTURER]
                     ,[PRICE]
                     ,[AMOUNT]
                     ,[WITHPRESCRIPTION])
               VALUES
                     ('Ibuprom','Polopharm','6.99','120',0)
                     
4. Enjoy:)
