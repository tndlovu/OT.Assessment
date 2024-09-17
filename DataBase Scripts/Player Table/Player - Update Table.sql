USE [OT_Assessment_DB]
GO

UPDATE [dbo].[Player]
   SET [AccountId] = <AccountId, uniqueidentifier,>
      ,[Username] = <Username, nchar(10),>
 WHERE <Search Conditions,,>
GO

