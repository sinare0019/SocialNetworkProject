using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Model.Comment
{
    public record CommentViewModel
    {
        public int? Id { get; init; }
        public DateTime? CommentDate { get; init; }
        public string? CommentContent { get; init; }
        public string? CommentCreatorName { get; init; }
        public string? PostTitle { get; init; }
        public int? User_Id { get; init; }
        public int? Post_Id { get; init; }
    }
}
