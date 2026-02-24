namespace schoolApp.Types;

public interface IValidator<T>
{
    bool IsValid(T value);
}
