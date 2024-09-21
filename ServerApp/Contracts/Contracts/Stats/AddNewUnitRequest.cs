namespace DTO.Contracts.Stats
{
    public class AddNewUnitRequest
    {
        public Guid exerciseId { get; set; }
        public ExerciseUnit exerciseUnit { get; set; }
    }
}
