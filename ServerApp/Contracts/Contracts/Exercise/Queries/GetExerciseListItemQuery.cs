namespace DTO.Contracts.Exercise.Queries
{
    public class GetExerciseListItemQuery
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
