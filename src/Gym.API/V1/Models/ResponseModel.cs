namespace Gym.API.V1.Models
{
    public class ResponseModel<T>
        where T : class
    {
        public T Values { get; set; }
    }
}
