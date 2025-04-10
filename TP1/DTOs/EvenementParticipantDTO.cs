namespace TP1.DTOs;

public class EvenementParticipantDTO
{
    public string DateInscription { get; set; } = string.Empty;
    public string StatutPresence { get; set; } = string.Empty;
    public int EvenementId { get; set; }
    public int ParticipantId { get; set; }
}

