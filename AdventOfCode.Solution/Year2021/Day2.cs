using System.Linq;
using AdventOfCode.Solution.Year2021.Models;

namespace AdventOfCode.Solution.Year2021
{
    public class Day2
    {
        private readonly ICsvService _csvHelper;

        public Day2(ICsvService csvHelper)
        {
            _csvHelper = csvHelper ?? throw new ArgumentNullException(nameof(csvHelper));
        }

        /*
            Now, you need to figure out how to pilot this thing.

            It seems like the submarine can take a series of commands like forward 1, down 2, or up 3:

                - forward X increases the horizontal position by X units.
                - down X increases the depth by X units.
                - up X decreases the depth by X units.

            Note that since you're on a submarine, down and up affect your depth, and so they have the opposite result of what you might expect.

            Your horizontal position and depth both start at 0.

            Calculate the horizontal position and depth you would have after following the planned course. 
            What do you get if you multiply your final horizontal position by your final depth?
        */
        public int Dive(string filepath)
        {
            var measurements = _csvHelper.GetListOf<DiveMeasurement>(filepath);
            return GetFinalDepth(measurements) * GetFinalHorizontal(measurements);
        }

        /*
            Based on your calculations, the planned course doesn't seem to make any sense. You find the submarine manual and discover that the process is actually slightly more complicated.

            In addition to horizontal position and depth, you'll also need to track a third value, aim, which also starts at 0. The commands also mean something entirely different than you first thought:

                - down X increases your aim by X units.
                - up X decreases your aim by X units.
                - forward X does two things:
                    - It increases your horizontal position by X units.
                    - It increases your depth by your aim multiplied by X.

            What do you get if you multiply your final horizontal position by your final depth?
        */
        public int DiveWithAim(string filepath)
        {
            var measurements = _csvHelper.GetListOf<DiveMeasurement>(filepath);
            var finalPosition = GetFinalPostition(measurements);
            return finalPosition.Item1 * finalPosition.Item2;
        }

        private Tuple<int, int> GetFinalPostition(List<DiveMeasurement> measurements)
        {
            if (measurements == null || measurements.Count < 1) return new Tuple<int, int>(0, 0);

            var aim = 0;
            var horizontal = 0;
            var depth = 0;
            foreach (var measurement in measurements)
            {
                switch (measurement.Direction)
                {
                    case "up":
                        aim -= measurement.Value;
                        break;
                    case "down":
                        aim += measurement.Value;
                        break;
                    case "forward":
                        horizontal += measurement.Value;
                        depth += (aim * measurement.Value);
                        break;
                    default:
                        break;
                }
            }
            
            return new Tuple<int, int>(horizontal, depth);
        }

        private int GetFinalHorizontal(List<DiveMeasurement> measurements)
        {
            if (measurements == null || measurements.Count < 1) return 0;
            return measurements.Where(x => x.Direction == "forward").Select(x => x.Value).Sum();
        }

        private int GetFinalDepth(List<DiveMeasurement> measurements)
        {
            if (measurements == null || measurements.Count < 1) return 0;
            var up = measurements.Where(x => x.Direction == "up").Select(x => x.Value).Sum();
            var down = measurements.Where(x => x.Direction == "down").Select(x => x.Value).Sum();
            return down - up;
        }
    }
}