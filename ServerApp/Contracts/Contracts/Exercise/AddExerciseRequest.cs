namespace DTO.Contracts.Exercise
{
    public class AddExerciseRequest
    {
        public string name { get; set; }
        public string icon { get; set; }
        public int sets { get; set; }
        public bool extraSet { get; set; }
    }
}
