import { useEffect, useState } from "react";
import { listarClientes } from "../services/clienteService";
import ListaCliente from "../components/ListaCliente";

export default function Home() {
  const [pagina, setPagina] = useState(1);
  const [clientes, setClientes] = useState([]);
  const [pesquisa, setPesquisa] = useState("")

  useEffect(() => {
    listarClientes(pagina, pesquisa).then((response) => {
      if (response.status == 200) {
        response.json().then(content => {
          setClientes(content)
        })
      }
    })
  }, [pagina, pesquisa]);

  return (
    <>
      <div className="logo">
        <h1>Exibindo informações de clientes cadastrados</h1>
      </div>
      <div className="search">
        <input type="search" name="" id="" className="searchbar" onChange={(event) => setPesquisa(event.target.value)} placeholder="Pesquisar cliente"/>
      </div>

      {clientes.map((cliente) => {
        return (<ListaCliente key={cliente.id} cliente={cliente}></ListaCliente>)
      })}

      <div className="footer">
        <div
          className={pagina == 1 ? "esconder button-list" : "button-list"}
          onClick={() => {
            setPagina(Math.max(1, pagina - 1));
          }}
        >
          Anterior
        </div>
        {pagina}
        <div className="button-nav" onClick={() => setPagina(pagina + 1)}>
          Proximo
        </div>
      </div>
    </>
  );
}
