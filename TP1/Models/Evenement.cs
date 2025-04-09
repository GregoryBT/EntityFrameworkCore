namespace TP1.Models;

public class Evenement
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string DateDebut { get; set; } = string.Empty;
    public string DateFin { get; set; } = string.Empty;
    public string Statut { get; set; } = string.Empty;
    public string Categorie { get; set; } = string.Empty;

    public int LieuId { get; set; }
    public Lieu? Lieu { get; set; }

    public List<Session>? Sessions { get; set; }
    public List<EvenementParticipant>? EvenementParticipants { get; set; }
}