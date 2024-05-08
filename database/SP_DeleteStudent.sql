IF EXISTS(SELECT TOP 1 1 FROM sys.procedures WHERE name='SP_DeleteStudent' AND type='P')
DROP PROCEDURE SP_DeleteStudent
GO 
CREATE PROC SP_DeleteStudent (@StudentId bigint)
AS
BEGIN
UPDATE TSTUDENTS SET RetirementDate=GETDATE() WHERE studentid=@StudentId
END