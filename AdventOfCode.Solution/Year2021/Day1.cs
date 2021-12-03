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

        /*
            As the submarine drops below the surface of the ocean, 
            it automatically performs a sonar sweep of the nearby sea floor. 
            On a small screen, the sonar sweep report (your puzzle input) appears: 
            each line is a measurement of the sea floor depth as the sweep looks 
            further and further away from the submarine.

            This report indicates that, scanning outward from the submarine, 
            the sonar sweep found depths of 199, 200, 208, 210, and so on.

            The first order of business is to figure out how quickly the depth increases, 
            just so you know what you're dealing with - you never know if the keys will 
            get carried into deeper water by an ocean current or a fish or something.

            To do this, count the number of times a depth measurement increases from 
            the previous measurement. (There is no measurement before the first measurement.) 
            
            How many measurements are larger than the previous measurement?
        */
        public int SonarSweep(List<int> measurements)
        {
            return GetNumberOfIncreases(measurements);
        }

        public int SonarSweep(string filepath)
        {
            var measurements = _csvHelper.GetListOfInt(filepath);
            return GetNumberOfIncreases(measurements);
        }

        /*
            Considering every single measurement isn't as useful as you expected: there's just too much noise in the data.

            Instead, consider sums of a three-measurement sliding window.

            Your goal now is to count the number of times the sum of measurements in this sliding window increases from the previous sum.

            How many sums are larger than the previous sum?
        */
        public int SonarSweepWithWindow(List<int> measurements)
        {
            return GetSlidingWindowIncreases(measurements);
        }

        public int SonarSweepWithWindow(string filepath)
        {
            var measurements = _csvHelper.GetListOfInt(filepath);
            return GetSlidingWindowIncreases(measurements);
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

        private int GetSlidingWindowIncreases(List<int> measurements)
        {
            if (measurements == null || measurements.Count < 2) return 0;
            
            var increases = 0;
            int? firstSum = null;
            int? secondSum = null;
            for (int i = 0; i < measurements.Count; i++)
            {
                if (i < 2) continue;
                secondSum = measurements[i] + measurements[i - 1] + measurements[i - 2];
                if (firstSum.HasValue && firstSum < secondSum) increases++;
                firstSum = secondSum;
            }
            return increases;
        }
    }
}