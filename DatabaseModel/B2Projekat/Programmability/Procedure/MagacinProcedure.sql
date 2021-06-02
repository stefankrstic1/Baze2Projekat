CREATE PROCEDURE [dbo].[ProcedureMagacin]
	@id int,
	@kapacitet int,
	@stanje varchar(50)
AS
BEGIN
	INSERT [dbo].[Magacins](ID,Kapacitet,Stanje)
	values (@id, @kapacitet, @stanje)
END
