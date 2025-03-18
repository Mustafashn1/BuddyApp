namespace BuddyApi.Models
{
    public class Planlama
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? PlanAdi { get; set; }
        public string? PlanAciklama { get; set; }
        public int Oncelik { get; set; }
        public DateOnly TarihAraligi { get; set; }
        public long Durum { get; set; }
        public string? Notlar { get; set; }

    }
}
