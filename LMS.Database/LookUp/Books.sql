TRUNCATE TABLE [dbo].[Books]
GO


SET IDENTITY_INSERT [dbo].[Books] ON 
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (2, N'The Great Gatsby', N'Fiction', N'F. Scott Fitzgerald', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (3, N'1984as', N'Action', N'George Orwell', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-28T02:16:39.800' AS DateTime), N'John', 1, 3)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (4, N'To Kill a Mockingbird 1', N'Fiction', N'Harper Lee', N'Old', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-28T00:33:43.070' AS DateTime), N'John', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (5, N'The Catcher in the Rye', N'Fiction', N'J.D. Salinger', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (6, N'The Hobbit', N'Romance', N'J.R.R. Tolkien', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (7, N'Moby Dick', N'Adventure', N'Herman Melville', N'Old', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (8, N'Pride and Prejudice', N'Romance', N'Jane Austen', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (9, N'The Lord of the Rings', N'Fantasy', N'J.R.R. Tolkien', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', 0, 5)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (10, N'Brave New World', N'Dystopian', N'Aldous Huxley', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-28T02:46:35.593' AS DateTime), N'John', 0, 2)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (11, N'Fahrenheit 451', N'Dystopian', N'Ray Bradbury', N'New', CAST(N'2024-10-27T21:35:16.680' AS DateTime), 0, 1, CAST(N'2024-10-27T21:35:16.680' AS DateTime), N'Admin', CAST(N'2024-10-28T03:03:00.423' AS DateTime), N'John', 0, 4)
GO
INSERT [dbo].[Books] ([BookId], [BookTitle], [BookCategory], [BookAuthor], [Status], [DateAdded], [IsAdmin], [IsActive], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted], [BookCopies]) VALUES (17, N'Ramayana', N'Fiction', N'Valmiki', N'New', CAST(N'2024-10-16T00:30:00.000' AS DateTime), 0, 1, CAST(N'2024-10-28T00:30:48.450' AS DateTime), N'John', CAST(N'2024-10-28T00:30:48.450' AS DateTime), N'John', 0, 5)
GO
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
