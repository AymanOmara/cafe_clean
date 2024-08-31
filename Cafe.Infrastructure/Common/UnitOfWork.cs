using Cafe.Contracts.Core;
using Cafe.Contracts.Features.Authentication;
using Cafe.Domain.Features.User;
using Cafe.Infrastructure.Common.Authentication;
using Cafe.Infrastructure.Repositories;
using Cafe.Shared.Localization;
using Microsoft.AspNetCore.Identity;

namespace Cafe.Infrastructure.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RawaanDBContext _context;
        private readonly IJWTGenerator _jwtGenerator;
        private readonly UserManager<RawaanUser> _userManager;
        private readonly LanguageService _languageService;

        public IAuthenticationRepository Authentication { get; private set; }

        public UnitOfWork(
            RawaanDBContext context,
            IJWTGenerator jwtGenerator,
            UserManager<RawaanUser> userManager,
            LanguageService languageService)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
            _userManager = userManager;
            _languageService = languageService;

            InitRepositories();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private void InitRepositories()
        {
            Authentication = new AuthenticationRepository(_context, _jwtGenerator, _userManager, _languageService);
        }
    }
}