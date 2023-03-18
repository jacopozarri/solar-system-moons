import { useState, useEffect } from "react";
import "./App.css";
import { Moon, Planet } from "./Types";
function Mars() {
  const [planets, setPlanets] = useState<Planet[]>([]);
  const fetchPlanets = async () => {
    const result = await fetch("https://localhost:3000/api/Planet");
    const data = await result.json();
    setPlanets(data);
    console.log(data);
  };
  useEffect(() => {
    fetchPlanets();
  }, []);
  const [newMoonName, setNewMoonName] = useState("");
  const [newMoonDescription, setNewMoonDescription] = useState("");
  const [newMoonImage, setNewMoonImage] = useState("");
  const [newMoonPlanetId, setNewMoonPlanetId] = useState(4);
  const handleNewMoonSubmit = async (
    event: React.FormEvent<HTMLFormElement>
  ) => {
    event.preventDefault();
    const newMoon: Moon = {
      moonId: 0,
      planetId: newMoonPlanetId,
      name: newMoonName,
      description: newMoonDescription,
      image: newMoonImage,
    };
    const result = await fetch("https://localhost:3000/api/Moon", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newMoon),
    });
    if (result.ok) {
      fetchPlanets();
      setNewMoonName("");
      setNewMoonDescription("");
      setNewMoonImage("");
      setNewMoonPlanetId(4);
    } else {
      console.error("Failed to add new moon");
    }
  };
  return (
    <div>
      {planets
        .filter((planet) => planet.planetId === 4)
        .map((planet) => (
          <span key={planet.planetId}>
            <img src={planet.image} alt={planet.name} />
            <h1>{planet.name}</h1>
            <p>{planet.description}</p>
            <div>
              {planet.moons.map((moon) => (
                <div>
                  <span key={moon.moonId}>
                    <img src={moon.image} alt={moon.name} />
                    <h1>{moon.name}</h1>
                    <p>{moon.description}</p>
                  </span>
                </div>
              ))}
            </div>
          </span>
        ))}
      <form onSubmit={handleNewMoonSubmit}>
        <label>
          Moon Name
          <input
            type="text"
            value={newMoonName}
            onChange={(event) => setNewMoonName(event.target.value)}
          />
        </label>
        <br />
        <label>
          Description
          <input
            type="text"
            value={newMoonDescription}
            onChange={(event) => setNewMoonDescription(event.target.value)}
          />
        </label>
        <br />
        <label>
          Image_URL
          <input
            type="text"
            value={newMoonImage}
            onChange={(event) => setNewMoonImage(event.target.value)}
          />
        </label>
        <br />
        <button type="submit">Add new moon</button>
      </form>
    </div>
  );
}
export default Mars;
