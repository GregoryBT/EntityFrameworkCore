namespace TP1.Models;

public class Participant
{
    public int Id { get; set; }
    public string Prenom { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Entreprise { get; set; } = string.Empty;
    public string Poste { get; set; } = string.Empty;

    public List<EvenementParticipant>? EvenementParticipants { get; set; }
    public List<Notation>? Notations { get; set; }
}

