namespace Domain
{
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sets { get; set; }
        public bool AllowExtraSet { get; set; }
        public ICollection<Statistic> Statistic { get; set; }
        public User User { get; set; }
    }
}
