-- Inserindo 30 usuários
INSERT INTO cliente (nome, cpf, nascimento, email)
VALUES 
('Alice Souza', '19026689012', '1990-01-01', 'alice.souza@example.com'),
('Bruno Lima', '41008907022', '1985-02-15', 'bruno.lima@example.com'),
('Carlos Silva', '01224156048', '1978-03-20', 'carlos.silva@example.com'),
('Daniela Costa', '11703936086', '1992-04-25', 'daniela.costa@example.com'),
('Eduardo Santos', '31612872077', '1989-05-30', 'eduardo.santos@example.com'),
('Fernanda Rocha', '30485290049', '1983-06-10', 'fernanda.rocha@example.com'),
('Gustavo Almeida', '62736606035', '1975-07-14', 'gustavo.almeida@example.com'),
('Helena Martins', '02547284057', '1994-08-18', 'helena.martins@example.com'),
('Isabel Ferreira', '23349268099', '1988-09-22', 'isabel.ferreira@example.com'),
('João Pinto', '64719396046', '1979-10-26', 'joao.pinto@example.com'),
('Karla Mendes', '61573961051', '1984-11-30', 'karla.mendes@example.com'),
('Luis Oliveira', '94892452084', '1991-12-12', 'luis.oliveira@example.com'),
('Mariana Sousa', '65342330025', '1982-01-16', 'mariana.sousa@example.com'),
('Nicolas Barros', '28240261035', '1977-02-20', 'nicolas.barros@example.com'),
('Olivia Gonçalves', '19449384002', '1986-03-24', 'olivia.goncalves@example.com'),
('Paulo Carvalho', '33739148098', '1993-04-28', 'paulo.carvalho@example.com'),
('Quelia Dantas', '13373648009', '1981-05-02', 'quelia.dantas@example.com'),
('Rafael Reis', '29460551084', '1995-06-06', 'rafael.reis@example.com'),
('Sofia Araújo', '45636878044', '1987-07-10', 'sofia.araujo@example.com'),
('Thiago Melo', '81654823007', '1980-08-14', 'thiago.melo@example.com'),
('Ursula Xavier', '03543362070', '1976-09-18', 'ursula.xavier@example.com'),
('Victor Nunes', '68764053032', '1990-10-22', 'victor.nunes@example.com'),
('Wanda Batista', '04501170069', '1983-11-26', 'wanda.batista@example.com'),
('Xavier Tavares', '77933020011', '1978-12-30', 'xavier.tavares@example.com'),
('Yara Freitas', '93467205062', '1992-01-04', 'yara.freitas@example.com'),
('Zeca Teixeira', '80396221076', '1989-02-08', 'zeca.teixeira@example.com'),
('Alana Moura', '60387919066', '1984-03-12', 'alana.moura@example.com'),
('Brenda Neves', '67000813008', '1979-04-16', 'brenda.neves@example.com'),
('Carlos Braga', '88775921090', '1988-05-20', 'carlos.braga@example.com'),
('Daniel Borges', '31661713041', '1981-06-24', 'daniel.borges@example.com');

-- Inserindo 50 dívidas
INSERT INTO divida (valor, situacao, descricao, id_cliente)
VALUES 
(50.00, false, 'Compra de materiais', 1),
(30.00, true, 'Pagamento de serviços', 1),
(100.00, false, 'Serviço de manutenção', 2),
(20.00, true, 'Compra de suprimentos', 2),
(150.00, false, 'Pagamento de aluguel', 3),
(10.00, true, 'Compra de alimentos', 3),
(70.00, false, 'Serviço de limpeza', 4),
(40.00, true, 'Compra de vestuário', 4),
(60.00, false, 'Pagamento de contas', 5),
(50.00, true, 'Compra de eletrônicos', 5),
(90.00, false, 'Serviço de transporte', 6),
(50.00, true, 'Compra de remédios', 6),
(110.00, false, 'Pagamento de impostos', 7),
(20.00, true, 'Compra de livros', 7),
(80.00, false, 'Serviço de jardinagem', 8),
(30.00, true, 'Compra de móveis', 8),
(40.00, false, 'Pagamento de serviços', 9),
(100.00, true, 'Compra de materiais', 9),
(50.00, false, 'Serviço de manutenção', 10),
(30.00, true, 'Compra de suprimentos', 10),
(70.00, false, 'Pagamento de aluguel', 11),
(60.00, true, 'Compra de alimentos', 11),
(50.00, false, 'Serviço de limpeza', 12),
(40.00, true, 'Compra de vestuário', 12),
(100.00, false, 'Pagamento de contas', 13),
(20.00, true, 'Compra de eletrônicos', 13),
(150.00, false, 'Serviço de transporte', 14),
(10.00, true, 'Compra de remédios', 14),
(90.00, false, 'Pagamento de impostos', 15),
(50.00, true, 'Compra de livros', 15),
(110.00, false, 'Serviço de jardinagem', 16),
(20.00, true, 'Compra de móveis', 16),
(80.00, false, 'Pagamento de serviços', 17),
(30.00, true, 'Compra de materiais', 17),
(40.00, false, 'Serviço de manutenção', 18),
(100.00, true, 'Compra de suprimentos', 18),
(50.00, false, 'Pagamento de aluguel', 19),
(30.00, true, 'Compra de alimentos', 19),
(70.00, false, 'Serviço de limpeza', 20),
(60.00, true, 'Compra de vestuário', 20),
(50.00, false, 'Pagamento de contas', 21),
(40.00, true, 'Compra de eletrônicos', 21),
(100.00, false, 'Serviço de transporte', 22),
(20.00, true, 'Compra de remédios', 22),
(150.00, false, 'Pagamento de impostos', 23),
(10.00, true, 'Compra de livros', 23),
(90.00, false, 'Serviço de jardinagem', 24),
(50.00, true, 'Compra de móveis', 24),
(110.00, false, 'Pagamento de serviços', 25),
(20.00, true, 'Compra de materiais', 25),
(80.00, false, 'Serviço de manutenção', 26),
(30.00, true, 'Compra de suprimentos', 26),
(40.00, false, 'Pagamento de aluguel', 27),
(100.00, true, 'Compra de alimentos', 27),
(50.00, false, 'Serviço de limpeza', 28),
(30.00, true, 'Compra de vestuário', 28),
(70.00, false, 'Pagamento de contas', 29),
(60.00, true, 'Compra de eletrônicos', 29),
(50.00, false, 'Serviço de transporte', 30),
(40.00, true, 'Compra de remédios', 30);

-- Assegurando que nenhum usuário tenha mais de 200 reais em dívidas
