namespace Biblioteca_API.Model
{
    public class ModelValidationException :Exception
    {
        public ModelValidationException(string? messages) : base(messages) {  }
    }
}
