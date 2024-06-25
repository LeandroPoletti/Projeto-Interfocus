import {Link} from "simple-react-routing"
import { idadeAtual, somarDividas } from "../services/clienteService";
import CardDivida from "./CardDivida";

/* eslint-disable react/prop-types */
export default function ListaCliente({ cliente }) {
  let idade = idadeAtual(cliente.nascimento)
  let total = somarDividas(cliente.dividasDoCliente)
    return (
    <>
      <div className="card">
        <div className="card-header">
          <div className="card-personal-info">
            <h2>{cliente.nome}</h2>
            <p>Cpf: {cliente.cpf}</p>
          </div>
          <div className="card-contact">
            <a href={cliente.email ? "mailto:" + cliente.email : ""}  >{cliente.email ? cliente.email : "Não informado"}</a>
            <p>Idade: {idade}</p>
            <p>Valor total em aberto: {total}</p>
          </div>
        </div>
        <hr />
        <div className="card-main-content">
            {cliente.dividasDoCliente.map(divida => {
                return <CardDivida key={divida.id} divida={divida}></CardDivida>
            })}
        </div>
        <div className="card-footer card-cliente-footer">
            <button className="card-button">Excluir</button>
            <Link to={"cliente/" + cliente.id}>
            <button className="card-button">Editar</button>
            </Link>
        </div>
      </div>
    </>
  );
}
