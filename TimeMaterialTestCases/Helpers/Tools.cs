using System;
using System.Text;

namespace TimeMaterialTestCases.Helpers
{
    public class Tools
    {
        /* Format Price
         * @param price The price to be formated, 10000.123
         * @return In the format of $10,000.12
         */
        public static String FormatPrice(String price)
        {
            if(price.Length == 0 || price == null)
            {
                return String.Empty;
            }
            String[] priceStrs = price.Split('.', StringSplitOptions.RemoveEmptyEntries);
            String priceNum = priceStrs[0];
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = priceNum.Length - 1; index >= 0; index--)
            {
                char c = priceNum[index];
                var len = priceNum.Length - index;
                if (len > 3 && len % 3 == 1)
                {
                    stringBuilder.Insert(0, ',');
                }
                stringBuilder.Insert(0, c);
            }
            stringBuilder.Insert(0, '$');
            String priceDecimal = (priceStrs.Length > 1) ? priceStrs[1] : "00";
            return stringBuilder.Append("." + priceDecimal.Substring(0, 2)).ToString();
        }
    }
}
