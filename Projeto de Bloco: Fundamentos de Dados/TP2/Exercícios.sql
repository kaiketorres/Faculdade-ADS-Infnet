-- 1) Listar os funcionários, cargos e departamentos em ordem alfabética.
-- Funcionários em ordem alfabética
SELECT * FROM TB_FUNCIONARIO ORDER BY Nome;

-- Cargos em ordem alfabética
SELECT * FROM TB_CARGO ORDER BY Descricao;

-- Departamentos em ordem alfabética
SELECT * FROM TB_DEPARTAMENTO ORDER BY Nome;

-- 2) Listar todos os departamentos localizados no quinto andar.
SELECT * FROM TB_DEPARTAMENTO WHERE Andar = 5;

-- 3) Listar o(a) analista com o salário mais alto.
SELECT 
    FUNC.Nome,
    FUNC.Salario
FROM TB_FUNCIONARIO FUNC
INNER JOIN TB_CARGO CARG ON FUNC.IdCargo = CARG.Id
WHERE CARG.Descricao LIKE '%Analista%'
ORDER BY FUNC.Salario DESC
LIMIT 1;

-- 4) Listar os funcionários com salário maior ou igual ao salário base do departamento de TI.
SELECT 
    FUNC.Nome,
    FUNC.Salario,
    CARG.SalarioBase 
FROM TB_FUNCIONARIO FUNC
INNER JOIN TB_CARGO CARG ON FUNC.IdCargo = CARG.Id
INNER JOIN TB_DEPARTAMENTO DEPA ON FUNC.IdDepartamento = DEPA.Id
WHERE DEPA.Nome = 'TI'
  AND FUNC.Salario >= CARG.SalarioBase;

-- 5) Listar o departamento com o maior número de estagiários.
SELECT 
    DEPA.Nome,
    COUNT(*) AS NumeroEstagiarios
FROM TB_FUNCIONARIO FUNC
INNER JOIN TB_CARGO CARG ON FUNC.IdCargo = CARG.Id
INNER JOIN TB_DEPARTAMENTO DEPA ON FUNC.IdDepartamento = DEPA.Id
WHERE CARG.IdNivel = 1
GROUP BY DEPA.Nome
ORDER BY NumeroEstagiarios DESC
LIMIT 1;

-- 6) Listar todos os funcionários que não possuem cargo associado.
SELECT * FROM TB_FUNCIONARIO WHERE IdCargo IS NULL;

-- 7) Listar os funcionários que estão no andar mais alto.
SELECT 
    FUNC.Nome,
    DEPA.Nome AS Departamento,
    DEPA.Andar
FROM TB_FUNCIONARIO FUNC
INNER JOIN TB_DEPARTAMENTO DEPA ON FUNC.IdDepartamento = DEPA.Id
WHERE DEPA.Andar = (
    SELECT MAX(Andar)
    FROM TB_DEPARTAMENTO
);

-- 8) Listar o cargo de funcionários que ganham entre 3000 e 5000.
SELECT 
    DISTINCT CARG.Descricao
FROM TB_FUNCIONARIO FUNC
INNER JOIN TB_CARGO CARG ON FUNC.IdCargo = CARG.Id
WHERE FUNC.Salario BETWEEN 3000 AND 5000;

-- 9) Listar o nome dos gerentes que chefiem ao menos dois departamentos.
SELECT 
    FUNC.Nome
FROM TB_FUNCIONARIO FUNC
INNER JOIN TB_CARGO CARG ON FUNC.IdCargo = CARG.Id
INNER JOIN TB_DEPARTAMENTO DEPA ON DEPA.IdFuncionario = FUNC.Id
WHERE CARG.IdNivel = 5
GROUP BY FUNC.Nome
HAVING COUNT(DISTINCT DEPA.Id) >= 2;

-- 10) Listar o cargo com o salário base mais baixo.
SELECT 
    CARG.Descricao, 
    CARG.SalarioBase
FROM TB_CARGO CARG
ORDER BY CARG.SalarioBase ASC
LIMIT 1;

-- 11) Listar o departamento com o salário mais alto.
SELECT 
    DEPA.Nome, 
    MAX(FUNC.Salario) AS SalarioMaisAlto
FROM TB_FUNCIONARIO FUNC
JOIN TB_DEPARTAMENTO DEPA ON FUNC.IdDepartamento = DEPA.Id
GROUP BY DEPA.Nome
ORDER BY SalarioMaisAlto DESC
LIMIT 1;

-- 12) Listar o andar onde ficam os diretores.
SELECT 
    DISTINCT DEPA.Andar
FROM TB_FUNCIONARIO FUNC
JOIN TB_CARGO CARG ON FUNC.IdCargo = CARG.Id
JOIN TB_DEPARTAMENTO DEPA ON FUNC.IdDepartamento = DEPA.Id
WHERE CARG.IdNivel = 6;

-- 13) Listar funcionários em ordem alfabética, que atendam a uma lógica criada por você, a partir do campo escolhido, que foi definido na tabela de funcionários.
SELECT 
    Nome,
    Salario
FROM TB_FUNCIONARIO
WHERE Salario > (
    SELECT AVG(Salario)
    FROM TB_FUNCIONARIO
    )
  AND Nome LIKE 'A%'
ORDER BY Nome;

-- 14) Listar cargos em ordem alfabética, que atendam a uma lógica criada por você, a partir do campo escolhido, que foi definido na tabela de cargos.
SELECT 
    Descricao,
    SalarioBase
FROM TB_CARGO
WHERE SalarioBase < (
    SELECT AVG(SalarioBase)
    FROM TB_CARGO
    )
  AND Descricao LIKE '%Analista%'
ORDER BY Descricao;

-- 15) Listar departamentos em ordem alfabética, que atendam a uma lógica criada por você, a partir do campo escolhido, que foi definido na tabela de departamentos.
SELECT 
    Nome,
    Andar
FROM TB_DEPARTAMENTO
WHERE Andar % 2 <> 0
  AND Nome LIKE '%E%'
ORDER BY Nome;
