-- Create a new table called '[Players_PersonalInfo]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Players_PersonalInfo]', 'U') IS NOT NULL
DROP TABLE [dbo].[Players_PersonalInfo]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Players_PersonalInfo]
(
    [Uniform_Number] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(20) NOT NULL,
    [Surname] NVARCHAR(20) NOT NULL,
    [Age] INT NOT NULL,
    [Height_metre] FLOAT NOT NULL,
    [Country] NVARCHAR(20) NOT NULL
    -- Specify more columns here
);
GO

-- Create a new table called '[Players_Position]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Players_Position]', 'U') IS NOT NULL
DROP TABLE [dbo].[Players_Position]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Players_Position]
(
    [Uniform_Number] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(20) NOT NULL,
    [Surname] NVARCHAR(20) NOT NULL,
    [Position] NVARCHAR(20) NOT NULL,
    [Foot] NVARCHAR(20) NOT NULL
    -- Specify more columns here
);
GO

-- Create a new table called '[Players_Value]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Players_Value]', 'U') IS NOT NULL
DROP TABLE [dbo].[Players_Value]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Players_Value]
(
    [Uniform_Number] INT NOT NULL PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(20) NOT NULL,
    [Surname] NVARCHAR(20) NOT NULL,
    [Current_Team] NVARCHAR(20) NOT NULL,
    [Value_$] INT NOT NULL
    -- Specify more columns here
);
GO