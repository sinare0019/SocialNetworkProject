using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Domain.Entity
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("عنوان پست")]
        [Required(ErrorMessage ="لطفا عنوان پست را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }

        [DisplayName("متن پست")]
        [Required(ErrorMessage = "لطفا متن پست را وارد کنید")]
        [MaxLength(500)]
        public string Content { get; set; }

        public DateTime Date { get; set; }
        public int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public User User { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }
}
