USE Bank_Library;
GO

-- WITHDRAWALS TABLE
CREATE TABLE dbo.Withdrawals (
	WithdrawalID INT IDENTITY (1,1) NOT NULL,
	Amount INT NULL,
	TransactionID INT NOT NULL,
	CONSTRAINT [PK_dbo.Withdrawals] PRIMARY KEY CLUSTERED ([WithdrawalID] ASC),
	CONSTRAINT [FK_dbo.Withdrawals_dbo.Transactions_TransactionID] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE
	);
GO

CREATE NONCLUSTERED INDEX [IX_TransactionID]
    ON [dbo].[Withdrawals]([TransactionID] ASC);
GO

-- DEPOSITS TABLE
CREATE TABLE dbo.Deposits (
	DepositID INT IDENTITY (1,1) NOT NULL,
	Amount INT NULL,
	TransactionID INT NOT NULL,
	CONSTRAINT [PK_dbo.Deposits] PRIMARY KEY CLUSTERED ([DepositID] ASC),
	CONSTRAINT [FK_dbo.Deposits_dbo.Transactions_TransactionID] FOREIGN KEY ([TransactionID]) REFERENCES [dbo].[Transactions] ([TransactionID]) ON DELETE CASCADE
	);
GO

CREATE NONCLUSTERED INDEX [IX_TransactionID]
    ON [dbo].[Deposits]([TransactionID] ASC);
GO
