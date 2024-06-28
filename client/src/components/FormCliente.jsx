import { useEffect, useState, useReducer } from "react";
import { useRouter, useNavigation } from "simple-react-routing";
import { DeletarCliente, getCliente, postCliente } from "../services/clienteService";
import CardDivida from "./CardDivida";

export default function FormCliente() {
  const { pathParams } = useRouter();
  const codigo = pathParams["codigo"];
  const [cliente, setCliente] = useState({});
  const [erro, setErro] = useState("");

  const { navigateTo } = useNavigation()

  const [cpf, setCpf] = useReducer((old, value) => {
    var digitos = value.replace(/[^0-9]+/g, "").substring(0, 11);

    if (digitos.length <= 3) return digitos;
    else if (digitos.length <= 6) {
      return digitos.replace(/(\d{3})(\d+)/, "$1.$2");
    } else if (digitos.length <= 9) {
      return digitos.replace(/(\d{3})(\d{3})(\d+)/, "$1.$2.$3");
    } else {
      return digitos.replace(/(\d{3})(\d{3})(\d{3})(\d+)/, "$1.$2.$3-$4");
    }
  }, "");

  const [email, setEmail] = useReducer((old, value) => {
    let email = value?.trim().replace(" ", "").toLowerCase();

    return email;
  });

  useEffect(() => {
    if (codigo) {
      getCliente(codigo).then((response) => {
        if (response.status == 200) {
          response.json().then((response) => {
            setCliente(response);
            setCpf(response.cpf);
            setEmail(response.email);
            console.log(response);
          });
        }
      });
    }
  }, []);

  const salvarCliente = async (evento) => {
    evento.preventDefault();
    let dados = new FormData(evento.target);
    let strippedCpf = dados.get("cpf");
    strippedCpf = strippedCpf.replace(/\D/g, "");

    let cliente = {
      nome: dados.get("nome"),
      cpf: strippedCpf,
      nascimento: dados.get("nascimento"),
      email: dados.get("email"),
      dividasDoCliente: [],
    };

    if (codigo) {
      cliente.id = codigo;
    }

    let resposta = await postCliente(cliente);
    if (resposta.status == 200) {
      navigateTo(null, "/")
    } else {
      let mensagem = await resposta.json();
      setErro("Erro: " + JSON.stringify(mensagem, null, "\t"));
    }
  };

  const deletar = async (id) => {
    let resposta = await DeletarCliente(id)
    if(resposta.status == 200){
      console.log("Deletado")
      navigateTo(null, "/")
    }
  }

  return (
    <>
      <div className="cliente-page">
        <div className="form-cliente">
          <h1>{codigo ? "Editar" : "Cadastrar"} cliente</h1>
          <form onSubmit={salvarCliente}>
            <div className="nome form-item">
              <label htmlFor="nome">Nome:</label>
              <input
                type="text"
                name="nome"
                id="nome"
                defaultValue={cliente.nome}
              />
            </div>
            <div className="cpf form-item">
              <label htmlFor="cpf">Cpf:</label>
              <input
                name="cpf"
                id="cpf"
                type="text"
                maxLength={14}
                onChange={(e) => {
                  setCpf(e.target.value);
                }}
                value={cpf}
              />
            </div>
            <div className="email form-item">
              <label htmlFor="email">Email:</label>
              <input
                type="email"
                name="email"
                id="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </div>
            <div className="nascimento form-item">
              <label htmlFor="nascimento">Data de nascimento</label>
              <input
                type="date"
                name="nascimento"
                id="nascimento"
                defaultValue={cliente.nascimento?.substring(0, 10)}
              />
            </div>

            <div className="form-buttons">
              <button
                className="card-button"
                type="button"
                onClick={() => deletar(cliente.id) == 200 ? console.log("oi") : console.log("falha ao deletar")}
              >
                Excluir
              </button>
              <button className="card-button" type="submit">
                Salvar mudanças
              </button>
              {/* <button className="card-button"></button> */}
            </div>
          </form>
          {erro ? <p>{erro}</p> : <></>}
        </div>
        <hr />

        {cliente.id ? (
          <div className="lista-dividas">
            <div className="titulo">
              <h3>Dividas do cliente</h3>
              <hr />
            </div>
            {cliente.dividasDoCliente.map((divida) => {
              return <CardDivida key={divida.id} divida={divida}></CardDivida>;
            })}
          </div>
        ) : (
          <p>Não é possivel listar dividas de um cliente não cadastrado</p>
        )}
      </div>
    </>
  );
}
