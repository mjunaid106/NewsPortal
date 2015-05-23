namespace NewsPortal.Domain.Responses
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }

        public static ArticlePublishResponse SuccessResponse()
        {
            return new ArticlePublishResponse { Success = true };
        }

        public static ArticlePublishResponse FailureResponse()
        {
            return new ArticlePublishResponse { Success = false };
        }
    }
}
