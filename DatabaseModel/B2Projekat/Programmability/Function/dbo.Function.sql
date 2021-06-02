create function FunctionGetValues
(
	@RadnikId int
)
returns int
begin
	declare @num as int;
	set @num = (select BrzinaRada from [dbo].[Masinas] a inner join [dbo].[Radniks_UProizvodnji] rup on a.IDMasina= rup.MasinaIDMasina
	where rup.MBR = @RadnikId);
	RETURN @num;
end
