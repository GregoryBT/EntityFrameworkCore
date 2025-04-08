namespace TP1.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        // Relations
        public int LieuId { get; set; }
        public Lieu? Lieu { get; set; }
        public List<Session>? Sessions { get; set; }

    }
}