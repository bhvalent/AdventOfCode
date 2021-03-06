using AdventOfCode.Solution.Year2021.Models;

namespace AdventOfCode.Solution.Year2021
{
    public class Day3
    {
        private readonly ICsvService _csvService;

        public Day3(ICsvService csvService)
        {
            _csvService = csvService ?? throw new ArgumentNullException(nameof(csvService));
        }

        /*
            The submarine has been making some odd creaking noises, 
            so you ask it to produce a diagnostic report just in case.

            The diagnostic report (your puzzle input) consists of a list of binary numbers which, 
            when decoded properly, can tell you many useful things about the conditions of the submarine. 
            The first parameter to check is the power consumption.

            You need to use the binary numbers in the diagnostic report to generate two new binary numbers 
            (called the gamma rate and the epsilon rate). The power consumption can then be found by 
            multiplying the gamma rate by the epsilon rate.

            Each bit in the gamma rate can be determined by finding the most common bit in the corresponding 
            position of all numbers in the diagnostic report.

            The epsilon rate is calculated in a similar way; rather than use the most common bit, 
            the least common bit from each position is used.

            Use the binary numbers in your diagnostic report to calculate the gamma rate and epsilon rate, 
            then multiply them together. What is the power consumption of the submarine? 
            (Be sure to represent your answer in decimal, not binary.)
        */
        public int PowerConsumption(string filepath)
        {
            var report = _csvService.GetListOf<DiagnosticData>(filepath);
            return DecodePowerConsumption(report);
        }

        /*
            Next, you should verify the life support rating, which can be determined by multiplying 
            the oxygen generator rating by the CO2 scrubber rating.

            Both the oxygen generator rating and the CO2 scrubber rating are values that can be found 
            in your diagnostic report - finding them is the tricky part. Both values are located using a 
            similar process that involves filtering out values until only one remains. Before searching for 
            either rating value, start with the full list of binary numbers from your diagnostic report and 
            consider just the first bit of those numbers. Then:

                - Keep only numbers selected by the bit criteria for the type of rating value for which you 
                  are searching. Discard numbers which do not match the bit criteria.
                - If you only have one number left, stop; this is the rating value for which you are searching.
                - Otherwise, repeat the process, considering the next bit to the right.

            The bit criteria depends on which type of rating value you want to find:

                - To find oxygen generator rating, determine the most common value (0 or 1) in the current bit position, 
                  and keep only numbers with that bit in that position. If 0 and 1 are equally common, keep values with 
                  a 1 in the position being considered.
                - To find CO2 scrubber rating, determine the least common value (0 or 1) in the current bit position, 
                  and keep only numbers with that bit in that position. If 0 and 1 are equally common, keep values with a 
                  0 in the position being considered.

            Use the binary numbers in your diagnostic report to calculate the oxygen generator rating and CO2 scrubber rating, 
            then multiply them together. What is the life support rating of the submarine? 
            (Be sure to represent your answer in decimal, not binary.)

        */
        public int LifeSupportRating(string filepath)
        {
            var report = _csvService.GetListOf<DiagnosticData>(filepath);
            return DecodeLifeSupportRating(report);
        }

        private int DecodeLifeSupportRating(List<DiagnosticData> report)
        {
            if (report == null || report.Count < 1) return 0;

            var totalBits = report.FirstOrDefault().Value.Count();
            var oxygenData = new List<DiagnosticData>();
            oxygenData.AddRange(report);

            int bitIndex = 0;
            while (oxygenData.Count > 1 && bitIndex <= totalBits)
            {
                oxygenData = FilterForOxygenData(oxygenData, bitIndex);
                bitIndex++;
            }

            var cO2Data = new List<DiagnosticData>();
            cO2Data.AddRange(report);

            bitIndex = 0;
            while (cO2Data.Count > 1 && bitIndex <= totalBits)
            {
                cO2Data = FilterForCO2Data(cO2Data, bitIndex);
                bitIndex++;
            }

            int oxygemGeneratorRating = Convert.ToInt32(oxygenData.FirstOrDefault()?.Value, 2);
            int cO2ScrubberRating = Convert.ToInt32(cO2Data.FirstOrDefault()?.Value, 2);

            return oxygemGeneratorRating * cO2ScrubberRating;
        }

        private List<DiagnosticData> FilterForOxygenData(List<DiagnosticData> report, int index)
        {
            var zeros =  report.Where(x => x.Value[index] == '0');
            var ones =  report.Where(x => x.Value[index] == '1');
            return zeros.Count() > ones.Count() ? zeros.ToList() : ones.ToList();
        }

        private List<DiagnosticData> FilterForCO2Data(List<DiagnosticData> report, int index)
        {
            var zeros =  report.Where(x => x.Value[index] == '0');
            var ones =  report.Where(x => x.Value[index] == '1');
            return zeros.Count() <= ones.Count() ? zeros.ToList() : ones.ToList();
        }

        private int DecodePowerConsumption(List<DiagnosticData> report)
        {
            if (report == null || report.Count < 1) return 0;
            
            string total = string.Empty;
            string gammaRateString = string.Empty;
            var numberOfBits = report.FirstOrDefault()?.Value?.Count();
            for (int i = 0; i < numberOfBits; i++)
            {
                total = report.Aggregate(string.Empty, (total, next) => total += next.Value[i]);
                gammaRateString += total.Count(x => x.Equals('1')) > total.Count(x => x.Equals('0')) ? "1" : "0";
            }
            var epsilonRateString = gammaRateString.Aggregate(string.Empty, (total, next) => next == '1' ? total += '0' : total += '1');
            int gammaRate = Convert.ToInt32(gammaRateString, 2);
            int epsilonRate = Convert.ToInt32(epsilonRateString, 2);

            return gammaRate * epsilonRate;
        }
    }
}