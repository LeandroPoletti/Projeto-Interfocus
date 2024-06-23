import "./App.css";
import { BrowserRouter } from "simple-react-routing";
import Home from "./home/home";
import Layout from "./layout/Layout";
import ListaClientes from "./clientes/lista_clientes/lista_clientes";
import  ListaDividas from "./divida/lista_divida/Lista_Dividas"

function App() {
  return (
    <BrowserRouter
      notFoundPage={<h1>404 - NOT FOUND</h1>}
      routes={[
        {
          path: "",
          component: <Home></Home>
        },
        {
          path: "clientes",
          component: <ListaClientes></ListaClientes>
        },
        {
          path: "dividas",
          component: <ListaDividas></ListaDividas>
        }
      
      ]}>
        <Layout></Layout>
        </BrowserRouter>
  );
}

export default App;
