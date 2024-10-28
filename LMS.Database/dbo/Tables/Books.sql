CREATE TABLE [dbo].[Books] (
    [BookId]        INT        IDENTITY (1, 1) NOT NULL,
    [BookTitle]         VARCHAR (100) NULL,
    [BookCategory]     VARCHAR (100) NOT NULL,
    [BookAuthor]      VARCHAR (100) NULL,
    [Status]        VARCHAR (100) NULL,
    [BookCopies]    int DEFAULT ((1)) NOT NULL,
    [DateAdded]          DATETIME NULL,
    [IsAdmin]       BIT           CONSTRAINT [DF_Books_IsAdmin] DEFAULT ((0)) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_Books_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedDate]   DATETIME      CONSTRAINT [DF_Books_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     VARCHAR(50)        CONSTRAINT [DF_Books_CreatedBy] DEFAULT ((1)) NOT NULL,
    [UpdatedDate]   DATETIME      CONSTRAINT [DF_Books_UpdatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]     VARCHAR(50)        CONSTRAINT [DF_Books_UpdatedBy] DEFAULT ((1)) NOT NULL,
    [IsDeleted]     BIT           CONSTRAINT [DF_Books_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookId] ASC)
);


