using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;

namespace TZ.Domain.Interfaces
{
    public interface IExperimentRepository:IBaseRepository<Experiment>
    {
        Task<bool> CreateAsync(ExperimentDto entity);
        Task<bool> UpdateAsync(ExperimentDto entity);
    }
}
