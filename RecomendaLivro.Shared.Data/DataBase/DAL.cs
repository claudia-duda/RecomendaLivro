namespace RecomendaLivro.Shared.Data.DataBase;
public class DAL<T> where T : class
{
    private readonly AppDbContext context;

    public DAL(AppDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<T> List()
    {
        return context.Set<T>().ToList();
    }
    public void Add(T TObject)
    {
        context.Set<T>().Add(TObject);
        context.SaveChanges();
    }
    public void Update(T TObject)
    {
        context.Set<T>().Update(TObject);
        context.SaveChanges();
    }
    public void Delete(T TObject)
    {
        context.Set<T>().Remove(TObject);
        context.SaveChanges();
    }

    public T? RecoverBy(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }
}
