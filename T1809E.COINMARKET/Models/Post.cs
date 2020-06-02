using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace T1809E.COINMARKET.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("User")]
        public string PostedUser { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Content { get; set; }
        [ForeignKey("Rank")]
        public int PostRank { get; set; }
        public Rank Rank { get; set; }
        public PostStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
    public enum PostStatus
        {
            ACTIVE = 0,
            DISABLE = 1,
            DELETED = -1
        }
}