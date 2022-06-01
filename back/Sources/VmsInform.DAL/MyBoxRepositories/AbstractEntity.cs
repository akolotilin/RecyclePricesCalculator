namespace VmsInform.DAL.MyBoxRepositories
{
    public abstract class AbstractEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
