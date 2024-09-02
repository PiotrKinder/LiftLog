namespace Domain
{
    public class Statistic
    {
        public Guid Id { get; set; }
        public string DataStat { get; set; }

        public Exercise Exercise { get; set; }
        public User User { get; set; }

    }
}
