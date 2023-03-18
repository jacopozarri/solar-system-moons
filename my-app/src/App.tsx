import "./App.css";
import { Routes, Route, Link } from "react-router-dom";
import Jupiter from "./Jupiter";
import Earth from "./Earth";
import Mars from "./Mars";
import Mercury from "./Mercury";
import Neptune from "./Neptune";
import Saturn from "./Saturn";
import Venus from "./Venus";
import Pluto from "./Pluto";
import Uranus from "./Uranus";
import Home from "./Home";
function App() {
  return (
    <nav>
      <Link to="/mercury">Mercury</Link>
      <Link to="/venus">Venus</Link>
      <Link to="/earth">Earth</Link>
      <Link to="/mars">Mars</Link>
      <Link to="/jupiter">Jupiter</Link>
      <Link to="/saturn">Saturn</Link>
      <Link to="/uranus">Uranus</Link>
      <Link to="/neptune">Neptune</Link>
      <Link to="/pluto">Pluto</Link>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/jupiter" element={<Jupiter />} />
        <Route path="/earth" element={<Earth />} />
        <Route path="/mars" element={<Mars />} />
        <Route path="/mercury" element={<Mercury />} />
        <Route path="/neptune" element={<Neptune />} />
        <Route path="/pluto" element={<Pluto />} />
        <Route path="/saturn" element={<Saturn />} />
        <Route path="/uranus" element={<Uranus />} />
        <Route path="/venus" element={<Venus />} />
      </Routes>
    </nav>
  );
}
export default App;
