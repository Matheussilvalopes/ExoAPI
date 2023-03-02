CREATE DATABASE ExoAPI
GO

USE ExoAPI
GO

CREATE TABLE Projetos (
    Id INT PRIMARY KEY IDENTITY,
    Titulo VARCHAR(150) NOT NULL,
    QuantidadeDesenvolvedores INT,
    Prioridade Varchar(6)
)
GO

INSERT INTO Projetos (Titulo, QuantidadeDesenvolvedores, Prioridade) 
VALUES ('Projeto 1', 3, 'Alta')
GO

INSERT INTO Projetos (Titulo, QuantidadeDesenvolvedores, Prioridade) 
VALUES ('Projeto 2', 3, 'Baixa')
GO

INSERT INTO Projetos (Titulo, QuantidadeDesenvolvedores, Prioridade) 
VALUES ('Projeto 3', 3, 'Média')
GO

-- UPDATE Livros SET Titulo = 'Titulo A1' Where Id = 1;

 -- DELETE FROM Livros WHERE Id = 1;

SELECT Id, Titulo, QuantidadeDesenvolvedores, Prioridade FROM Projetos
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Senha VARCHAR(120) NOT NULL,
	Tipo  VARCHAR(6) NOT NULL
)
GO

INSERT INTO Usuarios VALUES ('email1@sp.br', '1234','Admin'),('email2@email.com','1234','Comum'),('email3@email.com','1234','Comum'),('email4@email.com','1234','Admin' ),
('email5@email.com','1234','Comum'),('email6@email.com','1234', 'Comum'),('email7@email.com','1234', 'Admin'),('emai8@email.com','1234', 'Comum'),('email9@email.com','1234', 'Comum')

GO

--SELECT * FROM Usuarios WHERE email = 'email@sp.br' AND senha = '1234'
--GO

Select * from Usuarios
