using Cafe.Contracts.Features.Authentication;

namespace Cafe.Contracts.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IAuthenticationRepository Authentication { get; }

        Task SaveChangesAsync();
    }
}