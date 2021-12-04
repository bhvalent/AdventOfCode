using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace AdventOfCode.Solution.Helpers
{
    public class CsvHelperWrapper : ICsvHelperWrapper
    {
        public List<T> GetRecords<T>(StreamReader reader)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                
            };

             using (var csv = new CsvReader(reader, config))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}