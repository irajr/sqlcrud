--CRUD FOR CUSTOMER
ALTER PROC GenCrud
	@CHOICE VARCHAR(10),
	@CID INT,
	@CNAME VARCHAR(50) = null,
	@CEMAIL VARCHAR(50) = null,
	@CADDRESS VARCHAR(MAX) = null,
	@CCITY VARCHAR(20) =null,
	@CSTATE VARCHAR(30)= null, 
	@CGENDER VARCHAR(9) = null,
	@CRECORD DATE = null
AS
BEGIN
--INSERT
	IF @CHOICE = 'INSERT'
	BEGIN
		INSERT INTO gencustomers VALUES (@CID,@CNAME,@CEMAIL,@CADDRESS,@CCITY,@CSTATE,@CGENDER,@CRECORD)
	END
----UPDATE
	IF @CHOICE = 'UPDATE'
	BEGIN
		UPDATE gencustomers SET Cname = @CNAME, @CEMAIL = @CEMAIL, Caddress = @CADDRESS,Ccity = @CCITY, Cstate = @CSTATE, Cgender = @CGENDER, Crecord = @CRECORD WHERE Cid = @CID  
	END
----DELETE
	IF @CHOICE = 'DELETE'
	BEGIN
		DELETE FROM gencustomers WHERE Cid = @CID
	END
END
GO
