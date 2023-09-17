using System.Net;
namespace Domain;
public class Response<T>
{
    public string? Messege { get; set; } = null;
    public T Data { get; set; }
    public Response(T data)=>Data = data;
    public Response(string messege)=>Messege = messege;
    public Response(string messege,T data) { 
        Messege = messege;
        Data = data;
    }
}
