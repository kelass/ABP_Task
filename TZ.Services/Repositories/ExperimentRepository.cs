using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Data;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Domain.Interfaces;

namespace TZ.Services.Repositories
{
    public class ExperimentRepository : IExperimentRepository
    {
        private readonly ApplicationDbContext _context;
        public ExperimentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(ExperimentDto entity)
        {
            Experiment experiment = await GetByIdAsync(entity.Id);

            if (experiment == null)
            {
                
                Experiment model = new Experiment {Id = entity.Id, Name = entity.Name };
                await _context.AddAsync(model);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            Experiment? experiment = await _context.Experiments.FirstOrDefaultAsync(e => e.Id == Id);

            if (experiment != null)
            {
                _context.Remove(experiment);
                return true;
            }
            return false;
        }

        public async Task<Experiment> GetByIdAsync(Guid Id)
        {
            Experiment? experiment = await _context.Experiments.FirstOrDefaultAsync(e => e.Id == Id);

            return experiment;
        }

        public async Task<List<Experiment>> SelectAsync()
        {
            List<Experiment> experiments = await _context.Experiments.ToListAsync();
            return experiments;
        }

        public async Task<bool> UpdateAsync(ExperimentDto entity)
        {
            Experiment? experiment = await _context.Experiments.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (experiment != null)
            {
                experiment.Name = entity.Name;
                _context.Update(experiment);
                return true;
            }
            return false;
        }
    }
}
