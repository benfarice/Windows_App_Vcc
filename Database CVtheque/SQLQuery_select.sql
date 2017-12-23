select c.CIN,c.Genre,c.DateNaissance,c.Nom,c.Prenom,c.vcc
,c.Ville,c.Quartier,c.Email,c.CV from Candidat c ,diplome d ,emploi_metier m
where 
d.ID_candidat = c.ID and m.ID_candidat = c.ID
and
DATEDIFF(year,c.DateNaissance,getdate()) between 20 and 24
and
c.Ville = 'casablanca'
and
d.specialite = 'developement'
and 
c.Genre = 'True'
and 
c.Quartier = 'oulfa'
and
m.emploi_metier = 'designer'
