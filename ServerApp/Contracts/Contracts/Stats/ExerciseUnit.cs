namespace DTO.Contracts.Stats
{
    public class ExerciseUnit
    {
        public DateTime SessionDate { get; set; }
        public List<ExerciseSet> ExerciseSet { get; set; }
        public ExerciseSet? ExtraSet { get; set; }
    }

    public class ExerciseSet
    {
        public int Weight { get; set; }
        public string Reps { get; set; }
    }
}
