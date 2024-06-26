import "./navbar.css";
import { Link } from "simple-react-routing";

export default function Navbar() {
  return (
    <>
      <div className="navbar">
        <div className="Brand">
          <Link to="/">
            <h1>Projeto Interfocus</h1>
          </Link>
        </div>

        <div className="links">
          <Link to="/clientes">Cadastrar cliente</Link>
          <Link to="/dividas"> Cadastrar divida</Link>
        </div>
      </div>
    </>
  );
}
