namespace TP1.DTOs;

public class NotationDTO
{
    public int Id { get; set; }
    public int Note { get; set; }
    public string Commentaire { get; set; } = string.Empty;
    public int SessionId { get; set; }
    public int ParticipantId { get; set; }
}