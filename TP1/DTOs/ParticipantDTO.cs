namespace TP1.DTOs;

public class ParticipantDTO
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Entreprise { get; set; } = string.Empty;
    public string Poste { get; set; } = string.Empty;
}