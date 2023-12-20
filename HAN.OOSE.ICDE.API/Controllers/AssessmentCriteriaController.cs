using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using HAN.OOSE.ICDE.Logic.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentCriteriaController : VersionedEntityController<AssessmentCriteria>
    {
        private readonly IAssessmentCriteriaManager _assessmentCriteriaManager;

        public AssessmentCriteriaController(
            ILogger<BaseEntityController<AssessmentCriteria>> logger, 
            IAssessmentCriteriaManager entityManager) : base(logger)
        {
            _assessmentCriteriaManager = entityManager;
        }

        [HttpDelete("{id:guid}")]
        public override async Task<ActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            await _assessmentCriteriaManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<AssessmentCriteria>> Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _assessmentCriteriaManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        public override async Task<ActionResult<List<AssessmentCriteria>>> GetAll()
        {
            var entities = await _assessmentCriteriaManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        public override async Task<ActionResult<List<AssessmentCriteria>>> GetByVersionId(Guid versionId)
        {
            if(versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _assessmentCriteriaManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpPost]
        public override async Task<ActionResult<AssessmentCriteria>> Post(AssessmentCriteria entity)
        {
            if(entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            var saved = await _assessmentCriteriaManager.SaveAsync(entity);
            if(saved == null)
            {
                return BadRequest("Saving went wrong"); 
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult<AssessmentCriteria>> Put(Guid id, AssessmentCriteria entity)
        {
            if(id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            if(entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            if(id != entity.Id)
            {
                return BadRequest(new ArgumentException("Id in URL not the same as in sent object"));
            }

            var updated = await _assessmentCriteriaManager.UpdateAsync(entity);
            if(updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
