using System;
using System.Collections.Generic;
using System.Text;

namespace GameWebService.DAL.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string MiddleName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<Result> Results { get; set; } = new List<Result>();        

        public Role Role { get; set; }
    }
}
