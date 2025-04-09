// Interface de base
public interface IRepository<T> where T : class
{
    // Opérations de lecture
    IEnumerable<T> GetAll();
    T GetById(int id);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    // Opérations d'écriture
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    
    // Sauvegarde
    int SaveChanges();
}

// Class de base pour les repositories
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;

    public Repository(DbContext context) {
        _context = context;
    }

    public IEnumerable<T> GetAll(){
        return _context.Set<T>().ToList();
    }

    public T GetById(int id) {
        return _context.Set<T>().Find(id);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate) {
        return _context.Set<T>().Where(predicate).ToList();
    }

    public void Add(T entity) {
        _context.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities) {
    _context.Set<T>().AddRange(entities);
    }

    public void Update(T entity){
        _context.Set<T>().Update(entity);
    }

    public void Remove(T entity) {
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities) {
        _context.Set<T>().RemoveRange(entities);
    }

    public int SaveChanges() {
        return _context.SaveChanges();
    }
}