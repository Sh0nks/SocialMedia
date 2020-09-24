using SocialMedia.Core.Collections;
namespace SocialMedia.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public Metadata meta { get; set; }

        public ApiResponse(T data)
        {
            Data = data;
        }
        
    }
}