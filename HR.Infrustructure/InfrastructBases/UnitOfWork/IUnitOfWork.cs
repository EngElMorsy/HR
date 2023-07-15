namespace HR.Infrustructure.InfrastructBases.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // IBaseRepositry<TD> TD {get;}

        int Compelete();
    }
}
