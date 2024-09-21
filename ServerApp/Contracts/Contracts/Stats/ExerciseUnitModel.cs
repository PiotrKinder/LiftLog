namespace DTO.Contracts.Stats
{
    public class ExerciseUnitModel
    {
        public Guid Id { get; set; }
        public DateTime SessionDate { get; set; }
        public List<ExerciseSet> ExerciseSet { get; set; }
        public ExerciseSet? ExtraSet { get; set; }
    }
}
