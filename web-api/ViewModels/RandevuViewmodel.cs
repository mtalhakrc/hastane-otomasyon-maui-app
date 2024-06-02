namespace web_api.ViewModels
{
    public class RandevuViewModel
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public DateTime Tarih { get; set; }
        public string Not { get; set; }
        public string DoctorID { get; set; }
        public UserViewmodel.MeViewModel Doctor { get; set; }
        public string HastaID { get; set; }
        public UserViewmodel.MeViewModel Hasta { get; set; }
    }
}