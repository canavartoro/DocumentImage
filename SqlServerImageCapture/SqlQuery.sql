SELECT * FROM dbo.Weigh2 WITH (NOLOCK) 


ALTER DATABASE WINTR SET TRUSTWORTHY ON;

DROP TRIGGER tr_Weight

DROP PROC sp_CaptureImage


DROP ASSEMBLY  [SqlCaptureImage]
 

 SELECT * FROM sys.assemblies

 SELECT * FROM sys.assembly_files

 SELECT * FROM sys.assembly_modules

 SELECT * FROM sys.assembly_references

 SELECT * FROM sys.module_assembly_usages


CREATE ASSEMBLY [SqlCaptureImage]
AUTHORIZATION dbo
FROM 'D:\Projeler\Calismalar\Semih\DocumentImageCapture\SqlServerImageCapture\bin\Debug\SqlServerImageCapture.dll'
WITH PERMISSION_SET = UNSAFE --{ SAFE | EXTERNAL_ACCESS | UNSAFE }
GO


CREATE PROCEDURE  sp_CaptureImage      
(      
    @RowId BIGINT,      
    @Description NVARCHAR(1024),
	@HostName NVARCHAR(100),
	@Port INTEGER 
)      
AS EXTERNAL NAME SqlCaptureImage.TcpCaptureClient.CaptureImage;      
GO



sp_CaptureImage 3, N'Deneme'

ALTER DATABASE ors_test SET TRUSTWORTHY ON

EXEC sp_changedbowner  N'sa'

GO
ALTER DATABASE [ors_test] SET TRUSTWORTHY ON WITH ROLLBACK IMMEDIATE
GO
USE [ors_test]
GO
ALTER DATABASE [ors_test] SET TRUSTWORTHY ON
GO
exec sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
exec sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

CREATE ASSEMBLY [System.Drawing]
AUTHORIZATION [dbo]
FROM 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Drawing.dll'
WITH PERMISSION_SET = UNSAFE
GO


CREATE TRIGGER tr_Weight
ON dbo.Weigh2
AFTER INSERT
AS BEGIN
DECLARE @Id BIGINT
	BEGIN TRY
		SELECT TOP 1 @Id = Inserted.seq FROM Inserted WITH (NOLOCK) 
		EXECUTE sp_CaptureImage @Id,'TEST','127.0.0.1',8888
	END TRY
	BEGIN CATCH
		COMMIT
		DECLARE @ErrorMessage NVARCHAR(MAX)
		SET @ErrorMessage = ERROR_MESSAGE()
		EXEC xp_logevent 60000, @ErrorMessage, WARNING
		PRINT @ErrorMessage
	END CATCH
END

INSERT INTO dbo.Weigh2 (WeighTime1) VALUES (GETDATE()) 

SELECT seq,WeighTime1,[Desc] FROM dbo.Weigh2 WITH (NOLOCK) FOR XML PATH('irsaliye'), ROOT('Irsaliyeler')
 



