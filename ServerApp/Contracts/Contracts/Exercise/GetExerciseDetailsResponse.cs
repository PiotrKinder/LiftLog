using DTO.Contracts.Stats;

namespace DTO.Contracts.Exercise
{
    public class GetExerciseDetailsResponse
    {
        public Guid ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string Icon { get; set; }
        public List<ExerciseUnit> ExerciseUnits { get; set; }

    }
}
