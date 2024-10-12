using Microsoft.AspNetCore.Mvc;
using dot_net_assessment.Interfaces;
using dot_net_assessment.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace dot_net_assessment.Controllers
{
    [Route("api/manufacturing-processes")]
    [ApiController]
    [Authorize]
    public class ManufacturingProcessController : ControllerBase
    {
        private readonly IManufacturingProcessRepository _manufacturingProcessRepository;
        public ManufacturingProcessController(IManufacturingProcessRepository manufacturingProcessRepository)
        {
            _manufacturingProcessRepository = manufacturingProcessRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var manufactoringProcesses = await _manufacturingProcessRepository.GetAllAsync();

            return Ok(manufactoringProcesses);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetOneById([FromRoute]  Guid id)
        {
            var manufacturingProcess = await _manufacturingProcessRepository.GetByIdAsync(id);

            if (manufacturingProcess == null)
            {
                return NotFound();
            }

            return Ok(manufacturingProcess.ToManufacturingProcessDto());
        }
    }
}
