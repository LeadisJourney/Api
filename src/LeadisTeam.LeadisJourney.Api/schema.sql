
    
alter table accounts  drop foreign key FK68C28F4A5B879EEA
;

    
alter table GroupToAccount  drop foreign key FK589DA7B9CFB9D93E
;

    
alter table GroupToAccount  drop foreign key FK589DA7B918195D0C
;

    
alter table GroupToAdmins  drop foreign key FK5649E31018195D0C
;

    
alter table GroupToAdmins  drop foreign key FK5649E310CFB9D93E
;

    
alter table GroupToMembers  drop foreign key FKDB8A38C718195D0C
;

    
alter table GroupToMembers  drop foreign key FKDB8A38C7CFB9D93E
;

    
alter table helpSources  drop foreign key FK2DC6875F8A5155E4
;

    
alter table tutorials  drop foreign key FKE595C8678A5155E4
;

    
alter table userExperiences  drop foreign key FKC8F5034E352B6C1
;

    
alter table users  drop foreign key FK617CBC1A18195D0C
;

    drop table if exists accounts;

    drop table if exists GroupToAccount;

    drop table if exists exercices;

    drop table if exists exerciceSources;

    drop table if exists groups;

    drop table if exists GroupToAdmins;

    drop table if exists GroupToMembers;

    drop table if exists helpSources;

    drop table if exists tutorials;

    drop table if exists tutorialSources;

    drop table if exists userExperiences;

    drop table if exists users;

    create table accounts (
        Id INTEGER not null,
       Pseudo VARCHAR(255),
       Email VARCHAR(255),
       IsOwner TINYINT(1),
       Password VARCHAR(255),
       EntityState INTEGER,
       User_id INTEGER unique,
       primary key (Id)
    );

    create table GroupToAccount (
        Account_id INTEGER not null,
       Group_id INTEGER not null
    );

    create table exercices (
        Id INTEGER not null,
       Position INTEGER,
       Title VARCHAR(255),
       primary key (Id)
    );

    create table exerciceSources (
        Id INTEGER not null,
       Content VARCHAR(255),
       Type VARCHAR(255),
       primary key (Id)
    );

    create table groups (
        Id INTEGER not null,
       Name VARCHAR(255),
       primary key (Id)
    );

    create table GroupToAdmins (
        Group_id INTEGER not null,
       Account_id INTEGER not null
    );

    create table GroupToMembers (
        Group_id INTEGER not null,
       Account_id INTEGER not null
    );

    create table helpSources (
        Id INTEGER not null,
       Content VARCHAR(255),
       Type VARCHAR(255),
       Exercice_id INTEGER,
       primary key (Id)
    );

    create table tutorials (
        Id INTEGER not null,
       Title VARCHAR(255),
       Exercice_id INTEGER,
       primary key (Id)
    );

    create table tutorialSources (
        Id INTEGER not null,
       Content VARCHAR(255),
       Type VARCHAR(255),
       primary key (Id)
    );

    create table userExperiences (
        Id INTEGER not null,
       Code VARCHAR(255),
       CreationDate DATETIME,
       Creator_id INTEGER,
       primary key (Id)
    );

    create table users (
        Id INTEGER not null,
       FirstName VARCHAR(255),
       Name VARCHAR(255),
       Account_id INTEGER,
       primary key (Id)
    );

    alter table accounts 
        add index (User_id), 
        add constraint FK68C28F4A5B879EEA 
        foreign key (User_id) 
        references users (Id);

    alter table GroupToAccount 
        add index (Group_id), 
        add constraint FK589DA7B9CFB9D93E 
        foreign key (Group_id) 
        references groups (Id);

    alter table GroupToAccount 
        add index (Account_id), 
        add constraint FK589DA7B918195D0C 
        foreign key (Account_id) 
        references accounts (Id);

    alter table GroupToAdmins 
        add index (Account_id), 
        add constraint FK5649E31018195D0C 
        foreign key (Account_id) 
        references accounts (Id);

    alter table GroupToAdmins 
        add index (Group_id), 
        add constraint FK5649E310CFB9D93E 
        foreign key (Group_id) 
        references groups (Id);

    alter table GroupToMembers 
        add index (Account_id), 
        add constraint FKDB8A38C718195D0C 
        foreign key (Account_id) 
        references accounts (Id);

    alter table GroupToMembers 
        add index (Group_id), 
        add constraint FKDB8A38C7CFB9D93E 
        foreign key (Group_id) 
        references groups (Id);

    alter table helpSources 
        add index (Exercice_id), 
        add constraint FK2DC6875F8A5155E4 
        foreign key (Exercice_id) 
        references exercices (Id);

    alter table tutorials 
        add index (Exercice_id), 
        add constraint FKE595C8678A5155E4 
        foreign key (Exercice_id) 
        references exercices (Id);

    alter table userExperiences 
        add index (Creator_id), 
        add constraint FKC8F5034E352B6C1 
        foreign key (Creator_id) 
        references accounts (Id);

    alter table users 
        add index (Account_id), 
        add constraint FK617CBC1A18195D0C 
        foreign key (Account_id) 
        references accounts (User_id);
