using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationEventController : VersionedEntityController<ExaminationEvent>
    {
        private readonly IExaminationEventManager _entityManager;

        public ExaminationEventController(
            ILogger<BaseEntityController<ExaminationEvent>> logger, 
            IExaminationEventManager entityManager) : base(logger)
        {
            _entityManager = entityManager;
        }

        [HttpDelete("{id:guid}")]
        public override async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            await _entityManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<ExaminationEvent>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _entityManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        public override async Task<ActionResult<List<ExaminationEvent>>> GetAll()
        {
            var entities = await _entityManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        public override async Task<ActionResult<List<ExaminationEvent>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _entityManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpPost]
        public override async Task<ActionResult<ExaminationEvent>> Post(ExaminationEvent entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            var saved = await _entityManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult<ExaminationEvent>> Put(Guid id, ExaminationEvent entity)
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

            var updated = await _entityManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
