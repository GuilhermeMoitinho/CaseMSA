using CaseMSA.Domain.Interfaces;
using CaseMSA.Infrastructure.Context;

namespace CaseMSA.Infrastructure.Repositories
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly AppDbcontext _context;

        public UnityOfWork(AppDbcontext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
