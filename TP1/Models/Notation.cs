using TP1.Models;

public class Notation
{
    public int Id { get; set; }
    public int Note { get; set; }
    public string Commentaire { get; set; } = string.Empty;

    public int SessionId { get; set; }
    public Session? Session { get; set; }

    public int ParticipantId { get; set; }
    public Participant? Participant { get; set; }
}