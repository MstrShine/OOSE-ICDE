﻿using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningOutcomeController : VersionedEntityController<LearningOutcome>
    {
        private readonly ILearningOutcomeManager _learningOutcomeManager;

        public LearningOutcomeController(
            ILogger<BaseEntityController<LearningOutcome>> logger, 
            ILearningOutcomeManager entityManager) : base(logger)
        {
            _learningOutcomeManager = entityManager;
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            await _learningOutcomeManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public override async Task<ActionResult<LearningOutcome>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _learningOutcomeManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        [Authorize]
        public override async Task<ActionResult<List<LearningOutcome>>> GetAll()
        {
            var entities = await _learningOutcomeManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        [Authorize]
        public override async Task<ActionResult<List<LearningOutcome>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _learningOutcomeManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<LearningOutcome>> Post(LearningOutcome entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            var saved = await _learningOutcomeManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Teacher, Administrator")]
        public override async Task<ActionResult<LearningOutcome>> Put(Guid id, LearningOutcome entity)
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

            var updated = await _learningOutcomeManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
