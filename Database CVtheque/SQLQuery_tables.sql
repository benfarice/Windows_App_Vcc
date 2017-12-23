--////////////////////////////////////////////////////
create table Candidat(
	ID int primary key IDENTITY(1,1),
	Nom varchar(300),
	Prenom varchar(300),
	Genre varchar(100),
	DateNaissance date,
	CV varbinary(max),
	Ville varchar(300),
	Quartier varchar(300),
	CIN varchar(300),
	Email varchar(300) ,
	vcc varchar(100) ,
	

)
--//////////////////////////////////////////////////
create table Telephone(
	ID_tel int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	Numero int ,
	
)
--//////////////////////////////////////////////////
create table sourcing(
	ID_sourcing int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	Entreprise varchar(200),
	poste varchar(100),
	date_soorcing date,
	resultat varchar(100) ,
	check (resultat in('retenu','ajourné','EnCours'))
)
--////////////////////////////////////////////////// 
create table emploi_metier(
	ID_emploi_metier int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	emploi_metier varchar(200)
)

--//////////////////////////////////////////////////////
create table langues(
	ID_langue int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	langue varchar(300) ,
	Niveau varchar(300)
)
--/////////////////////////////////////////////////////////
create table baccalaureat(
	ID_bac int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	annee_obtention int,
	Type_ varchar(300),
	constraint annee_obtention_constraint check(annee_obtention <= year(getdate()))
)
--/////////////////////////////////////////////////////////
create table niveau_Bac(
	ID_niveau_Bac int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	Type_ varchar(300),
	Niveau varchar(300)
)
--//////////////////////////////////////////////////////////
create table diplome(
	ID_diplome int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	date_obtention int ,
	Niveau varchar(300),
	specialite varchar(300),
	Etablissement varchar(300),
	--constraint Niveau_constraint check(Niveau in ('Licence','Master','Technicien spécialisé','Technicien','Formation Qualifiante','Qualification','Spécialisation')),
	constraint date_obtention_constraint check(date_obtention <= year(getdate()))
)
--////////////////////////////////////////////////////////////
create table experience(
	ID_experience int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	DateDebut date,
	DateFin date,
	Encours int,
	Poste varchar(300),
	Service_ varchar(300),
	entreprise varchar(300),
	secteur_activite varchar(300),
	ville varchar(300),
	type_ varchar(300) 
	--check(type_ in('Benévole','Auto-Emploi','Stage','Emploi','CDI','CDD'))
	
)
--////////////////////////////////////////////////////////////
create table Atelier(
	ID_Atelier int primary key IDENTITY(1,1),
	ID_candidat int foreign key references Candidat(ID),
	Date_Debut_atelier date null,
	Date_Fin_atelier date null,
	theme varchar(300) not null,
	observation varchar(1000) null
	
)
--//////////////////////////////////////////////////////////////

--/////////////////////////////////////////////////////////////////

--/////////////////////////////////////////////////////////////////