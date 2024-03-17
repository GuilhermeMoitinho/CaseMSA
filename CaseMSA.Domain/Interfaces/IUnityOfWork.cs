namespace CaseMSA.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        Task CommitAsync();
    }
}
