using System.Data.Linq.Mapping;

namespace M5P1CountriesFinal
{
    [Table(Name = "Countries")]
    internal class Country
    {
        [Column(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Capital { get; set; }

        [Column]
        public int NumberOfInhabitants { get; set; }

        [Column]
        public decimal Area { get; set; }

        [Column]
        public string PartOfTheWorld { get; set; }
    }
}
