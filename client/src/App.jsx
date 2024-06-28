import "./App.css";
import { BrowserRouter } from "simple-react-routing";
import Layout from "./layout/Layout";
import Home from "./layout/Home";
import FormCliente from "./components/FormCliente";
import { FormDivida } from "./components/FormDivida";

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
          path: "clientes/:codigo",
          component: <FormCliente></FormCliente>
        },
        {
          path: "clientes",
          component: <FormCliente></FormCliente>
        },
        {
          path: "dividas",
          component: <FormDivida></FormDivida>
        },
        {
          path: "dividas/:codigo",
          component: <FormDivida></FormDivida>
        }

      ]}>
      <Layout></Layout>
    </BrowserRouter>
  );
}

export default App;
