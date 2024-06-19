-- CLiente
insert into cliente (nome, cpf, nascimento, email) 
	values ('Leandro', '46338728851', '2004-12-03', 'leandropoletti@outlook.com');
select * from cliente;

-- Divida
insert into divida (valor, situacao, descricao, id_cliente)
	values
	(5000,FALSE, 'comprinha teste do banco', 1);

select * from divida;