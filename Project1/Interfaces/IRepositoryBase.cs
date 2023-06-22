namespace Project1.Interfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        int Create(TEntity newEntity);
        int Update(TEntity newEntity);
    }
}
