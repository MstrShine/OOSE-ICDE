using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningOutcomeUnitController : VersionedEntityController<LearningOutcomeUnit>
    {
        private readonly ILearningOutcomeUnitManager _learningOutcomeUnitManager;
        private readonly ICompetencyManager _competencyManager;
        private readonly IExamManager _examManager;
        private readonly ILearningOutcomeManager _learningOutcomeManager;

        public LearningOutcomeUnitController(
            ILogger<BaseEntityController<LearningOutcomeUnit>> logger,
            ILearningOutcomeUnitManager entityManager,
            ICompetencyManager competencyManager,
            IExamManager examManager,
            ILearningOutcomeManager learningOutcomeManager) : base(logger)
        {
            _learningOutcomeUnitManager = entityManager;
            _competencyManager = competencyManager;
            _examManager = examManager;
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

            await _learningOutcomeUnitManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public override async Task<ActionResult<LearningOutcomeUnit>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _learningOutcomeUnitManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        [Authorize]
        public override async Task<ActionResult<List<LearningOutcomeUnit>>> GetAll()
        {
            var entities = await _learningOutcomeUnitManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        [Authorize]
        public override async Task<ActionResult<List<LearningOutcomeUnit>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _learningOutcomeUnitManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpGet("{id:guid}/competency")]
        [Authorize]
        public async Task<ActionResult<List<Competency>>> GetCompetenciesByLearningOutcomeUnitId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var competencies = await _competencyManager.GetByLearningOutcomeUnitIdAsync(id);

            return Ok(competencies);
        }

        [HttpGet("{id:guid}/exam")]
        [Authorize]
        public async Task<ActionResult<List<Exam>>> GetExamsByLearningOutcomeUnitId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var exams = await _examManager.GetByLearningOutcomeUnitIdAsync(id);

            return Ok(exams);
        }

        [HttpGet("{id:guid}/learningoutcome")]
        [Authorize]
        public async Task<ActionResult<List<LearningOutcome>>> GetLearningOutcomesByLearningOutcomeUnitId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var learningOutcomes = await _learningOutcomeManager.GetByLearningOutcomeUnitIdAsync(id);

            return Ok(learningOutcomes);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<LearningOutcomeUnit>> Post(LearningOutcomeUnit entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            var saved = await _learningOutcomeUnitManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<LearningOutcomeUnit>> Put(Guid id, LearningOutcomeUnit entity)
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

            var updated = await _learningOutcomeUnitManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
