namespace SCN.Model;

public class Result<T>
{
   // public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
}

