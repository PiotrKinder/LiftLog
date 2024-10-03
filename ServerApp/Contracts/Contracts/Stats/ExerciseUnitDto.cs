namespace DTO.Contracts.Stats
{
    public class ExerciseUnitDto
    {
        public DateTime SessionDate { get; set; }
        public List<ExerciseSet> ExerciseSet { get; set; }
        public ExerciseSet? ExtraSet { get; set; }
    }
}
