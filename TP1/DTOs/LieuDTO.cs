namespace TP1.DTOs;

public class LieuDTO
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Ville { get; set; } = string.Empty;
    public string Pays { get; set; } = string.Empty;
    public int Capacite { get; set; }
}