USE Bank_Library;
GO

ALTER TABLE dbo.Accounts
	ADD LastName2 VARCHAR(25) NULL,
		FirstName2 VARCHAR(25) NULL;
