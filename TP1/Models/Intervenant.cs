using TP1.Models;

public class Intervenant
{
    public int Id { get; set; }
    public string Prenom { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public string Biographie { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Entreprise { get; set; } = string.Empty;

    public List<SessionIntervenant>? SessionIntervenants { get; set; }
}