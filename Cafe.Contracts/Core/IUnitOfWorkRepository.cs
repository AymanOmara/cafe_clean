using Cafe.Contracts.Features.Authentication;
using Cafe.Contracts.Features.Employee;

namespace Cafe.Contracts.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IAuthenticationRepository Authentication { get; }

        public IEmployeeRepository Employees { get; }
        
        Task SaveChangesAsync();
    }
}