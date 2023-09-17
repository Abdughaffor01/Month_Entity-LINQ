namespace Domain;
public class Response<T>
{
    public string? Messege { get; set; }
    public T? Data { get; set; }
    public Response(T data) => Data = data;
    public Response(string messege) => Messege = messege;
}
