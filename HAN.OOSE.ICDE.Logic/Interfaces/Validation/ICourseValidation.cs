namespace HAN.OOSE.ICDE.Logic.Interfaces.Validation
{
    public interface ICourseValidation
    {
        Task<bool> ValidateCourse(Guid courseId);
    }
}
