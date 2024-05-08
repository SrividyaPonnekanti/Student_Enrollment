IF EXISTS(SELECT TOP 1 1 FROM sys.procedures WHERE name='SP_GetStudentById' AND type='P')
DROP PROCEDURE SP_GetStudentById
GO 
CREATE PROC SP_GetStudentById (@Sudentid bigint)
AS BEGIN
SELECT * FROM TSTUDENTS WHERE studentid=@Sudentid
END
GO


