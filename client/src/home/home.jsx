import "./home.css"
import {Link} from "react-router-dom"


export default function Home() {
  return (
    <>
    <div className="mainTitle">
      <h1>Gerencie seus clientes e suas dividas com facilidade</h1>
    </div>
    <div className="homeContent">
      <div className="home-links">
        <Link to="/clientes">Clientes</Link>
      </div>
    </div>
    </>
  );
}
