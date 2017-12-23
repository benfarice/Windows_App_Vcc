update langues set langue = '' ,Niveau='' where ID_langue = 0
go
insert into diplome(ID_candidat,Niveau,Etablissement,date_obtention)
values(1,'','','','')
go
insert into langues(ID_candidat,langue,Niveau)
values(1,'','')