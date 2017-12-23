select ID_diplome from diplome where ID_candidat = 1
go
select d.Niveau,d.date_obtention,d.specialite
,d.Etablissement from diplome d where d.ID_diplome = 1