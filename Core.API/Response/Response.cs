namespace Core.API.Response
{
    public class Response
    {
        public string Message { get; set; }
        public int Count { get; set; }

        public Response(string message)
        {
            Message = message;
        }

        public Response(int count)
        {
            Count = count;
        }
    }
}
