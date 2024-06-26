import "./App.css";
import { BrowserRouter } from "simple-react-routing";
import Layout from "./layout/Layout";
import Home from "./layout/Home";
import FormCliente from "./components/FormCliente";

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
        }

      ]}>
      <Layout></Layout>
    </BrowserRouter>
  );
}

export default App;
