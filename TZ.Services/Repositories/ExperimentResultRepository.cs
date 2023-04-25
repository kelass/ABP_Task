using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
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
            
            Experiment exp = await _context.Experiments.FirstOrDefaultAsync(e=>e.Id == entity.ExperimentId); //Check of experiment, get name and Id of experiment
            ExperimentResult token = await _context.ExperimentResults.FirstOrDefaultAsync(e => e.DeviceToken == entity.DeviceToken); //Check of experimentresults token, that the user does not pass the experiment 2 times

            if (experiment == null && token == null)
            {
                Random random = new Random();
                if (exp.Name == "button_color") 
                {
                    //I didn't guess how to do it faster and correctly :(
                    var number = random.NextInt64(0, 100);
                    if(number <= 33.3)
                    entity.Value = colors[0];
                    else if(number >=33.4 && number<=66.7)
                        entity.Value = colors[1];
                    else if (number >= 66.8)
                        entity.Value = colors[2];
                    
                    ExperimentResult model = new ExperimentResult { DeviceToken = entity.DeviceToken, Id = entity.Id, Key = exp.Name, Value = entity.Value, Experiment = exp };
                    await _context.AddAsync(model);
                }
                else
                {
                    //I didn't guess how to do it faster and correctly :(
                    var number = random.Next(0, 100);
                    if (number <= 75)
                        entity.Value = 10.ToString();
                    else if (number > 75 && number <= 85)
                        entity.Value = 20.ToString();
                    else if (number > 85 && number <= 90)
                        entity.Value = 50.ToString();
                    else if (number > 90)
                        entity.Value = 5.ToString();

                    ExperimentResult model = new ExperimentResult { DeviceToken = entity.DeviceToken, Id = entity.Id, Key = exp.Name, Value = entity.Value, Experiment=exp };
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

        public async Task<ExperimentResult> GetByDeviceTokenAsync(string DeviceToken)
        {
            ExperimentResult? experiment = await _context.ExperimentResults.FirstOrDefaultAsync(e => e.DeviceToken == DeviceToken);

            return experiment;
        }
        public async Task<List<ExperimentResult>> SelectAsync()
        {
            List<ExperimentResult> experiments = await _context.ExperimentResults.ToListAsync();
            return experiments;
        }
        public async Task<List<ExperimentResult>> GetByValueAsync(string Key)
        {
            List<ExperimentResult> experiments = await _context.ExperimentResults.Where(e=>e.Key==Key).ToListAsync();
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
