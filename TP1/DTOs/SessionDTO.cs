namespace TP1.DTOs;

public class SessionDTO
{
    public int Id { get; set; }
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string HeureDebut { get; set; } = string.Empty;
    public string HeureFin { get; set; } = string.Empty;
    public int EvenementId { get; set; }
    public int SalleId { get; set; }
}