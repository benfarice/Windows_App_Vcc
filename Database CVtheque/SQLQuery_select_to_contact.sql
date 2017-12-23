select  c.CIN,c.Nom,c.Prenom,c.Email,t.Numero from Candidat c  inner join Telephone t on c.ID = t.ID_candidat
where 
ID in( 1,2,3,4,5)