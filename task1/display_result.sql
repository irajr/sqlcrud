ALTER PROC Display7Result
	@CHOICE VARCHAR(100),
	@CUSTOMERFL VARCHAR(10) = null,
	@CUSTOMERID INT
AS 
BEGIN
	IF @CHOICE = 'Find Customer'
	BEGIN TRY
		SELECT * FROM gencustomers WHERE Cname  LIKE '%' + @CUSTOMERFL  + '%'
	END TRY
	BEGIN CATCH
		PRINT Concat('Error_Message()=' , Error_Message());
	END CATCH

	--IF @CHOICE = 'DATA'
	BEGIN TRY
		SELECT gencustomers.Cname,genorders.OrderNumber from gencustomers INNER JOIN genorders ON(genorders.Oid = gencustomers.Cid)
	END TRY
	BEGIN CATCH
		PRINT Concat('Error_Message()=' , Error_Message());
	END CATCH
END
GO

EXEC Display7Result @CHOICE = 'Find Customer' , @CUSTOMERFL = 'r' 
select * from gencustomers