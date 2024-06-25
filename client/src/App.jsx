import "./App.css";
import { BrowserRouter } from "simple-react-routing";
import Layout from "./layout/Layout";
import Home from "./layout/Home";

function App() {
  return (
    <BrowserRouter
      notFoundPage={<h1>404 - NOT FOUND</h1>}
      routes={[
        {
          path: "",
          component: <Home></Home>
        },

      ]}>
      <Layout></Layout>
    </BrowserRouter>
  );
}

export default App;
