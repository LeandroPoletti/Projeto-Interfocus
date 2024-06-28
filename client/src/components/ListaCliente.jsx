import { Link } from "simple-react-routing";
import { idadeAtual } from "../services/clienteService";
import CardDivida from "./CardDivida";
import { DeletarCliente } from "../services/clienteService";

/* eslint-disable react/prop-types */
export default function ListaCliente({ cliente }) {


  const deletar = async (id) => {
    let resposta = await DeletarCliente(id)
    if(resposta.status == 200){
      console.log("Deletado")
      window.location.reload()
    }
  }

  let idade = idadeAtual(cliente.nascimento);
  return (
    <>
      <div className="card">
        <div className="card-header">
          <div className="card-personal-info">
            <h2>{cliente.nome}</h2>
            <p>Cpf: {cliente.cpf}</p>
          </div>
          <div className="card-contact">
            <a href={cliente.email ? "mailto:" + cliente.email : ""}>
              {cliente.email ? cliente.email : "Não informado"}
            </a>
            <p>Idade: {idade}</p>
            <p>Valor total em aberto: {cliente.totalEmAberto}</p>
          </div>
        </div>
        <hr />
        <div className="card-main-content">
          {cliente.dividasDoCliente.map((divida) => {
            return <CardDivida key={divida.id} divida={divida}></CardDivida>;
          })}
        </div>
        <div className="card-footer card-cliente-footer">
          <button className="card-button" onClick={() => deletar(cliente.id)}>Excluir</button>
          <Link to={"clientes/" + cliente.id}>
            <button className="card-button">Editar</button>
          </Link>
        </div>
      </div>
    </>
  );
}
