namespace BMS.Models.Entities.Base
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}