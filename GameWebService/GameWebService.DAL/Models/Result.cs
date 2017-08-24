using System;

namespace GameWebService.DAL.Models
{
    public class Result
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public int Score { get; set; }

        public string Time { get; set; }

        public User User { get; set; }
    }
}