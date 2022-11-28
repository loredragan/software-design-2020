USE [Assignment1]
GO

INSERT INTO [dbo].[clientsaccounts]
           ([type]
           ,[amount]
           ,[creation_date]
           ,[clientID])
     VALUES
           ('ron'
           ,566.5
           ,'2020-03-15'
           ,1),
		   ('ron'
           ,566.5
           ,'2020-03-17'
           ,1),
		   ('euro'
           ,566.5
           ,'2020-03-16'
           ,2);
GO


