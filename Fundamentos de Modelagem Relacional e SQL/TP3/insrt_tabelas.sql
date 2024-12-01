INSERT INTO Livros (titulo, autor, preco, estoque) VALUES
('O Senhor dos Anéis', 'J.R.R. Tolkien', 59.90, 10),
('1984', 'George Orwell', 39.90, 15),
('Dom Quixote', 'Miguel de Cervantes', 49.90, 8),
('A Revolução dos Bichos', 'George Orwell', 29.90, 20),
('O Pequeno Príncipe', 'Antoine de Saint-Exupéry', 19.90, 25);

INSERT INTO Clientes (nome, email, telefone, endereco) VALUES
('João Silva', 'joao@example.com', '9999-8888', 'Rua A, 123'),
('Maria Souza', 'maria@example.com', '8888-7777', 'Rua B, 456'),
('Carlos Oliveira', 'carlos@example.com', '7777-6666', 'Rua C, 789'),
('Ana Lima', 'ana@example.com', '6666-5555', 'Rua D, 101'),
('Paula Ribeiro', 'paula@example.com', '5555-4444', 'Rua E, 202');

INSERT INTO Pedidos (cliente_id, data_pedido, valor_total) VALUES
(1, '2024-11-01', 150.00),
(2, '2024-11-02', 300.00),
(3, '2024-11-03', 100.00),
(4, '2024-11-04', 50.00),
(5, '2024-11-05', 250.00);