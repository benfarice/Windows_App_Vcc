delete from Candidat where ID = 10
go
create trigger for_delete
on candidat
instead of delete
as
begin
declare @id  int
select @id = ID from deleted
delete from Atelier where ID_candidat = @id
delete from baccalaureat where ID_candidat = @id
delete from diplome where ID_candidat = @id
delete from emploi_metier where ID_candidat = @id
delete from experience where ID_candidat = @id
delete from langues where ID_candidat = @id
delete from niveau_Bac where ID_candidat = @id
delete from sourcing where ID_candidat = @id
delete from Telephone where ID_candidat = @id
delete from Candidat where ID = @id
end
