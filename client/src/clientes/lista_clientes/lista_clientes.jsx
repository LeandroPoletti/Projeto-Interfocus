import { useEffect, useState } from "react";
import "./lista_clientes.css";
import { listarClientes, idadeAtual, somarDividas } from "/src/services/clienteService";

export default function ListaClientes() {
  const [pagina, setPagina] = useState(1);
  const [pesquisa, setPesquisa] = useState("");
  const [clientes, setClientes] = useState([]);

  useEffect(() => {
    listarClientes(pagina, pesquisa).then((resposta) => {
      if (resposta.status == 200) {
        resposta.json().then((resposta) => {
          console.log(resposta);
          setClientes(resposta);
        });
      }
    });
  }, [pagina, pesquisa]);

  return (
    <>
      <div className="listaTitulo">
        <h1>Lista de clientes cadastrados</h1>
      </div>
      <div className="lista">
        {clientes.map((cliente) => {
            let datanascimento =  idadeAtual(cliente.nascimento)
            let somaDasDividas = somarDividas(cliente.dividasDoCliente)

          return (
            <>
              <div className="card">
                <div className="nome">
                  <h2>{cliente.nome}</h2>
                </div>
                <div className="idade">Idade: {datanascimento}</div>
                <div className="email">
                  Email:
                  <a href="mailto:" className="email-link">
                    {" "}
                    {cliente.email}
                  </a>
                </div>
                <div className="divida">Valor em aberto: R${somaDasDividas}</div>
                <hr />
                <div className="footer">
                  <button className="excluir lista-button">Excluir</button>
                  <button className="editar lista-button">Editar</button>
                </div>
              </div>
            </>
          );
        })}
      </div>
      <div className="page-navigator">
        <button
          className="lista-button anterior"
          onClick={() => setPagina(Math.max(1, pagina - 1))}
        >
          Anterior
        </button>
        <div className="current-page page-info">{pagina}</div>
        <button
          className="lista-button proxima"
          onClick={() => setPagina(pagina + 1)}
        >
          Proxima
        </button>
      </div>
    </>
  );
}
