namespace TP1.DTOs;

public class SessionIntervenantDTO
{
    public string Role { get; set; } = string.Empty;
    public int SessionId { get; set; }
    public int IntervenantId { get; set; }
}