namespace DefaultNamespace;

public class Planet
{
    public int PlanetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public List<Moon>? Moons { get; set; }
}