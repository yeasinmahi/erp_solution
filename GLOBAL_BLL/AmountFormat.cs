using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Developped By Akramul Haider
/// </summary>
namespace GLOBAL_BLL
{
    public class AmountFormat
    {
        StringBuilder sb;
        public string GetTakaInWords(double amount, string prefix, string suffix)
        {
            string po = "", str = "";
            int p = 0;
            sb = new StringBuilder();
            sb.Append(prefix + " ");

            GetValueWithoutPaisa(amount, ref po, ref str);

            amount = double.Parse(str);
            
            Converter(amount);

            if (po != "") p = int.Parse(po);
            if (p > 0) sb.Append(" And " + LessHundred(int.Parse(po)) + " Poisha");

            sb.Append(" " + suffix);            
            return sb.ToString();
        }
        public string SetCommaInAmount(double amount, string prefix, string suffix)
        {
            string paisa = "", withoutPaisa = "";
            sb = new StringBuilder();
            sb.Append(prefix);

            GetValueWithoutPaisa(amount, ref paisa, ref withoutPaisa);
            if (paisa == "") paisa = "00";
            amount = double.Parse(withoutPaisa);
            /*int dividedBy = 10000000;
            int tmpVal = Convert.ToInt32(Math.Floor((amount / dividedBy)));
            if (tmpVal > 0)
            {
                //Crore
                sb.Append(FormatWithinCrore(tmpVal.ToString()));
                sb.Append(",");
                amount = amount % dividedBy;
                sb.Append(FormatWithinCrore(amount.ToString()));
            }
            else
            {
                sb.Append(FormatWithinCrore(amount.ToString()));
            }
            */

            //Temporary start

            string str = amount.ToString();
            int count = 0, tmp = 0;
            StringBuilder reverse = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverse.Append(str[i]);
                if (count >= 2)
                {
                    if (tmp % 2 == 0)
                    {
                        reverse.Append(',');
                    }
                    tmp++;
                }
                count++;
            }

            if (reverse[reverse.Length - 1] == ',') reverse[reverse.Length - 1] = ' ';
                        
            for (int i = reverse.ToString().Length - 1; i >= 0; i--)
            {
                sb.Append(reverse[i]);
            }

            //Temporary end

            int p = int.Parse(paisa);

            if (p > 0)
            {
                sb.Append(".");
                sb.Append(paisa);
            }
            else
            {
                sb.Append(suffix);
            }

            return sb.ToString();
        }

        public string GetTakaInWords(decimal amount, string prefix, string suffix)
        {
            return GetTakaInWords(double.Parse(amount.ToString()), prefix, suffix);
        }
        public string SetCommaInAmount(decimal amount, string prefix, string suffix)
        {
            return SetCommaInAmount(double.Parse(amount.ToString()), prefix, suffix);
        }
        
        # region PrivetMethods
        
        private string FormatWithinCrore(string amount)
        {
            StringBuilder tmp = new StringBuilder();
            int length = amount.Length;
            if (amount.Length > 3)
            {
                int start;
                if ((length - 3) % 2 == 0)
                {
                    start = 0;
                }
                else
                {
                    start = 1;
                    tmp.Append(amount[0]);
                    tmp.Append(",");
                }

                for (int i = start; i < length - 3; i++)
                {
                    if (i % 2 == 1)
                    {
                        tmp.Append(amount[i]);
                        tmp.Append(",");
                    }
                    else
                    {
                        tmp.Append(amount[i]);
                    }
                }

                tmp.Append(amount.Substring(length - 3));
            }
            else
            {
                tmp.Append(amount);
            }

            return tmp.ToString();
        }
        private void GetValueWithoutPaisa(double amount,ref string paisa,ref string withoutPaisa)
        {
            paisa = "";
            withoutPaisa = amount.ToString();

            int i = withoutPaisa.IndexOf('.');
            if (i >= 0)
            {
                paisa = withoutPaisa.Substring(i + 1);
                if (paisa.Length <= 1) paisa += "0";

                withoutPaisa = withoutPaisa.Substring(0, i);
            }
        }
        private void Converter(double value)
        {
            int dividedBy = 10000000;
            int tmpVal = Convert.ToInt32(Math.Floor((value / dividedBy)));
            if (tmpVal > 0)
            {
                //Crore
                CalculatrBelowCrore(tmpVal);
                sb.Append(" Crore ");
                value = value % dividedBy;
                Converter(value);
            }
            else
            {
                CalculatrBelowCrore(value);
            }
        }
        private void CalculatrBelowCrore(double value)
        {
            int dividedBy;
            int tmpVal;

            //Lakh
            dividedBy = 100000;
            tmpVal = Convert.ToInt32(Math.Floor((value / dividedBy)));
            if (tmpVal > 0)
            {
                sb.Append(LessHundred(tmpVal) + " Lakh ");
                value = value % dividedBy;
                CalculatrBelowCrore(value);
            }
            else
            {
                //Thousand
                dividedBy = 1000;
                tmpVal = Convert.ToInt32(Math.Floor((value / dividedBy)));
                if (tmpVal > 0)
                {
                    sb.Append(LessHundred(tmpVal) + " Thousand ");
                    value = value % dividedBy;
                    CalculatrBelowCrore(value);
                }
                else
                {
                    //Hundred
                    dividedBy = 100;
                    tmpVal = Convert.ToInt32(Math.Floor((value / dividedBy)));
                    if (tmpVal > 0)
                    {
                        sb.Append(LessHundred(tmpVal) + " Hundred ");
                        value = value % dividedBy;
                        CalculatrBelowCrore(value);
                    }
                    else
                    {
                        //Tenth
                        tmpVal = Convert.ToInt32(Math.Floor((value % dividedBy)));
                        sb.Append(LessHundred(tmpVal));
                    }
                }
            }
        }
        private string LessHundred(int value)
        {
            if (value >= 100) return "";
            else if (value < 20)
            {
                return Get1to19(value);
            }
            else
            {
                int tmp1 = value / 10;
                int tmp2 = value % 10;

                return GetTenth(tmp1) + " " + Get1to19(tmp2);
            }

        }
        private string Get1to19(int value)
        {
            switch (value)
            {
                case 0:
                    return "";
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
                    return "Fifteen";
                case 16:
                    return "Sixteen";
                case 17:
                    return "Seventeen";
                case 18:
                    return "Eighteen";
                case 19:
                    return "Nineteen";
                default:
                    return "";
            }
        }
        private string GetTenth(int value)
        {
            switch (value)
            {
                case 2:
                    return "Twenty";
                case 3:
                    return "Thirty";
                case 4:
                    return "Forty";
                case 5:
                    return "Fifty";
                case 6:
                    return "Sixty";
                case 7:
                    return "Seventy";
                case 8:
                    return "Eighty";
                case 9:
                    return "Ninety";
                default:
                    return "";
            }
        }

        #endregion
    }
}
