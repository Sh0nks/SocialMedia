﻿using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateBorn { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
