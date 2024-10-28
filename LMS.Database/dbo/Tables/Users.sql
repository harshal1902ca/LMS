CREATE TABLE [dbo].[Users] (
    [UserId]        BIGINT        IDENTITY (1, 1) NOT NULL,
    [Email]         VARCHAR (100) NULL,
    [FirstName]     VARCHAR (100) NOT NULL,
    [LastName]      VARCHAR (100) NULL,
    [MobileNo]      VARCHAR (100) NULL,    
    [Password]      VARCHAR (255) NULL,
    [Salt]          VARCHAR (255) NULL,
    [IsAdmin]       BIT           CONSTRAINT [DF_Users_IsAdmin] DEFAULT ((0)) NOT NULL,
    [IsActive]      BIT           CONSTRAINT [DF_Users_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedDate]   DATETIME      CONSTRAINT [DF_Users_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [CreatedBy]     VARCHAR(50)        CONSTRAINT [DF_Users_CreatedBy] DEFAULT ((1)) NOT NULL,
    [UpdatedDate]   DATETIME      CONSTRAINT [DF_Users_UpdatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]     VARCHAR(50)        CONSTRAINT [DF_Users_UpdatedBy] DEFAULT ((1)) NOT NULL,
    [IsDeleted]     BIT           CONSTRAINT [DF_Users_IsDeleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


