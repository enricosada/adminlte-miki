using System;

namespace w6.Models
{
    public class UserInfo
    {
        public string Nome { get; set; }
        public int Eta { get; set; }
        public bool Sportiva { get; set; }
        public string Location { get; set; }
    }

    public static class Users
    {
        static Users()
        {
            CurrentUser = new UserInfo { Nome = "Laura", Eta = 21, Sportiva = false, Location = "Malibu, California" };
        }

        public static UserInfo CurrentUser { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Nome { get; set; }
        public string Location { get; set; }
    }

    public class UserEditViewModel
    {
        public string Nome { get; set; }
        public int Eta { get; set; }
        public bool Sportiva { get; set; }
        public bool Salvato { get; set; }
    }

    public class UserEditFormData
    {
        public string Nome { get; set; }
        public int Eta { get; set; }
        public bool Sportiva { get; set; }
    }
}
