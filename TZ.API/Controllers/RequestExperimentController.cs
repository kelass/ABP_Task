using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TZ.Domain.DbModels;
using TZ.Domain.DtoModels;
using TZ.Services;

namespace TZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestExperimentController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public RequestExperimentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<ExperimentResult>> Experiment([FromQuery] ExperimentResultDto entity)
        {
            var experiment = await _unitOfWork.ExperimentResults.CreateAsync(entity);
            await _unitOfWork.SaveAsync();

            //Get entity by deviceToken
            var model = await _unitOfWork.ExperimentResults.GetByDeviceTokenAsync(entity.DeviceToken);
             return Ok(model.Value);
        }
    }
}
