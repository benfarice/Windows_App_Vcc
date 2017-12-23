create table application_users(
username varchar(50) primary key,
pass_word varchar(50)
) 
go
insert into application_users(username,pass_word)
values('Admin','abc123')
go
select * from application_users
go
--drop table application_users
select COUNT(*) from application_users
where username = 'Admin' and pass_word = 'ab0c123'
