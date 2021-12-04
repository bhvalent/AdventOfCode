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
        public int PowerConsumption(List<DiagnosticData> report)
        {
            return DecodeReport(report);
        }

        public int PowerConsumption(string filepath)
        {
            var report = _csvService.GetListOf<DiagnosticData>(filepath);
            return DecodeReport(report);
        }

        private int DecodeReport(List<DiagnosticData> report)
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