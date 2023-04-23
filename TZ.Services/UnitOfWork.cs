using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Data;
using TZ.Domain.DbModels;
using TZ.Domain.Interfaces;
using TZ.Services.Repositories;

namespace TZ.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private ExperimentRepository _experimentRepository;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IBaseRepository<Experiment> Experiments
        {
            get
            {
                return _experimentRepository = _experimentRepository ?? new ExperimentRepository(_context);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
