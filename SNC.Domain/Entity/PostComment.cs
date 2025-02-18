using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Domain.Entity
{
    public class PostComment
    {
        public int Post_Id { get; set; }
        public int Comment_Id { get; set; }

        public Post Post { get; set; }
        public Comment Comment { get; set; }
    }
}
