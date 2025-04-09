namespace TP1.Models;

public class Session
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string HeureDebut { get; set; } = string.Empty;
    public string HeureFin { get; set; } = string.Empty;

    public int EvenementId { get; set; }
    public Evenement? Evenement { get; set; }

    public int SalleId { get; set; }
    public Salle? Salle { get; set; }

    public List<SessionIntervenant>? SessionIntervenants { get; set; }
    public List<Notation>? Notations { get; set; }
}
