import "./home.css"
import {Link} from "simple-react-routing"


export default function Home() {
  return (
    <>
    <div className="mainTitle">
      <h1>Gerencie seus clientes e suas dividas com facilidade</h1>
    </div>
    <div className="homeContent">
      <div className="home-links">
        <Link to="/clientes">
        <button>
          Clientes
        </button>
        </Link>
        <Link to="/dividas">
        <button>
          Dividas
        </button>
        </Link>
      </div>
    </div>
    </>
  );
}
