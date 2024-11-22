namespace Tactical.Framework.Core.Abstractions
{
    public class Entity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
