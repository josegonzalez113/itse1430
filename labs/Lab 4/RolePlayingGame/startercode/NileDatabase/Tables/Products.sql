CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(100) NOT NULL,
    [Profession] NVARCHAR(50) NOT NULL,
    [Race] NVARCHAR(50) NOT NULL, 
    [Attribute] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [CK_Products_NameSet] CHECK (LEN(Name) > 0), 
    CONSTRAINT [AK_Products_Name] UNIQUE ([Name]), 
    CONSTRAINT [CK_Products_Profession] CHECK ((Profession) > 0), 
    CONSTRAINT [CK_Products_Race] CHECK ((Race) > 0), 
    CONSTRAINT [CK_Products_Description] CHECK ((Description) > 0) 
)
