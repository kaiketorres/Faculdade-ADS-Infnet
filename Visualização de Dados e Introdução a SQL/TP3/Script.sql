
-- 1. Liste todos os times e seus respectivos rankings FIFA.
SELECT "Team", "FIFA Ranking"
FROM "teams";

-- 2. Recupere os nomes dos times e o nome de seus capitães.
SELECT "Team", "Captain"
FROM "teams";

-- 3. Liste os times que têm um ranking FIFA menor que 10.
SELECT "Team", "FIFA Ranking"
FROM "teams"
WHERE "FIFA Ranking" < 10;

-- 4. Recupere os times que tiveram uma mudança positiva em seus pontos ("Change in Points" maior que 0).
SELECT "Team", "Change in Points"
FROM "teams"
WHERE "Change in Points" > 0;

-- 5. Liste os times que têm um ranking FIFA menor que 10 e que também tiveram uma mudança negativa em seus pontos.
SELECT "Team", "FIFA Ranking", "Change in Points"
FROM "teams"
WHERE "FIFA Ranking" < 10
AND "Change in Points" < 0;

-- 6. Recupere os times que têm um ranking FIFA maior que 30 ou que tiveram uma mudança em seus pontos maior que 5.
SELECT "Team", "FIFA Ranking", "Change in Points"
FROM "teams"
WHERE "FIFA Ranking" > 30
OR "Change in Points" > 5;

-- 7. Liste os times que estão no "Group A" ou "Group B".
SELECT "Team", "Group"
FROM "teams"
WHERE "Group" = 'Group A'
OR "Group" = 'Group B';

-- 8. Recupere os times cujos treinadores são 'Didier Deschamps', 'Gareth Southgate', ou 'Cristiano Ronaldo'.
SELECT "Team", "Manager Name"
FROM "teams"
WHERE "Manager Name" IN ('Didier Deschamps', 'Gareth Southgate', 'Cristiano Ronaldo');

-- 9. Liste os times que têm uma média de idade dos jogadores maior que 27 anos e cujo técnico está há mais de 3 anos no cargo.
SELECT "Team", "Average Age", "Installation (in years)"
FROM "teams"
WHERE "Average Age" > 27
AND "Installation (in years)" > 3;

-- 10. Recupere o nome dos times e seus pontos totais, mas exclua os times que têm um técnico com menos de 2 anos de instalação.
SELECT "Team", "Total Points"
FROM "teams"
WHERE "Installation (in years)" >= 2;

-- 11. Recupere o nome dos times e seus locais de treinamento, ordenados pelo nome do time.
SELECT "Team", "Training Ground"
FROM "teams"
ORDER BY "Team";
