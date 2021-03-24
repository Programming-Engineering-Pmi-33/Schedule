using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ScheduleWebApp
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            Requests = new HashSet<Request>();
            UserSubjects = new HashSet<UserSubject>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<UserSubject> UserSubjects { get; set; }


        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }
        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }
        [NotMapped]
        public override bool PhoneNumberConfirmed { get; set; }
        [NotMapped]
        public override string PhoneNumber { get; set; }
        [NotMapped]
        public override string ConcurrencyStamp { get; set; }
        [NotMapped]
        public override string SecurityStamp { get; set; }
        [NotMapped]
        public override string PasswordHash { get; set; }
        [NotMapped]
        public override bool EmailConfirmed { get; set; }
        [NotMapped]
        public override string NormalizedEmail { get; set; }
        [NotMapped]
        public override string Email { get; set; }
        [NotMapped]
        public override string NormalizedUserName { get; set; }
        [NotMapped]
        public override string UserName { get; set; }
        [NotMapped]
        public override bool LockoutEnabled { get; set; }
        [NotMapped]
        public override int AccessFailedCount { get; set; }
    }
}
