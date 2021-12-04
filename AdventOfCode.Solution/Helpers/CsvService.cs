using System.Globalization;

namespace AdventOfCode.Solution.Helpers
{
    public class CsvService : ICsvService
    {
        private readonly ICsvHelperWrapper _csvWrapper;

        public CsvService(ICsvHelperWrapper csvWrapper)
        {
            _csvWrapper = csvWrapper ?? throw new ArgumentNullException(nameof(csvWrapper));
        }

        public List<T> GetListOf<T>(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath)) throw new ArgumentNullException(nameof(filepath));
            var contents = new List<T>();

            using (var reader = new StreamReader(filepath))
            {
                contents = _csvWrapper.GetRecords<T>(reader);
            }
            
            return contents;
        }
    }
}