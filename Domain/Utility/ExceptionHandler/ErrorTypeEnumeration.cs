using System.Text.RegularExpressions;
using Domain.SeedWork.Resources;
using FluentValidation.Results;
using Microsoft.Extensions.Localization;

namespace Domain.Utility.ExceptionHandler;

public class ErrorTypeEnumeration
{
    public static readonly ErrorTypeEnumeration Unknown = new(nameof(Resource_Fa.Unknown));
    public static readonly ErrorTypeEnumeration NotFound = new(nameof(Resource_Fa.NotFound));

    public string Name { get; }
    public int ErrorCode { get; }
    public Dictionary<string, object> FormattedMessagePlaceholderValues { get; } = new Dictionary<string, object>();

    public ErrorTypeEnumeration(string name)
    {
        Name = name;
    }

    public ErrorTypeEnumeration(int errorCode, string name)
    {
        ErrorCode = errorCode;
        Name = name;
    }

    public ErrorTypeEnumeration(ValidationFailure validationFailure)
    {
        Name = string.IsNullOrWhiteSpace(validationFailure.ErrorCode)
            ? validationFailure.PropertyName
            : validationFailure.ErrorCode;
        ErrorCode = string.IsNullOrWhiteSpace(validationFailure.ErrorCode) ||
                    !int.TryParse(validationFailure.ErrorCode, out int _)
            ? 0
            : int.Parse(validationFailure.ErrorCode);
        FormattedMessagePlaceholderValues = validationFailure.FormattedMessagePlaceholderValues;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not ErrorTypeEnumeration item)
            return false;

        if (ReferenceEquals(this, item))
            return true;

        if (GetType() != item.GetType())
            return false;
        return item.Name == Name || item.ErrorCode == ErrorCode;
    }

    protected bool Equals(ErrorTypeEnumeration other)
    {
        return Name == other.Name && ErrorCode == other.ErrorCode &&
               FormattedMessagePlaceholderValues.Equals(other.FormattedMessagePlaceholderValues);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, ErrorCode, FormattedMessagePlaceholderValues);
    }

    public void AddToFormattedMessagePlaceholderValues(int index, object value)
    {
        if (FormattedMessagePlaceholderValues.ContainsKey(index.ToString()))
        {
            FormattedMessagePlaceholderValues.Remove(index.ToString());
        }

        FormattedMessagePlaceholderValues.Add(index.ToString(), value);
    }

    public string GetMessage(IStringLocalizer localizer)
    {
        if (!FormattedMessagePlaceholderValues.Any())
        {
            return localizer[Name];
        }

        string formattedMessage = localizer[Name];

        MatchCollection matchCollection = Regex.Matches(formattedMessage, "{[0-9]}");
        for (int i = 0; i < matchCollection.Count; ++i)
        {
            string trimmedKey = matchCollection[i].Value.Trim("{}".ToCharArray());

            if (FormattedMessagePlaceholderValues.TryGetValue(trimmedKey, out object? value))
            {
                formattedMessage = formattedMessage.Replace(matchCollection[i].Value,
                    value.ToString());
            }
        }

        return formattedMessage;
    }
}