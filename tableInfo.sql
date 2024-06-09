CREATE SEQUENCE cliente_seq;
CREATE SEQUENCE divida_seq;


CREATE TABLE IF NOT EXISTS cliente(
	id INTEGER NOT NULL DEFAULT nextval('cliente_seq') PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	cpf CHAR(11) NOT NULL,
	nascimento DATE NOT NULL,
	email VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS divida(
	id SERIAL NOT NULL DEFAULT nextval('divida_seq') PRIMARY KEY,
	situacao BOOL 
);
