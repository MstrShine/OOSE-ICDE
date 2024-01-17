using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : VersionedEntityController<Course>
    {
        private readonly ICourseManager _courseManager;
        private readonly ICompetencyManager _competencyManager;
        private readonly ICoursePlanningManager _coursePlanningManager;
        private readonly ILearningOutcomeUnitManager _learningOutcomeUnitManager;

        public CourseController(
            ILogger<BaseEntityController<Course>> logger,
            ICourseManager entityManager,
            ICompetencyManager competencyManager,
            ICoursePlanningManager coursePlanningManager,
            ILearningOutcomeUnitManager learningOutcomeUnitManager) : base(logger)
        {
            _courseManager = entityManager;
            _competencyManager = competencyManager;
            _coursePlanningManager = coursePlanningManager;
            _learningOutcomeUnitManager = learningOutcomeUnitManager;
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            await _courseManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public override async Task<ActionResult<Course>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _courseManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        [Authorize]
        public override async Task<ActionResult<List<Course>>> GetAll()
        {
            var entities = await _courseManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        [Authorize]
        public override async Task<ActionResult<List<Course>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _courseManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpGet("{id:guid}/competency")]
        [Authorize]
        public async Task<ActionResult<List<Competency>>> GetCompetenciesByCourseId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var competencies = await _competencyManager.GetByCourseIdAsync(id);

            return Ok(competencies);
        }

        [HttpGet("{id:guid}/courseplanning")]
        [Authorize]
        public async Task<ActionResult<CoursePlanning>> GetCoursePlanningByCourseId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var coursePlanning = await _coursePlanningManager.GetByCourseIdAsync(id);

            return Ok(coursePlanning);
        }

        [HttpGet("{id:guid}/learningoutcomeunit")]
        [Authorize]
        public async Task<ActionResult<List<LearningOutcomeUnit>>> GetLearningOutcomeUnitsByCourseId(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var learningOutcomes = await _learningOutcomeUnitManager.GetByCourseIdAsync(id);

            return Ok(learningOutcomes);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<Course>> Post(Course entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            entity.Author = UserId;

            var saved = await _courseManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<Course>> Put(Guid id, Course entity)
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

            if (entity.Author == Guid.Empty)
                entity.Author = UserId;

            var updated = await _courseManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
