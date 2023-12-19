namespace Builder;

public interface IBuildable<T>
{
    T Build();
}