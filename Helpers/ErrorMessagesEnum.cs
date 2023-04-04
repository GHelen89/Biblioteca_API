using Microsoft.Extensions.Options;

namespace Biblioteca_API.Helpers
{
    public class ErrorMessagesEnum
    {
        public const string NoElementFound = "No element found in tabel ";
        public const string StarEndDateError = "End date cannot be smaller than start date";
        public const string BadRequest = "Body is not correct";
    }
}
