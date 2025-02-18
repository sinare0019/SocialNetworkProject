using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.Model.Reaction
{
    public record ReactionViewModel
    {
        public int Id { get; init; }
        public DateTime Date { get; init; }
        public int Post_Id { get; init; }
        public int User_Id { get; init; }
        public short ReactionType { get; init; }
    }
}
