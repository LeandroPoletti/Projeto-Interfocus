import "./App.css";
import { BrowserRouter } from "simple-react-routing";
import Home from "./home/home";
import Layout from "./layout/Layout";
import ListaClientes from "./clientes/lista_clientes/lista_clientes";
// import ListaClientes from "./clientes/lista_clientes/lista_clientes";

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
        }
      
      ]}>
        <Layout></Layout>
        </BrowserRouter>
  );
}

export default App;
