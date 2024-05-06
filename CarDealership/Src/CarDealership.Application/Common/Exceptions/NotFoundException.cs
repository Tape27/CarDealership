namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
        : base($"{name} с {key} не найдено") { }
    }
}
