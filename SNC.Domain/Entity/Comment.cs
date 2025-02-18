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
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(500)]
        [Required(ErrorMessage ="لطفا متن کامنت را وارد کنید")]
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public User User { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
    }
}
