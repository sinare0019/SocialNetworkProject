using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Domain.Entity
{
    public class Reaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Post_Id")]
        public Post Post { get; set; }
        [ForeignKey("User_Id")]
        public User User { get; set; }

        public int Post_Id { get; set; }
        public int User_Id { get; set; }
       
        // لایک یا دیسک لایک
        public ReactionType ReactionType { get; set; }
    }
    public enum ReactionType
    {
        Like = 0,
        DisLike = 1
    }
}
