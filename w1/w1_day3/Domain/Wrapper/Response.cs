namespace Domain;

public class Response<T>
{
    public string Messege { get; set; }
    public T Data { get; set; }
    public Response(string messege) => Messege = messege;
    public Response(T data) => Data = data;
}
