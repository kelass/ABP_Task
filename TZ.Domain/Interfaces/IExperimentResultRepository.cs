using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;

namespace TZ.Domain.Interfaces
{
    public interface IExperimentResultRepository:IBaseRepository<ExperimentResult>
    {
        Task<bool> CreateAsync(ExperimentResultDto entity);
        Task<bool> UpdateAsync(ExperimentResultDto entity);
        Task<ExperimentResult> GetByDeviceTokenAsync(string DeviceToken);
    }
}
