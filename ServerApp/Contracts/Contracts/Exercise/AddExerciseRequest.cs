﻿namespace DTO.Contracts.Exercise
{
    public class AddExerciseRequest
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sets { get; set; }
        public bool ExtraSet { get; set; }
    }
}
