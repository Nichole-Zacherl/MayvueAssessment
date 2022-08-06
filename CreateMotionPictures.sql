USE [Movies]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

BEGIN TRANSACTION;
DROP TABLE IF EXISTS MotionPictures;

CREATE TABLE [dbo].[MotionPictures](
	[ID] [int] IDENTITY NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ReleaseYear] [int] NOT NULL,
 CONSTRAINT [PK_MotionPictures] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO MotionPictures (Name,Description,ReleaseYear)
VALUES 
('Avengers: Endgame','After the devastating events of Avengers: Infinity War, the universe is in ruins due to the efforts of the Mad Titan, Thanos. With the help of remaining allies, the Avengers must assemble once more in order to undo Thanos actions and restore order to the universe once and for all, no matter what consequences may be in store.',2019),
( 'Avengers: Infinity War', 'As the Avengers and their allies have continued to protect the world from threats too large for any one hero to handle, a new danger has emerged from the cosmic shadows: Thanos. A despot of intergalactic infamy, his goal is to collect all six Infinity Stones, artifacts of unimaginable power, and use them to inflict his twisted will on all of reality.', 2018),
('Captain America: Civil War','Political pressure mounts to install a system of accountability when the actions of the Avengers lead to collateral damage. The new status quo deeply divides members of the team. Captain America believes superheroes should remain free to defend humanity without government interference. Iron Man sharply disagrees and supports oversight.',2016),
('Avengers: Age of Ultron','When Tony Stark jump-starts a dormant peacekeeping program, things go terribly awry, forcing him, Thor, the Incredible Hulk and the rest of the Avengers to reassemble. As the fate of Earth hangs in the balance, the team is put to the ultimate test as they battle Ultron, a technological terror hell-bent on human extinction.',2015),
('The Avengers','When Thors evil brother, Loki, gains access to the unlimited power of the energy cube called the Tesseract, Nick Fury, director of S.H.I.E.L.D., initiates a superhero recruitment effort to defeat the unprecedented threat to Earth.',2012),
('Iron Man','A billionaire industrialist and genius inventor, Tony Stark, is conducting weapons tests overseas, but terrorists kidnap him to force him to build a devastating weapon. Instead, he builds an armored suit and upends his captors. Returning to America, Stark refines the suit and uses it to combat crime and terrorism',2008),
('Iron Man 2','With the world now aware that he is Iron Man, billionaire inventor Tony Stark faces pressure from all sides to share his technology with the military. He is reluctant to divulge the secrets of his armored suit, fearing the information will fall into the wrong hands.',2010),
('Iron Man 3','Plagued with worry and insomnia since saving New York from destruction, Tony Stark, now, is more dependent on the suits that give him his Iron Man persona - so much so that every aspect of his life is affected, including his relationship with Pepper. Tony must rely solely on instinct and ingenuity to avenge his losses and protect the people he loves.',2013),
('Captain America','It is 1941 and the world is in the throes of war. Steve Rogers wants to do his part and join Americas armed forces, but the military rejects him because of his small stature. Finally, Steve gets his chance when he is accepted into an experimental program that turns him into a supersoldier called Captain America.',2011),
('Captain America: The Winter Soldier','After the cataclysmic events in New York with his fellow Avengers Captain America, lives in the nations capital as he tries to adjust to modern times. An attack on a S.H.I.E.L.D. colleague throws Rogers into a web of intrigue that places the whole world at risk. Joining forces with allies, Rogers struggles to expose an ever-widening conspiracy.',2014),
('Thor','As the son of Odin, king of the Norse gods, Thor will soon inherit the throne of Asgard from his aging father. However, on the day that he is to be crowned, Thor reacts with brutality when the gods enemies, the Frost Giants, enter the palace in violation of their treaty. As punishment, Odin banishes Thor to Earth. Thor, now stripped of his powers, faces his greatest threat.',2011),
('Thor: The Dark World ','In ancient times, the gods of Asgard fought and won a war against an evil race known as the Dark Elves. The survivors were neutralized, and their ultimate weapon -the Aether- was buried in a secret location. Hundreds of years later, Jane Foster finds the Aether and becomes its host, forcing Thor to bring her to Asgard ',2013),
('Thor: Ragnarok','Imprisoned on the other side of the universe, the mighty Thor finds himself in a deadly gladiatorial contest that pits him against the Hulk, his former ally and fellow Avenger. Thors quest for survival leads him in a race against time to prevent the all-powerful Hela from destroying his home world and the Asgardian civilization.',2017)
;

COMMIT;
GO