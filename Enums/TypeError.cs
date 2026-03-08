namespace TestBookApi.Enums;

public enum TypeError
{
    None = 0,
    ValidationError,
    InvalidCredential,
    Forbidden,
    NotFound,
    InternalError,
    Conflict
}
