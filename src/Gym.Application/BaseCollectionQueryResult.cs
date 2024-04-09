namespace Gym.Application;

public class BaseCollectionQueryResult<T>
{
    public IEnumerable<T> Result { get; set; }

    public long TotalCount { get; set; }
}