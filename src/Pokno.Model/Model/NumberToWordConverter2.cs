using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokno.Model
{
    public class NumberToWordConverter2
    {

        private StringBuilder stringBuilder;


        public StringBuilder TransformNumberToWord(long numberToCovert)
        {
            string numberInStringFormat = numberToCovert.ToString();
            long numberCount = numberInStringFormat.Count();
            stringBuilder = new StringBuilder();
            if (numberToCovert > 0 && numberCount <= 12)
            {
                return ConvertNumberToWord(numberInStringFormat);
            }
            return stringBuilder.Append("Word Can Be Generated");
        }

        public StringBuilder ConvertNumberToWord(string numberToConvertInStringFormat)
        {
            long actualToConvert = long.Parse(numberToConvertInStringFormat);
            numberToConvertInStringFormat = actualToConvert.ToString();
            long numberCount = numberToConvertInStringFormat.Count();
            if (numberCount != 5 && numberCount != 8 && numberCount != 11)
            {
                if (numberCount == 2 || numberCount == 1)
                {
                    return ProcessNumberWithOneZero(numberToConvertInStringFormat);
                }
                string firstUnitNumberForm = numberToConvertInStringFormat.First().ToString();
                string firstUnitNumberInWord = GetNumberBundleInWords(long.Parse(firstUnitNumberForm));
                string substring1 = numberToConvertInStringFormat.Substring(1);
                string powersOfTenInWord = GetNumberBundleInWords((long)Math.Pow(10, numberCount - 1));
                if (stringBuilder.Length == 0)
                {
                    stringBuilder.Append(firstUnitNumberInWord + " ");
                }
                else
                {
                    //throw new Exception("here");
                    stringBuilder.Append(" " + "," + " " + firstUnitNumberInWord + " ");
                }
                string substring = numberToConvertInStringFormat.Substring(1);

                if (long.Parse(substring) == 0)
                {
                    return stringBuilder.Append(powersOfTenInWord + " " + "Naira Only.");
                }
                else if (substring.Count() == 2)
                {
                    stringBuilder.Append(" "+powersOfTenInWord + " " + "And" + " ");
                    return ProcessNumberWithOneZero(substring);
                }
                else if (substring.Count() == 4)
                {
                    stringBuilder.Append(" "+powersOfTenInWord + " ");
                    return ProcessNumberWithOneZero(substring);
                }
                else
                {
                    if (numberToConvertInStringFormat.Count() == 12 || numberToConvertInStringFormat.Count() == 6 || numberToConvertInStringFormat.Count() == 9)
                    {

                        long substringInNumber = long.Parse(substring);
                        if (substringInNumber.ToString().Count() < substring.Count())
                        {
                            stringBuilder.Append(powersOfTenInWord + " ");
                            return ConvertNumberToWord(substring);
                        }
                        stringBuilder.Append("hundred" + " ");
                        return ConvertNumberToWord(substring);
                    }
                    stringBuilder.Append(powersOfTenInWord + " ");
                    return ConvertNumberToWord(substring);
                }
            }
            else if (numberCount == 5 || numberCount == 8 || numberCount == 11)
            {
                ProcessWithCountOfFiveAndEightAndEleven(numberToConvertInStringFormat);
            }
            return stringBuilder;
        }

        public StringBuilder ProcessWithCountOfFiveAndEightAndEleven(string numberToConvertInStringFormat)
        {
            numberToConvertInStringFormat = long.Parse(numberToConvertInStringFormat).ToString();
            int newNumberCount = numberToConvertInStringFormat.Count();
            if (newNumberCount == 5 || newNumberCount == 8 || newNumberCount == 11)
            {
                long firstTwoNumbersInNumberToConvert = long.Parse(numberToConvertInStringFormat.Substring(0, 2));
                string powersOfTenInWord = GetNumberBundleInWords((long)Math.Pow(10, newNumberCount - 1));
                string firstTwoNumbersInWord = GetNumberBundleInWords(firstTwoNumbersInNumberToConvert);
                if (firstTwoNumbersInWord != null)
                {
                    return FirstTwoNumberNotNull(firstTwoNumbersInWord, numberToConvertInStringFormat, powersOfTenInWord);
                }
                else
                {
                    return FirstTwoNumberEqualNull(firstTwoNumbersInNumberToConvert, numberToConvertInStringFormat, powersOfTenInWord);
                }
            }
            return ConvertNumberToWord(numberToConvertInStringFormat);
        }

        public StringBuilder FirstTwoNumberNotNull(string firstTwoNumbersInWord, string numberToConvertInStringFormat, string powersOfTenInWord)
        {
            string substring = numberToConvertInStringFormat.Substring(2);
            if (long.Parse(substring) == 0)
            {
                stringBuilder.Append(firstTwoNumbersInWord + " " + powersOfTenInWord + " " + "");
            }
            else
            {
                if (stringBuilder.Length == 0)
                {
                    stringBuilder.Append(firstTwoNumbersInWord + " " + powersOfTenInWord + " ");
                }
                else
                {
                    //throw new Exception("here");
                    stringBuilder.Append("and" + " " + firstTwoNumbersInWord + " " + powersOfTenInWord + " ");
                }
                //stringBuilder.Append("and"+" "+firstTwoNumbersInWord + " " + powersOfTenInWord + " " );
            }
            return ConvertNumberToWord(substring);
        }

        public StringBuilder FirstTwoNumberEqualNull(long firstTwoNumbersInNumberToConvert, string numberToConvertInStringFormat, string powersOfTenInWord)
        {
            long firstNumber = long.Parse(firstTwoNumbersInNumberToConvert.ToString().First().ToString());
            long secondNumber = long.Parse(firstTwoNumbersInNumberToConvert.ToString().Last().ToString());
            double firstPowerOften = firstNumber * Math.Pow(10, 1);
            double secondPowerOften = secondNumber * Math.Pow(10, 0);
            string firstNumberInWordForm = GetNumberBundleInWords((long)firstPowerOften);
            string secondNumberInWordForm = GetNumberBundleInWords((long)secondPowerOften);

            if (stringBuilder.Length == 0)
            {
                stringBuilder.Append(firstNumberInWordForm + " " + secondNumberInWordForm + " " + powersOfTenInWord);
            }
            else
            {
                //throw new Exception("here");
                stringBuilder.Append(" " + "and" + " " + firstNumberInWordForm + " " + secondNumberInWordForm + " " + powersOfTenInWord);
            }
            //stringBuilder.Append(firstNumberInWordForm + " ");
            string substring = numberToConvertInStringFormat.Substring(2);
            return ConvertNumberToWord(substring);

        }
        public StringBuilder ProcessNumberWithOneZero(string numberInStringFormat)
        {
            long numberCount = numberInStringFormat.Count();
            long numberForm = long.Parse(numberInStringFormat);

            if (numberForm == 0)
            {
                return stringBuilder.Append(".");
            }
            string tensInBundle = GetNumberBundleInWords(numberForm);
            if (tensInBundle != null)
            {
                return stringBuilder.Append(" "+tensInBundle + ".");
            }
            else
            {
                long firstNumberForm = long.Parse(numberInStringFormat.First().ToString());
                long secondNumberForm = long.Parse(numberInStringFormat.Last().ToString());
                double firstPowerOften = firstNumberForm * Math.Pow(10, numberCount - 1);
                double secondPowerOften = secondNumberForm * Math.Pow(10, numberCount - 2);
                string firstUnitInWordForm = GetNumberBundleInWords((long)firstPowerOften);
                string secondUnitInWordForm = GetNumberBundleInWords((long)secondPowerOften);
                return stringBuilder.Append(" "+firstUnitInWordForm + " " + secondUnitInWordForm);
            }

        }

        public string GetNumberBundleInWords(long number)
        {
            switch (number)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Eleven";
                case 12:
                    return "Twelve";
                case 13:
                    return "Thirteen";
                case 14:
                    return "Fourteen";
                case 15:
                    return "Fiftteen";
                case 16:
                    return "Sixteen";
                case 17:
                    return "Seventeen";
                case 18:
                    return "Eighteen";
                case 19:
                    return "Nineteen";
                case 20:
                    return "Twenty";
                case 30:
                    return "Thirty";
                case 40:
                    return "Fourty";
                case 50:
                    return "Fifty";
                case 60:
                    return "Sixty";
                case 70:
                    return "Seventy";
                case 80:
                    return "Eighty";
                case 90:
                    return "Ninty";
                case 100:
                    return "hundred";
                case 1000:
                case 10000:
                    return "thousand";
                case 100000:
                    return "hundred thousand";
                case 1000000:
                case 10000000:
                    return "Million";
                case 100000000:
                    return "hundred Million";
                case 1000000000:
                case 10000000000:
                    return "Billion";
                case 100000000000:
                    return "hundred Billion";
            }
            return null;
        }
       
       
    }
}
