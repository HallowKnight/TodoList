using FluentValidation;
using FluentValidation.Results;

namespace Domain.Utility.ExceptionHandler;

public static class ExceptionHandler
{
    public static ErrorTypeEnumeration? GetError(System.Exception? e)
    {
        if (e?.InnerException is not ValidationException error)
        {
            return null;
        }

        return error.Errors == null || !error.Errors.Any()
            ? null
            : error.Errors.Select(validationFailure => new ErrorTypeEnumeration(validationFailure)).FirstOrDefault();
    }
    
    public static List<ErrorTypeEnumeration>? GetErrorList(System.Exception? e)
    {
        if (e?.InnerException is not ValidationException error)
        {
            return null;
        }

        return error.Errors == null || !error.Errors.Any()
            ? null
            : error.Errors.Select(validationFailure => new ErrorTypeEnumeration(validationFailure)).ToList();
    }

    public static List<ValidationFailure>? GetInnerExceptionValidationFailureList(System.Exception? e)
    {
        if (e?.InnerException is not ValidationException error)
        {
            return null;
        }

        return error.Errors == null || !error.Errors.Any() ? null : error.Errors.ToList();
    }

    public static System.Exception GetException(ErrorTypeEnumeration error)
    {
        return GetExceptions(new List<ErrorTypeEnumeration> { error });
    }

    private static System.Exception GetExceptions(IEnumerable<ErrorTypeEnumeration> errorList)
    {
        List<ValidationFailure> validationFailureList = errorList.Select(error =>
        {
            ValidationFailure validationFailure = new ValidationFailure(error.Name, string.Empty)
            {
                ErrorCode = error.ErrorCode != 0 ? error.ErrorCode.ToString() : string.Empty,
                FormattedMessagePlaceholderValues = error.FormattedMessagePlaceholderValues
            };

            return validationFailure;
        }).ToList();

        System.Exception exception = new System.Exception("an error occured!",
            new ValidationException("Validation exception", validationFailureList));

        return exception;
    }

}