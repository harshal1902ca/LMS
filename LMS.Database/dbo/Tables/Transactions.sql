CREATE TABLE [dbo].[Transactions] (
    [TransactionId]        INT        IDENTITY (1, 1) NOT NULL,
    [BookId]         INT NULL,
    [TransactionStatus]     VARCHAR (100) NOT NULL,
    [TransactionDate]      DATETIME NULL,    
    [UserId]      INT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_Transactions_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedDate]   DATETIME      CONSTRAINT [DF_Transactions_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     VARCHAR(50)        CONSTRAINT [DF_Transactions_CreatedBy] DEFAULT ((1)) NOT NULL,
    [UpdatedDate]   DATETIME      CONSTRAINT [DF_Transactions_UpdatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]     VARCHAR(50)        CONSTRAINT [DF_Transactions_UpdatedBy] DEFAULT ((1)) NOT NULL,
    [IsDeleted]     BIT           CONSTRAINT [DF_Transactions_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([TransactionId] ASC)
);


