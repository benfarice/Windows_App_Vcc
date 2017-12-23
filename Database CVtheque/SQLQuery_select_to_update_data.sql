select c.CIN,c.Genre,c.Nom,c.Prenom,
c.DateNaissance,c.Ville,c.Quartier,c.Email,c.vcc from Candidat c 
where c.ID = 1 
go
select c.ID from Candidat c 
where c.ID > -1 
and c.CIN = '' and c.Nom='' and c.Prenom = '' and c.Email=''