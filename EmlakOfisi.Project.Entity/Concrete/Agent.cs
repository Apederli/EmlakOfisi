using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EmlakOfisi.Core.DataAccess.Abstract;

namespace EmlakOfisi.Project.Entity.Concrete
{
    public class Agent : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [NotMapped]
        public string PasswordVerify { get; set; }

        public string CompanyName { get; set; }

        public string AddedByAdminId { get; set; }

        public DateTime AddedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

    }
}
