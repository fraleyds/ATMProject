USE Bank_Library
GO

DROP TABLE Customers;
GO
DROP TABLE Accounts;
GO

CREATE TABLE dbo.Customers (
	CustomerID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	FirstName VARCHAR(25) NOT NULL,
	LastName VARCHAR(25) NOT NULL
	);
GO

CREATE TABLE dbo.Accounts (
	AccountID INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	CustomerID INT NOT NULL,
	AccountNum INT NOT NULL,
	AccountType VARCHAR(25) NOT NULL,
	PIN INT NOT NULL,
	Balance INT NULL,
	CONSTRAINT [FK_dbo.Accounts_dbo.Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([CustomerID]) ON DELETE CASCADE
	);
GO

CREATE NONCLUSTERED INDEX [IX_CustomerID]
    ON [dbo].[Accounts]([CustomerID] ASC);
GO
