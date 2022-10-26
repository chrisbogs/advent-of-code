using AdventOfCodeShared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class Diagnostic
    {
        private int gammaRate = 0; // most common bit
        private int epsilonRate = 0; // least common bit
        public int PowerConsumption => this.gammaRate * this.epsilonRate;

        private int oxygenGeneratorRating = 0; // most common bit
        private int cO2ScrubberRating = 0; // least common bit
        public int LifeSupportRating => this.oxygenGeneratorRating * this.cO2ScrubberRating;


        // read in the diagnostic report and produce the binary numbers.
        // assume all binary strings same Length.
        public void Read(string[] diagnosticReport)
        {
            if (diagnosticReport == null || diagnosticReport.Length< 1)
                return;

            var mostCommonBitString = "";
            var binaryStringLength = diagnosticReport[0].Length;

            for (var currentPosition = 0; currentPosition < binaryStringLength; currentPosition++)
            {
                mostCommonBitString += this.GetMostCommonBitString(diagnosticReport, currentPosition, '1');
            }
            this.gammaRate = Convert.ToInt32(mostCommonBitString, 2);
            this.epsilonRate = Convert.ToInt32(mostCommonBitString.FlipBitString(), 2);
            this.CalculateOxygenAndCo2Ratings(diagnosticReport, binaryStringLength);
        }

        private void CalculateOxygenAndCo2Ratings(string[] diagnosticReport, int binaryStringLength)
        {
            var bitStrings = diagnosticReport.ToArray();
            this.oxygenGeneratorRating = this.FilterByBitCriteria(bitStrings, binaryStringLength, '1');
            this.cO2ScrubberRating = this.FilterByBitCriteria(bitStrings, binaryStringLength, '0', true);

        }

        // Returns the binary representation of the bit string left over after applying the 
        // bit criteria to the given list.
        private int FilterByBitCriteria(string[] bitStrings, int binaryStringLength,
            char tieBreaker, bool findLeastCommon = false)
        {
            for (var currentPosition = 0; currentPosition < binaryStringLength; currentPosition++)
            {
                var firstMostCommon = this.GetMostCommonBitString(bitStrings, currentPosition, tieBreaker, findLeastCommon);

                // filter values to those that have this value in their nth position
                bitStrings = bitStrings.ToList().Where(x => x[currentPosition] == firstMostCommon).ToArray();
                if (bitStrings.Length == 1)
                {
                    return Convert.ToInt32(bitStrings[0], 2);
                }

            }
            return 0;
        }
        private char GetMostCommonBitString(string[] bitStringArray, int currentPosition,
            char tieBreaker, bool findLeastCommon = false)
        {
            var counts0 = 0;
            var counts1 = 0;
            foreach (var element in bitStringArray)
            {
                // check the i-th position in each string
                if (element[currentPosition] == '0')
                {
                    counts0++;
                }
                else
                {
                    counts1++;
                }
            }
            var result = '1';
            if (counts0 > counts1) result = '0';
            if (findLeastCommon)
            {
                result = result == '0' ? '1' : '0';
            }

            // tiebreaker MUST come last
            if (counts0 == counts1) result = tieBreaker;

            return result;
        }

    }
}