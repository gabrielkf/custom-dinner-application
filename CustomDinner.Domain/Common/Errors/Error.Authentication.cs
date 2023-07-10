using ErrorOr;

namespace CustomDinner.Domain.Common.Errors;

public static partial class AppErrors
{
    public static class Authentication
    {
        public static Error InvalidCredentials = Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials");
    }
}
