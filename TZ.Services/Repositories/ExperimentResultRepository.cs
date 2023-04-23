using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Data;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Domain.Interfaces;

namespace TZ.Services.Repositories
{
    public class ExperimentResultRepository : IExperimentResultRepository
    {
        public List<string> colors = new List<string> { "#FF0000", "#00FF00", "#0000FF" };

        private readonly ApplicationDbContext _context;
        public ExperimentResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateAsync(ExperimentResultDto entity)
        {  
            ExperimentResult experiment = await GetByIdAsync(entity.Id);
            int i = 0;
            Experiment exp = await _context.Experiments.FirstOrDefaultAsync(e=>e.Id == entity.ExperimentId); //Check of experiment, get name and Id of experiment
               
                if (experiment != null)
                {
                if (exp.Name == "button_color") 
                {
                    entity.Value = colors[i];
                    ExperimentResult model = new ExperimentResult { DeviceToken = entity.DeviceToken, Id = entity.Id, Key = exp.Name, Value = entity.Value };

                    //Checking if a number is out of list
                    var CheckNumber = i<=colors.Count() ? i++ : i=0;
                    await _context.AddAsync(model);
                }
                else
                {
                    //I didn't guess how to do it faster :(
                    Random random = new Random();
                    var number = random.Next(0, 100);
                    if (number <= 75)
                        entity.Value = 10.ToString();
                    else if (number > 75 && number <= 85)
                        entity.Value = 20.ToString();
                    else if (number > 85 && number <= 90)
                        entity.Value = 50.ToString();
                    else if (number > 90)
                        entity.Value = 5.ToString();

                    ExperimentResult model = new ExperimentResult { DeviceToken = entity.DeviceToken, Id = entity.Id, Key = exp.Name, Value = entity.Value };
                    await _context.AddAsync(model);
                }
                    
                    return true;
                }   
                return false;
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            ExperimentResult? experiment = await _context.ExperimentResults.FirstOrDefaultAsync(e => e.Id == Id);
                
            if (experiment != null) 
            {
                _context.Remove(experiment);
                return true; 
            }
            return false;
        }

        public async Task<ExperimentResult> GetByIdAsync(Guid Id)
        {
            ExperimentResult? experiment = await _context.ExperimentResults.FirstOrDefaultAsync(e => e.Id == Id);
            
            return experiment;
        }

        public async Task<List<ExperimentResult>> SelectAsync()
        {
            List<ExperimentResult> experiments = await _context.ExperimentResults.ToListAsync();
            return experiments;
        }

        public async Task<bool> UpdateAsync(ExperimentResultDto entity)
        {
            ExperimentResult? experiment = await _context.ExperimentResults.FirstOrDefaultAsync(e=>e.Id == entity.Id);
            if (experiment != null)
            {
                experiment.DeviceToken = entity.DeviceToken;
                experiment.Key = entity.Key;
                experiment.Value = entity.Value;
                _context.Update(experiment);
                return true;
            }
            return false;
        }
    }
}
