namespace TP1.Models
{
    public class Lieu
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;

        // Relations
        public List<Evenement>? Evenements { get; set; } = new List<Evenement>();
    }
}
