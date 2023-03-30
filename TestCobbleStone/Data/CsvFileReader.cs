using CsvHelper;
using System.Globalization;
using TestCobbleStone.Models;

namespace TestCobbleStone.Data
{
    public static class CsvFileReader
    {
        public static List<Pokemon> GetPokemons(string filePath)
        {
            //Logic from CSV Helper
            using var reader = new StreamReader(filePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Pokemon>();
            return records.ToList();
        }
    }
}
