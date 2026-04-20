namespace WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

public interface IBaseRepository<T>
{
    public List<T> All();
    public T Get(Guid id);
    public void Post(T cliente);
    public void Update(T cliente);
    public void Delete(Guid id);
    public bool IsInDatabase(Guid id);
}