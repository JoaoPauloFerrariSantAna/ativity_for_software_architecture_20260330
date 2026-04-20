using WorkFromSchool_20260408.BillingContext.Application.Domain.Entities;
using WorkFromSchool_20260408.BillingContext.Application.Domain.Interfaces;

namespace WorkFromSchool_20260408.BillingContext.Infrastructure.Repositories;

public class PixRepository : IBaseRepository<Pix>
{
    private static List<Pix> _pixs = new List<Pix>();

    public Pix Get(Guid id) { return _pixs.Find(p => id == p.Id); }

    public bool IsInDatabase(Guid id) { return (_pixs.Find(p => id == p.Id) != null); }

    public List<Pix> All() { return _pixs; }

    public void Delete(Guid id)
    {
        if (!IsInDatabase(id)) 
            throw new Exception("Pix does not exists");
        
        _pixs.Remove(Get(id));
    }

    public void Post(Pix pix)
    {
        if (pix == null)
            throw new Exception("Pix must be filled");
        
        if(IsInDatabase(pix.Id))
            throw new Exception("Pix already exists");
        
        _pixs.Add(pix);
    }

    public void Update(Pix pix)
    {
        Pix pixToUpdate = null;

        if (pix == null)
            throw new Exception("Pix must be filled");
        
        if (IsInDatabase(pix.Id))
            throw new Exception("Pix does not exists");
        
        pixToUpdate = Get(pix.Id);
        pixToUpdate = pix;
    }
}