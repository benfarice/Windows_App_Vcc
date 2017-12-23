create function getID(@nom varchar(1000),@prenom varchar(1000),@naissance date)
returns int
as
begin
declare @x int
select @x = ID from Candidat 
where Nom=@nom and Prenom = @prenom and DateNaissance = @naissance
return @x
end