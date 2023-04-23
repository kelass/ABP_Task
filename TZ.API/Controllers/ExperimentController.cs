using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Services;

namespace TZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ExperimentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Experiment>>> Select()
        {
            List<Experiment> select = await _unitOfWork.Experiments.SelectAsync();
            return Ok(select);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Experiment>> GetById(Guid Id)
        {
            Experiment result = await _unitOfWork.Experiments.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(ExperimentDto experiment)
        {
            bool result = await _unitOfWork.Experiments.CreateAsync(experiment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(Guid Id)
        {
            bool result = await _unitOfWork.Experiments.DeleteAsync(Id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(ExperimentDto experiment)
        {
            bool result = await _unitOfWork.Experiments.UpdateAsync(experiment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

    }
}
