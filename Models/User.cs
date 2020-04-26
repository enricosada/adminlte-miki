using System;

namespace w6.Models
{
    public static class Users
    {
        public static int CurrentUserId { get; set; }
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
