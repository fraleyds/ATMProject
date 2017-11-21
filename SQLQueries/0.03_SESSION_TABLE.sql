USE Bank_Library
GO

CREATE TABLE dbo.Transactions (
	TransactionID INT IDENTITY (1,1) NOT NULL,
	TransactionTime Datetime NOT NULL,
	AccountID INT NOT NULL,
	CONSTRAINT [PK_dbo.Transactions] PRIMARY KEY CLUSTERED ([TransactionID] ASC),
    CONSTRAINT [FK_dbo.Transactions_dbo.Accounts_AccountID] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Accounts] ([AccountID]) ON DELETE CASCADE
	);
GO

CREATE NONCLUSTERED INDEX [IX_AccountID]
    ON [dbo].[Transactions]([AccountID] ASC);
GO


