USE Bank_Library;
GO

SET IDENTITY_INSERT dbo.Customers ON;
GO
INSERT INTO dbo.Customers (CustomerID, LastName, FirstName)
VALUES
	(1, 'Bobson', 'Steven'),
	(2, 'Stevenson', 'Bob'),
	(3, 'Janus', 'Janice'),
	(4, 'Linguini', 'Kelly'),
	(5, 'McName', 'Fake');
GO
SET IDENTITY_INSERT dbo.Customers OFF;
GO


SET IDENTITY_INSERT dbo.Accounts ON;
GO
INSERT INTO dbo.Accounts (AccountID, CustomerID, AccountType, AccountNum, PIN, Balance, LastName2, FirstName2)
VALUES
	(1, 1, 'Savings', 0118, 1234, 10234, NULL, NULL),
	(2, 1, 'Checking', 999, 1234, 1030, NULL, NULL),
	(3, 2, 'Checking', 881, 1234, 306, 'Stevenson', 'Bobette'),
	(4, 3, 'Savings', 99, 1234, 549235, 'Janus', 'Manice'),
	(5, 4, 'Checking', 911, 1234, 16002, NULL, NULL),
	(6, 4, 'Savings', 9, 1234, 55555555, NULL, NULL),
	(7, 5, 'Savings', 725, 1234, 13, 'McName', 'Fakest'),
	(8, 5, 'Checking', 3, 1234, 5, NULL, NULL);
GO
SET IDENTITY_INSERT dbo.Accounts OFF;
GO


SET IDENTITY_INSERT dbo.Transactions ON;
GO
INSERT INTO dbo.Transactions (TransactionID, AccountID, TransactionTime)
VALUES
	(1, 1, '12-01-16 01:29'),
	(2, 1, '12-05-16 01:38'),
	(3, 1, '01-01-17 12:29'),
	(4, 2, '09-01-16 01:32'),
	(5, 2, '11-11-16 05:29'),
	(6, 3, '10-01-17 01:29'),
	(7, 4, '12-02-16 01:29'),
	(8, 5, '11-01-16 02:29'),
	(9, 5, '01-01-17 01:29'),
	(10, 6, '10-01-16 02:29'),
	(11, 7, '10-01-17 01:29'),
	(12, 8, '11-01-16 11:11'),
	(13, 8, '12-01-16 21:29');
GO
SET IDENTITY_INSERT dbo.Transactions OFF;
GO


SET IDENTITY_INSERT dbo.Deposits ON;
GO
INSERT INTO dbo.Deposits (DepositID, TransactionID, Amount)
VALUES
	(1, 1, 135),
	(2, 4, 5),
	(3, 5, 95),
	(4, 8, 16),
	(5, 9, 5455),
	(6, 11, 1345),
	(7, 13, 555);
GO
SET IDENTITY_INSERT dbo.Deposits OFF;
GO


SET IDENTITY_INSERT dbo.Withdrawals ON;
GO
INSERT INTO dbo.Withdrawals (WithdrawalID, TransactionID, Amount)
VALUES
	(1, 2, 13),
	(2, 3, 55),
	(3, 5, 2),
	(4, 6, 10),
	(5, 7, 58),
	(6, 10, 15),
	(7, 12, 58);
GO
SET IDENTITY_INSERT dbo.Withdrawals OFF;
GO