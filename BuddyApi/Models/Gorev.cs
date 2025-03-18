namespace BuddyApi.Models
{
    public class Gorev
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? GorevAdi { get; set; }
        public string? GorevAciklama { get; set; }
        public int Oncelik { get; set; }
        public DateOnly SonTarih { get; set; }
        public long Durum { get; set; }
        public string? Notlar { get; set; }

    }
}
