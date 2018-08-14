----DELETE * FROM skills
DROP TABLE skills
CREATE TABLE [dbo].[Skills] (
    [id]    INT          IDENTITY (1, 1) NOT NULL,
    [skill] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([id] ASC)
);
INSERT INTO SKILLS (skill) VALUES('Drooling')
INSERT INTO SKILLS (skill) VALUES('Driving')
INSERT INTO SKILLS (skill) VALUES('Efficiency expert')
INSERT INTO SKILLS (skill) VALUES('Comendering')
INSERT INTO SKILLS (skill) VALUES('Pirating')
INSERT INTO SKILLS (skill) VALUES('Dependency Injection')
INSERT INTO SKILLS (SKILL) VALUES('Cuddling')
INSERT INTO SKILLS (skill) VALUES('Gravity Testing')
INSERT INTO SKILLS (skill) VALUES('Filling Boxes')
INSERT INTO SKILLS (skill) VALUES('Hate')
INSERT INTO SKILLS (skill) VALUES('Schedule Management')
INSERT INTO SKILLS (skill) VALUES('Hiding')
INSERT INTO SKILLS (skill) VALUES('Life Coach')
--INSERT INTO SKILLS (skill) VALUES('')


----DELETE * FROM Cats
DROP TABLE Cats
CREATE TABLE [dbo].[Cats] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [name]        VARCHAR (50)  NULL,
    [color]       VARCHAR (50)  NULL,
    [hair_length] VARCHAR (50)  NULL,
    [age]         INT           NULL,
    [prior_exp]   VARCHAR (250) NULL,
    [photo]       VARCHAR (50)  NULL,
    [is_featured] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Percy','orange $ white', 'Long', 12, 'Purficient at wakeup calls', 'Percy.jpg', 1 )
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Fern', 'tabby', 'long', 8, 'Will do anything for bread.', 'fern.jpg', 0 )
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Luna', 'Black & Orange', 'short', 3, 'Flexible for the right opportunity', 'luna.jpg', 0 )
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Picard', 'orange', 'short', 7, 'Licking, Stealing food, Commanding USS Enterprise', 'picard.jpg', 0)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Memesiku', 'calico', 'long', 9, 'Flooping, Drooling, Hunting gnats', 'memsiku.jpg', 1 )
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Wulfgang', 'black', 'long', 7, 'Always looking for new ways to assinate dogs', 'wulfgang.jpg', 0 )
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('Brahm', 'brown', 'short', 5, '100% good boy 0% cat', 'brahm.jpg', 0)
--INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured ) VALUES ('', '',, '', '', 0)

----DELETE * FROM cat_skill
DROP TABLE cat_skills
CREATE TABLE [dbo].[cat_skill] (
    [cat_id]   INT NOT NULL,
    [skill_id] INT NOT NULL,
    CONSTRAINT [PK_Cats_Skills_cat_id_skill_id] PRIMARY KEY CLUSTERED ([cat_id] ASC, [skill_id] ASC)
);
INSERT INTO cat_skill (cat_id, skill_id) VALUES(1, 1)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(1, 7)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(2, 6)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(2, 10)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(3, 2)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(3, 5)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(3, 9)
--INSERT INTO cat_skill (cat_id, skill_id) VALUES(, )

----DELETE * FROM 
DROP TABLE Users
CREATE TABLE [dbo].[Users] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [name]     NCHAR (10)   NULL,
    [password] VARCHAR (50) NULL,
    [is_admin] BIT          DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
INSERT INTO Users (name, password, is_admin) VALUES ('Dinah',			'password', 1)
INSERT INTO Users (name, password, is_admin) VALUES ('Peter',			'password', 1)
INSERT INTO Users (name, password, is_admin) VALUES ('Dan',				'password', 1)
INSERT INTO Users (name, password, is_admin) VALUES ('Austin',			'password', 1)
INSERT INTO Users (name, password, is_admin) VALUES ('John',			'password', 1)
INSERT INTO Users (name, password, is_admin) VALUES ('Babadook',		'password', 0)
INSERT INTO Users (name, password, is_admin) VALUES ('rumpelstiltskin', 'password', 0)
INSERT INTO Users (name, password, is_admin) VALUES ('Slenderman',		'password', 0)
INSERT INTO Users (name, password, is_admin) VALUES ('NightMan',		'password', 0)
INSERT INTO Users (name, password, is_admin) VALUES ('DayMan',			'password', 0)
--INSERT INTO Users (name, password, is_admin) VALUES ('', '', 0)

