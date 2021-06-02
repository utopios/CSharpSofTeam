Drop TABLE client;
Drop TABLE compte;
Drop TABLE operation;
/*
 * Création table Utilisateur
 */
CREATE TABLE [dbo].[client]
(
	[Id] INT IDENTITY (1, 1) NOT NULL, 
    [nom] VARCHAR(50) NOT NULL, 
    [prenom] VARCHAR(50) NOT NULL, 
    [telephone] VARCHAR(50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
)

/*
 * Création table Compte
 */
CREATE TABLE [dbo].[compte]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,       
    [solde]  DECIMAL (10, 2) NOT NULL,
    [client_id]   INT   NOT NULL
    PRIMARY KEY CLUSTERED ([id] ASC)
)

/*
 * Création table opération
 */
CREATE TABLE [dbo].[operation]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
    [montant]      DECIMAL (10, 2) NOT NULL,
    [date_Operation] DATETIME     NOT NULL,
    [compte_id]    VARCHAR (50) NOT NULL   
    PRIMARY KEY CLUSTERED ([id] ASC)
)