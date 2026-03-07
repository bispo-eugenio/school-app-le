namespace schoolApp.Types;

public interface IFormatter<T>
{
    T Format(T value);
}
