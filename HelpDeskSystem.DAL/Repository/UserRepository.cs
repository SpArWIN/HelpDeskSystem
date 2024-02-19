using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpDeskSystem.DAL.Interfaces;
using HelpDeskSystem.Domain.Entity;

namespace HelpDeskSystem.DAL.Repository
{
    public class UserRepository : IBaseRepository<Users>
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Create(Users entity)
        {
            await _appDbContext.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public IQueryable<Users> GetAll()
        {
            return _appDbContext.Users;
        }

        public async Task Delete(Users entity)
        {
            _appDbContext.Users.Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Users> Update(Users entity)
        {
            _appDbContext.Users.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
