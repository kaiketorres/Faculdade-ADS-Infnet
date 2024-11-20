CREATE TABLE TB_NIVEL (
    Id INT NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(50) NOT NULL,
    CONSTRAINT PK_NIVEL PRIMARY KEY (Id)
);

CREATE TABLE TB_CARGO (
    Id INT NOT NULL AUTO_INCREMENT,
    IdNivel INT NOT NULL,
    Descricao VARCHAR(250),
    SalarioBase DECIMAL(10,2) NOT NULL,
    CONSTRAINT PK_CARGO PRIMARY KEY (Id),
    CONSTRAINT FK_NIVEL_CARGO FOREIGN KEY (IdNivel) REFERENCES TB_NIVEL (Id)
);

CREATE TABLE TB_DEPARTAMENTO (
    Id INT NOT NULL AUTO_INCREMENT,
    IdFuncionario INT NULL,
    Nome VARCHAR(150) NOT NULL,    
    Andar INT NOT NULL,
    CONSTRAINT PK_DEPARTAMENTO PRIMARY KEY (Id)
);

CREATE TABLE TB_FUNCIONARIO (
    Id INT NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(150),
    IdCargo INT NULL,
    IdDepartamento INT NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,    
    CONSTRAINT PK_FUNCIONARIO PRIMARY KEY (Id),
    CONSTRAINT FK_FUNCIONARIO_DEPARTAMENTO FOREIGN KEY (IdDepartamento) REFERENCES TB_DEPARTAMENTO (Id),
    CONSTRAINT FK_CARGO_FUNCIONARIO FOREIGN KEY (IdCargo) REFERENCES TB_CARGO (Id)
);

ALTER TABLE TB_DEPARTAMENTO
ADD CONSTRAINT FK_DEPARTAMENTO_FUNCIONARIO
FOREIGN KEY (IdFuncionario) REFERENCES TB_FUNCIONARIO (Id);


INSERT INTO TB_NIVEL (Nome) VALUES ('Estagiario');
INSERT INTO TB_NIVEL (Nome) VALUES ('Junior');
INSERT INTO TB_NIVEL (Nome) VALUES ('Pleno');
INSERT INTO TB_NIVEL (Nome) VALUES ('Senior');
INSERT INTO TB_NIVEL (Nome) VALUES ('Gerente');
INSERT INTO TB_NIVEL (Nome) VALUES ('Diretor');

INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (1, 'Analista de Sistemas', 1000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (2, 'Analista de Sistemas', 2000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (3, 'Analista de Sistemas', 4000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (4, 'Analista de Sistemas', 8000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (1, 'Analista de RH', 1000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (2, 'Analista de RH', 3000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (3, 'Analista de RH', 4500.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (4, 'Analista de RH', 6500.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (1, 'Contador', 1000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (2, 'Contador', 3000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (3, 'Contador', 5000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (4, 'Contador', 7000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (1, 'Analista de Marketing', 1000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (2, 'Analista de Marketing', 2000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (3, 'Analista de Marketing', 3000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (4, 'Analista de Marketing', 4000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (1, 'Vendedor', 1000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (2, 'Vendedor', 2000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (3, 'Vendedor', 3000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (4, 'Vendedor', 5000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (5, 'Gerente', 15000.00);
INSERT INTO TB_CARGO (IdNivel, Descricao, SalarioBase) VALUES (6, 'Diretor', 25000.00);


INSERT INTO TB_DEPARTAMENTO (Nome, Andar) VALUES ('TI', 1);
INSERT INTO TB_DEPARTAMENTO (Nome, Andar) VALUES ('RH', 2);
INSERT INTO TB_DEPARTAMENTO (Nome, Andar) VALUES ('Financeiro', 3);
INSERT INTO TB_DEPARTAMENTO (Nome, Andar) VALUES ('Marketing', 4);
INSERT INTO TB_DEPARTAMENTO (Nome, Andar) VALUES ('Vendas', 5);
INSERT INTO TB_DEPARTAMENTO (Nome, Andar) VALUES ('Limpeza', 6);

INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Lucas Ferreira', 1, 1, 1000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Lucas Almeida', 1, 1, 1000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Fernanda Oliveira', 2, 1, 2000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Ricardo Costa', 3, 1, 4000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Júlia Silva', 4, 1, 8000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Pedro Santos', 5, 2, 1000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Mariana Almeida', 6, 2, 3000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Carlos Pereira', 7, 2, 4500.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Ana Costa', 8, 2, 6500.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Gabriel Lima', 9, 3, 1000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Roberta Martins', 10, 3, 3000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Tatiane Rocha', 11, 3, 5000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Felipe Souza', 12, 3, 7000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Laura Nunes', 13, 4, 1000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Luana Almeida', 14, 4, 2000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Renato Silva', 15, 4, 3000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Marcela Costa', 16, 4, 4000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Eduardo Santos', 17, 5, 1000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Priscila Lima', 18, 5, 2000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Leonardo Rocha', 19, 5, 3000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Paula Pereira', 20, 5, 5000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('João Fernandes', 21, 1, 15000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Cristina Andrade', 22, 2, 25000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Juliano Lima', 21, 3, 15000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Aline Costa', 21, 4, 15000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Sandra Oliveira', 21, 5, 15000.00);
INSERT INTO TB_FUNCIONARIO (Nome, IdCargo, IdDepartamento, Salario) VALUES ('Janaina Pereira', NULL, 6, 1500.00);

UPDATE TB_DEPARTAMENTO SET IdFuncionario = (SELECT Id FROM TB_FUNCIONARIO WHERE Nome = 'João Fernandes') WHERE Nome = 'TI';
UPDATE TB_DEPARTAMENTO SET IdFuncionario = (SELECT Id FROM TB_FUNCIONARIO WHERE Nome = 'João Fernandes') WHERE Nome = 'RH';
UPDATE TB_DEPARTAMENTO SET IdFuncionario = (SELECT Id FROM TB_FUNCIONARIO WHERE Nome = 'Juliano Lima') WHERE Nome = 'Financeiro';
UPDATE TB_DEPARTAMENTO SET IdFuncionario = (SELECT Id FROM TB_FUNCIONARIO WHERE Nome = 'Aline Costa') WHERE Nome = 'Marketing';
UPDATE TB_DEPARTAMENTO SET IdFuncionario = (SELECT Id FROM TB_FUNCIONARIO WHERE Nome = 'Sandra Oliveira') WHERE Nome = 'Vendas';
