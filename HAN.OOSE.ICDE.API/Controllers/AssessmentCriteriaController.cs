using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    public class AssessmentCriteriaController : VersionedEntityController<AssessmentCriteria>
    {
        public AssessmentCriteriaController(
            ILogger<BaseEntityController<AssessmentCriteria>> logger, 
            IVersionedEntityManager<AssessmentCriteria> entityManager) : base(logger, entityManager)
        {
        }

        [HttpDelete("{id:guid}")]
        public override Task<ActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}")]
        public override Task<ActionResult<AssessmentCriteria>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public override Task<ActionResult<List<AssessmentCriteria>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("version/{versionId:guid}")]
        public override Task<ActionResult<List<AssessmentCriteria>>> GetByVersionId(Guid versionId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public override Task<ActionResult<AssessmentCriteria>> Post(AssessmentCriteria entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:guid}")]
        public override Task<ActionResult<AssessmentCriteria>> Put(Guid id, AssessmentCriteria entity)
        {
            throw new NotImplementedException();
        }
    }
}
