﻿--DELETE FROM Skill, Cats, cat_skill, Users, Reviews, sucess_Stories
INSERT INTO Skills (skill) VALUES('Drooling')
INSERT INTO Skills (skill) VALUES('Driving')
INSERT INTO Skills (skill) VALUES('Efficiency expert')
INSERT INTO Skills (skill) VALUES('Comendering')
INSERT INTO Skills (skill) VALUES('Pirating')
INSERT INTO Skills (skill) VALUES('Dependency Injection')
INSERT INTO Skills (SKILL) VALUES('Cuddling')
INSERT INTO Skills (skill) VALUES('Gravity Testing')
INSERT INTO Skills (skill) VALUES('Filling Boxes')
INSERT INTO Skills (skill) VALUES('Hate')
INSERT INTO Skills (skill) VALUES('Schedule Management')
INSERT INTO Skills (skill) VALUES('Hiding')
INSERT INTO Skills (skill) VALUES('Life Coach')
--INSERT INTO SKILLS (skill) VALUES('')


INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Percy',		'orange and white', 'Long',  12, 'Purficient at wakeup calls',						'Percy.jpg',	1, 'A fluffy cudly mainecoon taht likes to eat hair ties', 1)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Fern',		'tabby',		  'long',   8, 'Will do anything for bread.',						'fern.jpg',		0, 'Sassy and coy, only eats the finest wet foods', 1)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Luna',		'Black & Orange', 'short',  3, 'Flexible for the right opportunity',				'luna.jpg',		0, 'Overly affectionate, loves laptop keyboards', 1)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Picard',		'orange',		  'short',  7, 'Licking, Stealing food, Commanding USS Enterprise', 'picard.jpg',	0, 'Tricky, friendly and bossy. Watch your wallet', 1)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Memesiku',	'calico',		  'long',   9, 'Flooping, Drooling, Hunting gnats',					'memisiku.jpg',	1, 'Drooling, fat lard. Needs incentivized to do anything', 1)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Wulfgang',	'black',		  'long',   7, 'Always looking for new ways to assinate dogs',		'wulfgang.jpg', 0, '', 1)
INSERT INTO Cats (name, color, hair_length, age, prior_exp, photo, is_featured, description, isEmployed) VALUES ('Brahm',		'brown',		  'short',  5, '100% good boy 0% cat',								'brahm.jpg',	0, 'Very excited all the time, Suspected of not being a cat', 1)

INSERT INTO cat_skill (cat_id, skill_id) VALUES(1, 1)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(1, 7)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(2, 6)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(2, 10)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(3, 2)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(3, 5)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(3, 9)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(4, 2)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(4, 13)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(4, 11)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(5, 1)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(5, 3)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(5, 6)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(5, 9)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(6, 2)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(6, 7)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(6, 10)
INSERT INTO cat_skill (cat_id, skill_id) VALUES(7, 13)
--INSERT INTO cat_skill (cat_id, skill_id) VALUES(, )

INSERT INTO Users (name, email, password, is_admin) VALUES ('Dinah',			'adnmin@email.com.com',			'password', 1)
INSERT INTO Users (name, email, password, is_admin) VALUES ('Peter',			'adnmin@email.com.com',			'password', 1)
INSERT INTO Users (name, email, password, is_admin) VALUES ('Dan',				'adnmin@email.com.com',			'password', 1)
INSERT INTO Users (name, email, password, is_admin) VALUES ('Austin',			'adnmin@email.com.com',			'password', 1)
INSERT INTO Users (name, email, password, is_admin) VALUES ('John',				'adnmin@email.com.com',			'password', 1)
INSERT INTO Users (name, email, password, is_admin) VALUES ('Babadook',			'babadook@email.com',			'password', 0)
INSERT INTO Users (name, email, password, is_admin) VALUES ('rumpelstiltskin',	'rumpdahump@email.com',			'password', 0)
INSERT INTO Users (name, email, password, is_admin) VALUES ('Slenderman',		'slendy@email.com',				'password', 0)
INSERT INTO Users (name, email, password, is_admin) VALUES ('NightMan',			'EnemyofDayman@email.com',		'password', 0)
INSERT INTO Users (name, email, password, is_admin) VALUES ('DayMan',			'FighterofNightman@email.com',  'password', 0)
--INSERT INTO Users (name, password, is_admin) VALUES ('', '', 0)

INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (1, 4, GETDATE(), 5, 'Generic Title', '', 'Picard has really taken an interest in the cleanliness of my hands', 1)
INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (1, 5, GETDATE(), 5, 'Generic Title', '', 'Memesiku is very inviting to strangers, tolerates superiors', 1)
INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (1, 6, GETDATE(), 4, 'Generic Title', '', 'Never have I met a cat more determined to kill dogs', 1)
INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (2, 7, GETDATE(), 2, 'Generic Title', '', 'Brahm does his best to fit in', 1)
INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (3, 1, GETDATE(), 3, 'Generic Title', '', 'Percy - Very sucessful morning wakeups', 1)
INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (3, 2, GETDATE(), 4, 'Generic Title', '', 'Fern will find your bread at any costs', 1)
INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (3, 3, GETDATE(), 4, 'Generic Title', '', 'Luna always finds a way', 1)
--INSERT INTO Reviews (user_id, cat_id, date, rating, title, sucess_story, review, is_approved) VALUES (, , GETDATE(), , , , , )

