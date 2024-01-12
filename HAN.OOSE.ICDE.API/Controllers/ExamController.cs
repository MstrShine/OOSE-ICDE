using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : VersionedEntityController<Exam>
    {
        private readonly IExamManager _entityManager;
        private readonly IAssessmentDimensionManager _assessmentDimensionManager;
        private readonly IExaminationEventManager _examinationEventManager;
        private readonly ILearningOutcomeManager _learningOutcomeManager;

        public ExamController(
            ILogger<BaseEntityController<Exam>> logger,
            IExamManager entityManager,
            IAssessmentDimensionManager assessmentDimensionManager,
            IExaminationEventManager examinationEventManager,
            ILearningOutcomeManager learningOutcomeManager) : base(logger)
        {
            _entityManager = entityManager;
            _assessmentDimensionManager = assessmentDimensionManager;
            _examinationEventManager = examinationEventManager;
            _learningOutcomeManager = learningOutcomeManager;
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
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
        [Authorize]
        public override async Task<ActionResult<Exam>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _entityManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        [Authorize]
        public override async Task<ActionResult<List<Exam>>> GetAll()
        {
            var entities = await _entityManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        [Authorize]
        public override async Task<ActionResult<List<Exam>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _entityManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpGet("{id:guid}/assessmentdimension")]
        [Authorize]
        public async Task<ActionResult<List<AssessmentDimension>>> GetAssessmentDimensionsByExamId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var dimensions = await _assessmentDimensionManager.GetByExamIdAsync(id);

            return Ok(dimensions);
        }

        [HttpGet("{id:guid}/examinationevent")]
        [Authorize]
        public async Task<ActionResult<List<ExaminationEvent>>> GetExaminationEventsByExamId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var examinationEvents = await _examinationEventManager.GetByExamIdAsync(id);

            return Ok(examinationEvents);
        }

        [HttpGet("{id:guid}/learningoutcome")]
        [Authorize]
        public async Task<ActionResult<List<LearningOutcome>>> GetLearningOutcomesByExamId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var learningOutcomes = await _learningOutcomeManager.GetByExamIdAsync(id);

            return Ok(learningOutcomes);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<Exam>> Post(Exam entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            entity.Author = UserId;

            var saved = await _entityManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<Exam>> Put(Guid id, Exam entity)
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

            entity.Author = UserId;

            var updated = await _entityManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
