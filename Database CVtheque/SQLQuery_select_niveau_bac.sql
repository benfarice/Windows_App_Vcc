select n.Type_,n.Niveau from niveau_Bac n where n.ID_niveau_Bac = 1
go
select t.ID_tel from Telephone t where t.ID_candidat = 1
go
select t.Numero from Telephone t where t.ID_tel = 1
go
select m.ID_emploi_metier from emploi_metier m where m.ID_candidat = 1
go
select m.emploi_metier from emploi_metier m where m.ID_emploi_metier = 1
go
select x.ID_experience from experience x where x.ID_candidat = 1
go
select x.DateDebut,x.DateFin,x.Encours,x.entreprise,x.Poste,
x.secteur_activite,x.Service_,x.type_,x.ville
 from experience x where x.ID_experience = 1
 go
 select t.ID_Atelier from Atelier t where t.ID_candidat = 1
 go
 select t.Date_Debut_atelier
 ,t.Date_Fin_atelier,t.observation,t.theme from Atelier t where t.ID_Atelier = 1
 go
 select l.ID_langue from langues l where l.ID_candidat = 1
 go
 select l.langue,l.Niveau from langues l where l.ID_langue =1