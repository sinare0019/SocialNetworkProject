namespace SCN.Model.Post
{
    public record PostViewModel
    {
        public DateTime Date { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public string PostCreatorUser { get; init; }
        public int? Id { get; init; }
        public int? User_Id { get; init; }
        public int? DisLikeCount { get; init; }
        public int? LikeCount { get; init; }
        public int? CommentCount { get; init; }
    }
}
