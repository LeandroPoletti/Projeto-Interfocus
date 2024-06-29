# Projeto Interfocus

[Github: LeandroPoletti](https://github.com/LeandroPoletti)

---

## Como inicializar o banco de dados

- As instruções do banco se encontram no arquivo tableinfo.sql
- Para realizar testes existe o arquivo mockdata.sql que contém dados de exemplo possuem cpf invalido pois foram gerados pelo chat gpt para fins de teste

## Uso backend

> ### Pacotes
>
> Para o backend foi utilizado os pacotes aprenstados durante a aula com finalidade de permitir a comunicação entre o banco de dados e a api facilmente utilizando o conceito de ORM

> ### Endpoints e suas finalidades
>
> Foram feitos endpoints para as duas entidades do projeto, cliente e divida, ambas possuindo endpoinsts para trabalhar com GET, POST, PUT e DELETE
>
> Cliente
>
> > - GET
> >
> >   Permite ao usuario listar os clintes cadastrados por pagina, onde cada retorna um limite de 10 clientes, porém ao inserir a pagina como -1 retorna todos os clientes listadas, permitindo a funcionalidade do `<select>` ao cadastrar dividas.
> >
> > - POST
> >
> >   Permite a atualização apenas dos dados cadastrados do cliente, sendo necessário utilizar o formulário de cada divida para atualizar suas informações.
> > - PUT
> >
> >   Permite atualizar dados cadastrados com a mesma restrição de dividas do POST
> > - DELETE
> >   Permite deletar um cliente cadastrado, sendo a exclusão de dividas relacionadas a ela feito com constraint no banco de dados
>
> ---
>
> Divida
>
> Todos os métodos responsáveis por atualizar a informação verificam a somatória do cliente antes de gravar as alterações
>
> > - GET
> >
> >   É possivel utilizar de duas formas, passando ou não o parametro id. No primeiro caso retorna apenas a divida referente ao id junto com informações do cliente da divída, que por si retorna as demais que possui. No segundo caso retorna todas as dividas cadastradas e informações de seus clientes, porém os clientes não listam as demais dividas
> > - POST
> >
> >   Permite cadastrar uma nova divida ao cliente informado, sendo necessário apenas informar o id do cliente
> > - PUT
> >
> >   Permite atualizar o cadastrado da divida, sendo possível alterar seu dono por meio dessa requisição
> > - DELETE
> >
> >   Permite deletar apenas uma divida
>
> ***
> ## FRONTEND
> 
> Foi utilizado a biblioteca react porém devido a questão de disponibilidade de tempo e habilidades pessoais não foi possível realizar uma integração decente, porém é possível realizar todas as ações esperadas, sendo elas:
> 
> - Cadastrar uma divida ou um cliente
> - Alterar informações de um cliente ou de uma divida 
> - Excluir um cliente ou uma divida