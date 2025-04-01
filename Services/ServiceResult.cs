using System.Net;
using System.Text.Json.Serialization;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        [JsonIgnore] public bool IsSuccess => Errors != null || Errors?.Count == 0;

        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        // Static Factory Methods
        public static ServiceResult<T> Success(T data,HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>()
            {
                Data = data,
                Status = status
            };
        }
        public static ServiceResult<T> Fail(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                Errors = errors,
                Status = status

            };
        }
        public static ServiceResult<T> Fail(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>()
            {
                Errors = [error],
                Status = status

            };
        }
    }
    public class ServiceResult
    {
        public List<string>? Errors { get; set; }
        [JsonIgnore] public bool IsSuccess => Errors != null || Errors?.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        // Static Factory Methods
        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status
            };
        }
        public static ServiceResult Fail(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Errors = errors,
                Status = status

            };
        }
        public static ServiceResult Fail(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult()
            {
                Errors = [error],
                Status = status
            };
        }
    }
}
