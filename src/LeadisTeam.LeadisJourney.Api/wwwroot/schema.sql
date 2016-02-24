
    
alter table accounts  drop foreign key FKF8F14CCF1F819813


    
alter table GroupToAccount  drop foreign key FK58803956B194A467


    
alter table GroupToAccount  drop foreign key FK588039562D71B1AD


    
alter table GroupToAdmins  drop foreign key FKF88E7DA02D71B1AD


    
alter table GroupToAdmins  drop foreign key FKF88E7DA0B194A467


    
alter table GroupToMembers  drop foreign key FK48884D412D71B1AD


    
alter table GroupToMembers  drop foreign key FK48884D41B194A467


    
alter table helpSources  drop foreign key FKD7F07FD581F50FA


    
alter table tutorials  drop foreign key FK53D0E02281F50FA


    
alter table userExperiences  drop foreign key FK1E76E877E42E26F


    
alter table users  drop foreign key FK2C1C7C052D71B1AD


    drop table if exists accounts

    drop table if exists GroupToAccount

    drop table if exists exercices

    drop table if exists exerciceSources

    drop table if exists groups

    drop table if exists GroupToAdmins

    drop table if exists GroupToMembers

    drop table if exists helpSources

    drop table if exists tutorials

    drop table if exists tutorialSources

    drop table if exists userExperiences

    drop table if exists users

    create table accounts (
        Id INTEGER not null,
       Pseudo VARCHAR(255),
       Email VARCHAR(255),
       IsOwner TINYINT(1),
       Password VARCHAR(255),
       EntityState INTEGER,
       User_id INTEGER unique,
       primary key (Id)
    )

    create table GroupToAccount (
        Account_id INTEGER not null,
       Group_id INTEGER not null
    )

    create table exercices (
        Id INTEGER not null,
       Position INTEGER,
       Title VARCHAR(255),
       primary key (Id)
    )

    create table exerciceSources (
        Id INTEGER not null,
       Content VARCHAR(255),
       Type VARCHAR(255),
       primary key (Id)
    )

    create table groups (
        Id INTEGER not null,
       Name VARCHAR(255),
       primary key (Id)
    )

    create table GroupToAdmins (
        Group_id INTEGER not null,
       Account_id INTEGER not null
    )

    create table GroupToMembers (
        Group_id INTEGER not null,
       Account_id INTEGER not null
    )

    create table helpSources (
        Id INTEGER not null,
       Content VARCHAR(255),
       Type VARCHAR(255),
       Exercice_id INTEGER,
       primary key (Id)
    )

    create table tutorials (
        Id INTEGER not null,
       Title VARCHAR(255),
       Exercice_id INTEGER,
       primary key (Id)
    )

    create table tutorialSources (
        Id INTEGER not null,
       Content VARCHAR(255),
       Type VARCHAR(255),
       primary key (Id)
    )

    create table userExperiences (
        Id INTEGER not null,
       Code VARCHAR(255),
       CreationDate DATETIME,
       Creator_id INTEGER,
       primary key (Id)
    )

    create table users (
        Id INTEGER not null,
       FirstName VARCHAR(255),
       Name VARCHAR(255),
       Account_id INTEGER,
       primary key (Id)
    )

    alter table accounts 
        add index (User_id), 
        add constraint FKF8F14CCF1F819813 
        foreign key (User_id) 
        references users (Id)

    alter table GroupToAccount 
        add index (Group_id), 
        add constraint FK58803956B194A467 
        foreign key (Group_id) 
        references groups (Id)

    alter table GroupToAccount 
        add index (Account_id), 
        add constraint FK588039562D71B1AD 
        foreign key (Account_id) 
        references accounts (Id)

    alter table GroupToAdmins 
        add index (Account_id), 
        add constraint FKF88E7DA02D71B1AD 
        foreign key (Account_id) 
        references accounts (Id)

    alter table GroupToAdmins 
        add index (Group_id), 
        add constraint FKF88E7DA0B194A467 
        foreign key (Group_id) 
        references groups (Id)

    alter table GroupToMembers 
        add index (Account_id), 
        add constraint FK48884D412D71B1AD 
        foreign key (Account_id) 
        references accounts (Id)

    alter table GroupToMembers 
        add index (Group_id), 
        add constraint FK48884D41B194A467 
        foreign key (Group_id) 
        references groups (Id)

    alter table helpSources 
        add index (Exercice_id), 
        add constraint FKD7F07FD581F50FA 
        foreign key (Exercice_id) 
        references exercices (Id)

    alter table tutorials 
        add index (Exercice_id), 
        add constraint FK53D0E02281F50FA 
        foreign key (Exercice_id) 
        references exercices (Id)

    alter table userExperiences 
        add index (Creator_id), 
        add constraint FK1E76E877E42E26F 
        foreign key (Creator_id) 
        references accounts (Id)

    alter table users 
        add index (Account_id), 
        add constraint FK2C1C7C052D71B1AD 
        foreign key (Account_id) 
        references accounts (User_id)
