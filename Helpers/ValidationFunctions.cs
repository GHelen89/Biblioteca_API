using Biblioteca_API.Model;
using System.Runtime.Serialization;

namespace Biblioteca_API.Helpers
{
    public class ValidationFunctions
    {
        public static void ExceptionsWhenDateIsNotValid(DateTime? start,DateTime? end)
        {
            if (start.HasValue && end.HasValue && start > end)
            {
                throw new ModelValidationException(ErrorMessagesEnum.StarEndDateError);
            }
        }
    }
}
