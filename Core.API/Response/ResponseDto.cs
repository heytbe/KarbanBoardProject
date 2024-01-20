namespace Core.API.Response
{
    public class ResponseDto<T>
    {

        public T Data { get; set; }
        public ErrorDto Error { get; set; }
        public int StatusCode { get; set; }
        public Response Response { get; set; }

        public static ResponseDto<T> Success(T data,int statusCode,Response response = null)
        {
            return new ResponseDto<T>
            {
                Data = data,
                StatusCode = statusCode,
                Response = response
            };
        }

        public static ResponseDto<T> Success(string message,int statusCode)
        {
            var response = new Response(message);
            return new ResponseDto<T>
            {
                Response = response,
                StatusCode = statusCode

            };
        }

        public static ResponseDto<T> Fail(ErrorDto error,int statusCode)
        {
            return new ResponseDto<T>
            {
               Error = error,
               StatusCode = statusCode
            };
        }

        public static ResponseDto<T> Fail(string message,int statusCode,bool isShow)
        {
            var error = new ErrorDto(message, isShow);
            return new ResponseDto<T>
            {
               Error = error,
               StatusCode = statusCode
            };
        }

    }
}
