using GameWebService.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWebService.ViewModels
{
    public static class UserCabinet
    {
        public static string Name { get; set; }

        public static string Surname { get; set; }

        public static string MiddleName { get; set; }

        public static string Login { get; set; }

        public static string Password { get; set; }

        public static string Email { get; set; }

        public static string Phone { get; set; }

        public static ICollection<Result> Results { get; set; } = new List<Result>();
    }
}
