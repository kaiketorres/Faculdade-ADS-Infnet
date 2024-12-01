
-- Alterações na Estrutura das Tabelas
ALTER TABLE Livros ADD COLUMN categoria VARCHAR(100);
ALTER TABLE Clientes CHANGE telefone celular VARCHAR(20);
ALTER TABLE Livros MODIFY COLUMN preco FLOAT;

-- Atualizando Dados
UPDATE Livros SET estoque = 5 WHERE livro_id = 1;
UPDATE Clientes SET endereco = 'Rua Nova, 123' WHERE cliente_id = 3;
UPDATE Pedidos SET valor_total = 200.00 WHERE pedido_id = 4;

-- Excluindo Dados
DELETE FROM Livros WHERE livro_id = 2;
DELETE FROM Clientes WHERE cliente_id = 5;
DELETE FROM Pedidos WHERE valor_total < 100;

-- Removendo uma Tabela
DROP TABLE Pedidos;
