import { useEffect, useState } from "react";
import { listarClientes } from "../services/clienteService";
import ListaCliente from "../components/ListaCliente";
import { Link } from "simple-react-routing";

export default function Home() {
  const [pagina, setPagina] = useState(1);
  const [clientes, setClientes] = useState([]);
  const [pesquisa, setPesquisa] = useState("");

  useEffect(() => {
    listarClientes(pagina, pesquisa).then((response) => {
      if (response.status == 200) {
        response.json().then((content) => {
          setClientes(content);
        });
      }
    });
  }, [pagina, pesquisa]);

  return (
    <>
      <div className="logo">
        <h1>Exibindo informações de clientes cadastrados</h1>
      </div>
      <div className="search">
        <input
          type="search"
          name=""
          id=""
          className="searchbar"
          onChange={(event) => {
            setPesquisa(event.target.value);
            setPagina(1);
          }}
          placeholder="Pesquisar cliente"
        />
        <div className="cadastros">
          <Link to="clientes">
            <button className="card-button">Cadastrar cliente</button>
          </Link>

          <Link to="dividas">
            <button className="card-button">Cadastrar divida</button>
          </Link>
        </div>
      </div>

      <div className="footer">
        <div
          className={pagina == 1 ? "esconder card-button" : "card-button"}
          onClick={() => {
            setPagina(Math.max(1, pagina - 1));
          }}
        >
          Anterior
        </div>
        {pagina}
        <div className="card-button" onClick={() => setPagina(pagina + 1)}>
          Proximo
        </div>
      </div>

      {clientes.map((cliente) => {
        return <ListaCliente key={cliente.id} cliente={cliente}></ListaCliente>;
      })}

      <div className="footer">
        <div
          className={pagina == 1 ? "esconder card-button" : "card-button"}
          onClick={() => {
            setPagina(Math.max(1, pagina - 1));
          }}
        >
          Anterior
        </div>
        {pagina}
        <div className="card-button" onClick={() => setPagina(pagina + 1)}>
          Proximo
        </div>
      </div>
    </>
  );
}
