namespace web_api.ViewModels;

public class UserViewmodel
{
    
    public class MeViewModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}