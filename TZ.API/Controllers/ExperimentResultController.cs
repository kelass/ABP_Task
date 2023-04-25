using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Services;

namespace TZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperimentResultController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public ExperimentResultController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExperimentResult>>> Select()
        {
            List<ExperimentResult> select = await _unitOfWork.ExperimentResults.SelectAsync();
            return Ok(select);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ExperimentResult>> GetById(Guid Id)
        {
            ExperimentResult result = await _unitOfWork.ExperimentResults.GetByIdAsync(Id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create(ExperimentResultDto experiment)
        {
            bool result = await _unitOfWork.ExperimentResults.CreateAsync(experiment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(Guid Id)
        {
            bool result = await _unitOfWork.ExperimentResults.DeleteAsync(Id);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(ExperimentResultDto experiment)
        {
            bool result = await _unitOfWork.ExperimentResults.UpdateAsync(experiment);
            await _unitOfWork.SaveAsync();
            return Ok(result);
        }


    }
}
