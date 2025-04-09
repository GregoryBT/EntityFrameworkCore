using TP1.Models;

public class SessionIntervenant
{
    public string Role { get; set; } = string.Empty;

    public int SessionId { get; set; }
    public Session? Session { get; set; }

    public int IntervenantId { get; set; }
    public Intervenant? Intervenant { get; set; }
}