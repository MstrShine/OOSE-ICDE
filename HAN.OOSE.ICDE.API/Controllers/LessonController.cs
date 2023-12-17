﻿using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : VersionedEntityController<Lesson>
    {
        private readonly ILessonManager _lessonManager;

        public LessonController(
            ILogger<BaseEntityController<Lesson>> logger, 
            ILessonManager entityManager) : base(logger)
        {
            _lessonManager = entityManager;
        }

        [HttpDelete("{id:guid}")]
        public override async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            await _lessonManager.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("{id:guid}")]
        public override async Task<ActionResult<Lesson>> Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(id)));
            }

            var entities = await _lessonManager.GetByIdAsync(id);

            return Ok(entities);
        }

        [HttpGet]
        public override async Task<ActionResult<List<Lesson>>> GetAll()
        {
            var entities = await _lessonManager.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("version/{versionId:guid}")]
        public override async Task<ActionResult<List<Lesson>>> GetByVersionId(Guid versionId)
        {
            if (versionId == Guid.Empty)
            {
                return BadRequest(new ArgumentNullException(nameof(versionId)));
            }

            var entities = await _lessonManager.GetByVersionIdAsync(versionId);

            return Ok(entities);
        }

        [HttpPost]
        public override async Task<ActionResult<Lesson>> Post(Lesson entity)
        {
            if (entity == null)
            {
                return BadRequest(new ArgumentNullException(nameof(entity)));
            }

            var saved = await _lessonManager.SaveAsync(entity);
            if (saved == null)
            {
                return BadRequest("Saving went wrong");
            }

            return Ok(saved);
        }

        [HttpPut("{id:guid}")]
        public override async Task<ActionResult<Lesson>> Put(Guid id, Lesson entity)
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

            var updated = await _lessonManager.UpdateAsync(entity);
            if (updated == null)
            {
                return BadRequest(new ArgumentException("Updating went wrong"));
            }

            return Ok(updated);
        }
    }
}
