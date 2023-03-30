using CsvHelper.Configuration.Attributes;

namespace TestCobbleStone.Models
{
    public class Pokemon
    {
        [Index(0)]
        public int Id { get; set; }
        [Index(1)]
        public string Name { get; set; }
        [Index(2)]
        public string Type1 { get; set; }
        [Index(3)]
        public string Type2 { get; set; }
        [Index(4)]
        public int Total { get; set; }
        [Index(5)]
        public int HP { get; set; }
        [Index(6)]
        public int Attack { get; set; }
        [Index(7)]
        public int Defense { get; set; }
        [Index(8)]
        public int SpeedAtack { get; set; }
        [Index(9)]
        public int SpeedDefence { get; set; }
        [Index(10)]
        public int Speed { get; set; }
        [Index(11)]
        public int Generation { get; set; }
        [Index(12)]
        public bool Legendary { get; set; }
    }
}
