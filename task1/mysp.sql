ALTER proc crud 
@choice varchar(100)
AS
BEGIN
	if @choice = 'INSERT'
	begin
		print 'ins'
	end

	if @choice = 'DELETE'
	begin
	print 'dlt'
	end

	if @choice = 'UPDATE'
	begin
	print 'upd'
	end

END