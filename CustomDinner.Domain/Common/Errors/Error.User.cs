using ErrorOr;

namespace CustomDinner.Domain.Common.Errors;

public static partial class AppErrors
{
    public static class User
    {
        public static Error DuplicateEmail = Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email has already been registered");
    } 
}