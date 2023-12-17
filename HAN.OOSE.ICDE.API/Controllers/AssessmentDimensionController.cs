using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentDimensionController : VersionedEntityController<AssessmentDimension>
    {
        private readonly IAssessmentDimensionManager _assessmentDimensionManager;
        public AssessmentDimensionController(
            ILogger<BaseEntityController<AssessmentDimension>> logger, 
            IAssessmentDimensionManager entityManager) : base(logger)
        {
            _assessmentDimensionManager = entityManager;
        }

        [HttpDelete("{id:guid}")]
        public override async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            await _assessmentDimensionManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<AssessmentDimension>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _assessmentDimensionManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        public override async Task<ActionResult<List<AssessmentDimension>>> GetAll()
        {
            var entities = await _assessmentDimensionManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        public override async Task<ActionResult<List<AssessmentDimension>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _assessmentDimensionManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpPost]
        public override async Task<ActionResult<AssessmentDimension>> Post(AssessmentDimension entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            var saved = await _assessmentDimensionManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult<AssessmentDimension>> Put(Guid id, AssessmentDimension entity)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            if (id != entity.Id)
            {
                return BadRequest(new ArgumentException("Id in URL not the same as in sent object"));
            }

            var updated = await _assessmentDimensionManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
