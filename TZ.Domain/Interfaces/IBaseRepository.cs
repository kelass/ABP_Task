using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;

namespace TZ.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(ExperimentDto entity);
        Task<bool> DeleteAsync(Guid Id);
        Task<T> GetByIdAsync(Guid Id);
        Task<List<Experiment>> SelectAsync();
        Task<bool> UpdateAsync(ExperimentDto entity);

    }
}
