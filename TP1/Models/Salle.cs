namespace TP1.Models;

public class Salle
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public int Capacite { get; set; }

    public int LieuId { get; set; }
    public Lieu? Lieu { get; set; }

    public List<Session>? Sessions { get; set; }
}