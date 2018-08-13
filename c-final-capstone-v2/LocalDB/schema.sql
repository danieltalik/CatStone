-- script to create tables and static data for tables
-- should be place in this file

DROP DATABASE [CatStone]
GO
CREATE DATABASE [CatStone]

CREATE TABLE [dbo].[Cats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(50) NULL, 
    [color] VARCHAR(50) NOT NULL, 
    [hair_length] VARBINARY(50) NULL, 
    [age] INT NULL, 
    [prior_exp] VARCHAR(250) NULL, 
    [skills] NCHAR(10) NULL, 
    [photo] VARBINARY(MAX) NULL, 
    [is_featured] BIT NOT NULL 
)
