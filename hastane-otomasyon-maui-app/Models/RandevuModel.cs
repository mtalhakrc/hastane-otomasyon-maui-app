namespace hastane_otomasyon_maui_app.Models;

public class RandevuModel 
{ 
        public int Id { get; set; }
        public string Isim { get; set; }
        public DateTime Tarih { get; set; }
        public string Not { get; set; }
        public string DoctorID { get; set; }
        public MeModel Doctor { get; set; }
        public string HastaID { get; set; }
        public MeModel Hasta { get; set; }

}
