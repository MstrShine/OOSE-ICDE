using HAN.OOSE.ICDE.API.Controllers.Base;
using HAN.OOSE.ICDE.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HAN.OOSE.ICDE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyController : BaseEntityController<Study>
    {
        public StudyController(ILogger<BaseEntityController<Study>> logger) : base(logger)
        {
        }

        public override Task<ActionResult> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Study>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<List<Study>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Study>> Post(Study entity)
        {
            throw new NotImplementedException();
        }

        public override Task<ActionResult<Study>> Put(Guid id, Study entity)
        {
            throw new NotImplementedException();
        }
    }
}
