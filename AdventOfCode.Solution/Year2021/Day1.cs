using AdventOfCode.Solution.Helpers;

namespace AdventOfCode.Solution.Year2021
{
    public class Day1
    {
        private ICsvService _csvHelper;

        public Day1(ICsvService csvHelper)
        {
            _csvHelper = csvHelper ?? throw new ArgumentNullException(nameof(csvHelper));
        }

        public int SonarSweep(List<int> measurements)
        {
            return GetNumberOfIncreases(measurements);
        }

        public int SonarSweep(string filepath)
        {
            var measurements = _csvHelper.GetListOfInt(filepath);
            return GetNumberOfIncreases(measurements);
        }

        private int GetNumberOfIncreases(List<int> measurements)
        {
            if (measurements == null || measurements.Count < 2) return 0;

            int increases = 0;
            for (int i = 0; i < measurements.Count; i++)
            {
                if (i == 0) continue;
                if (measurements[i] > measurements[i -1]) increases++;
            }
            return increases;
        }
    }
}