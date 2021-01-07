CREATE TABLE Empregados (
  Id SERIAL  NOT NULL ,
  Nome TEXT,
  Profissao TEXT,
  Idade INTEGER,
PRIMARY KEY(Id));

INSERT INTO Empregados VALUES 
(1, 'Maria', 'Desenvolvedor', 26),
(2, 'Ana', 'Vendedor', 34),
(3, 'Diego', 'Montador', 30),
(4, 'José', 'Desenvolvedor', 41),
(5, 'Paulo', 'Montador', 34);

SELECT nome, (SELECT (Select Extract('Year' From Now()) LIMIT 1) - idade as "AnoNascimento") FROM EMPREGADOS WHERE profissao <> 'Montador';