namespace TP1.Models;

public class EvenementParticipant
{
    public string DateInscription { get; set; }
    public string StatutPresence { get; set; } = string.Empty;

    public int EvenementId { get; set; }
    public Evenement? Evenement { get; set; }

    public int ParticipantId { get; set; }
    public Participant? Participant { get; set; }
}