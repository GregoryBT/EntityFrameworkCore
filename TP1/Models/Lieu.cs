namespace TP1.Models;

public class Lieu
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Ville { get; set; } = string.Empty;
    public string Pays { get; set; } = string.Empty;
    public int Capacite { get; set; }

    public List<Salle>? Salles { get; set; }
    public List<Evenement>? Evenements { get; set; }
}