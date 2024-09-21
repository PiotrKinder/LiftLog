namespace DTO.Contracts.Stats
{
    internal class GetTrainingModeData
    {
        public Guid ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string Icon { get; set; }
        public int Sets { get; set; }
        public bool AllowExtraSet { get; set; }
        public ExerciseUnit? LastSessionStats { get; set; }
    }
}
