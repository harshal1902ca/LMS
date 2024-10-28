TRUNCATE TABLE [dbo].[Users] 
GO 

SET IDENTITY_INSERT [dbo].[Users] ON 
INSERT INTO dbo.Users (UserId, Email, FirstName, LastName, MobileNo, Password, Salt, IsAdmin, IsActive, CreatedDate, CreatedBy, UpdatedDate, UpdatedBy, IsDeleted)
VALUES 
(1, 'john.doe@example.com', 'John', 'Doe', '(555) 123-4567', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 0, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(2, 'jane.smith@example.com', 'Jane', 'Smith', '(555) 234-5678', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 1, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(3, 'alice.johnson@example.com', 'Alice', 'Johnson', '(555) 345-6789', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 0, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(4, 'bob.brown@example.com', 'Bob', 'Brown', '(555) 456-7890', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 1, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(5, 'charlie.wilson@example.com', 'Charlie', 'Wilson', '(555) 567-8901', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 0, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(6, 'diana.white@example.com', 'Diana', 'White', '(555) 678-9012', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 1, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(7, 'eve.davis@example.com', 'Eve', 'Davis', '(555) 789-0123', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 0, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(8, 'frank.martin@example.com', 'Frank', 'Martin', '(555) 890-1234', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 1, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(9, 'grace.lee@example.com', 'Grace', 'Lee', '(555) 901-2345', 'JCI0m5hPVwmAAQ6Mbz2DH/PiO8XZw332zs1keCY6wlo=', 'salt1', 0, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0),
(10, 'henry.clark@example.com', 'Henry', 'Clark', '(555) 012-3456', 'Password123', 'salt1', 1, 1, GETDATE(), 'Admin', GETDATE(), 'Admin', 0);

SET IDENTITY_INSERT [dbo].[Users] OFF
GO
--For Alluser password is: Password123