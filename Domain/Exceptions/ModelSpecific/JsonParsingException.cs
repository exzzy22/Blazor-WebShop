namespace Domain.Exceptions.ModelSpecific;

public class JsonParsingException : Exception
{
    public JsonParsingException(string message) : base(message) { }
}
