using HAN.OOSE.ICDE.Domain;
using HAN.OOSE.ICDE.Logic.Interfaces.Managers;
using HAN.OOSE.ICDE.Logic.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAN.OOSE.ICDE.Logic.Validation
{
    public class GradeDescriptionValidation : AbstractEntityValidation<GradeDescription, IGradeDescriptionManager>
    {
        public GradeDescriptionValidation(IGradeDescriptionManager entityManager) : base(entityManager)
        {
        }

        public override Task<bool> ValidateEntity(Guid entityId)
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ValidateChildren(Guid parentId)
        {
            throw new NotImplementedException();
        }
    }
}
