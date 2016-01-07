
    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF8F14CCF1F819813]') AND parent_object_id = OBJECT_ID('accounts'))
alter table accounts  drop constraint FKF8F14CCF1F819813


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK58803956B194A467]') AND parent_object_id = OBJECT_ID('GroupToAccount'))
alter table GroupToAccount  drop constraint FK58803956B194A467


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK588039562D71B1AD]') AND parent_object_id = OBJECT_ID('GroupToAccount'))
alter table GroupToAccount  drop constraint FK588039562D71B1AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF88E7DA02D71B1AD]') AND parent_object_id = OBJECT_ID('GroupToAdmins'))
alter table GroupToAdmins  drop constraint FKF88E7DA02D71B1AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKF88E7DA0B194A467]') AND parent_object_id = OBJECT_ID('GroupToAdmins'))
alter table GroupToAdmins  drop constraint FKF88E7DA0B194A467


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK48884D412D71B1AD]') AND parent_object_id = OBJECT_ID('GroupToMembers'))
alter table GroupToMembers  drop constraint FK48884D412D71B1AD


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK48884D41B194A467]') AND parent_object_id = OBJECT_ID('GroupToMembers'))
alter table GroupToMembers  drop constraint FK48884D41B194A467


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FKD7F07FD581F50FA]') AND parent_object_id = OBJECT_ID('helpSources'))
alter table helpSources  drop constraint FKD7F07FD581F50FA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK53D0E02281F50FA]') AND parent_object_id = OBJECT_ID('tutorials'))
alter table tutorials  drop constraint FK53D0E02281F50FA


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK1E76E877E42E26F]') AND parent_object_id = OBJECT_ID('userExperiences'))
alter table userExperiences  drop constraint FK1E76E877E42E26F


    if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[FK2C1C7C052D71B1AD]') AND parent_object_id = OBJECT_ID('users'))
alter table users  drop constraint FK2C1C7C052D71B1AD


    if exists (select * from dbo.sysobjects where id = object_id(N'accounts') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table accounts

    if exists (select * from dbo.sysobjects where id = object_id(N'GroupToAccount') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GroupToAccount

    if exists (select * from dbo.sysobjects where id = object_id(N'exercices') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table exercices

    if exists (select * from dbo.sysobjects where id = object_id(N'exerciceSources') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table exerciceSources

    if exists (select * from dbo.sysobjects where id = object_id(N'groups') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table groups

    if exists (select * from dbo.sysobjects where id = object_id(N'GroupToAdmins') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GroupToAdmins

    if exists (select * from dbo.sysobjects where id = object_id(N'GroupToMembers') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table GroupToMembers

    if exists (select * from dbo.sysobjects where id = object_id(N'helpSources') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table helpSources

    if exists (select * from dbo.sysobjects where id = object_id(N'tutorials') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table tutorials

    if exists (select * from dbo.sysobjects where id = object_id(N'tutorialSources') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table tutorialSources

    if exists (select * from dbo.sysobjects where id = object_id(N'userExperiences') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table userExperiences

    if exists (select * from dbo.sysobjects where id = object_id(N'users') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table users

    create table accounts (
        Id INT not null,
       Pseudo NVARCHAR(255) null,
       Email NVARCHAR(255) null,
       IsOwner BIT null,
       Password NVARCHAR(255) null,
       EntityState INT null,
       User_id INT null unique,
       primary key (Id)
    )

    create table GroupToAccount (
        Account_id INT not null,
       Group_id INT not null
    )

    create table exercices (
        Id INT not null,
       Position INT null,
       Title NVARCHAR(255) null,
       primary key (Id)
    )

    create table exerciceSources (
        Id INT not null,
       Content NVARCHAR(255) null,
       Type NVARCHAR(255) null,
       primary key (Id)
    )

    create table groups (
        Id INT not null,
       Name NVARCHAR(255) null,
       primary key (Id)
    )

    create table GroupToAdmins (
        Group_id INT not null,
       Account_id INT not null
    )

    create table GroupToMembers (
        Group_id INT not null,
       Account_id INT not null
    )

    create table helpSources (
        Id INT not null,
       Content NVARCHAR(255) null,
       Type NVARCHAR(255) null,
       Exercice_id INT null,
       primary key (Id)
    )

    create table tutorials (
        Id INT not null,
       Title NVARCHAR(255) null,
       Exercice_id INT null,
       primary key (Id)
    )

    create table tutorialSources (
        Id INT not null,
       Content NVARCHAR(255) null,
       Type NVARCHAR(255) null,
       primary key (Id)
    )

    create table userExperiences (
        Id INT not null,
       Code NVARCHAR(255) null,
       CreationDate DATETIME null,
       Creator_id INT null,
       primary key (Id)
    )

    create table users (
        Id INT not null,
       FirstName NVARCHAR(255) null,
       Name NVARCHAR(255) null,
       Account_id INT null,
       primary key (Id)
    )

    alter table accounts 
        add constraint FKF8F14CCF1F819813 
        foreign key (User_id) 
        references users

    alter table GroupToAccount 
        add constraint FK58803956B194A467 
        foreign key (Group_id) 
        references groups

    alter table GroupToAccount 
        add constraint FK588039562D71B1AD 
        foreign key (Account_id) 
        references accounts

    alter table GroupToAdmins 
        add constraint FKF88E7DA02D71B1AD 
        foreign key (Account_id) 
        references accounts

    alter table GroupToAdmins 
        add constraint FKF88E7DA0B194A467 
        foreign key (Group_id) 
        references groups

    alter table GroupToMembers 
        add constraint FK48884D412D71B1AD 
        foreign key (Account_id) 
        references accounts

    alter table GroupToMembers 
        add constraint FK48884D41B194A467 
        foreign key (Group_id) 
        references groups

    alter table helpSources 
        add constraint FKD7F07FD581F50FA 
        foreign key (Exercice_id) 
        references exercices

    alter table tutorials 
        add constraint FK53D0E02281F50FA 
        foreign key (Exercice_id) 
        references exercices

    alter table userExperiences 
        add constraint FK1E76E877E42E26F 
        foreign key (Creator_id) 
        references accounts

    alter table users 
        add constraint FK2C1C7C052D71B1AD 
        foreign key (Account_id) 
        references accounts (User_id)
