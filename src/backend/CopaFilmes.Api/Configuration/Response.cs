using System.Net;
using Newtonsoft.Json;

namespace CopaFilmes.Api.Configuration
{
  public class Response<T>
  {
    [JsonConstructor]
    public Response(){}
    public Response(HttpStatusCode httpStatusCode, string message)
    {
      Message = message;
      HttpStatusCode = httpStatusCode;
    }
    public Response(HttpStatusCode httpStatusCode, string message, T data)
    {
      Message = message;
      HttpStatusCode = httpStatusCode;
      Data = data;
    }

    [JsonProperty("message")]
    public string Message { get; set; }
    [JsonIgnore]
    public HttpStatusCode HttpStatusCode { get; set; }
    [JsonProperty("data")]
    public T Data { get; set; }
    [JsonProperty("status")]
    public bool Status { get; }
  }
}