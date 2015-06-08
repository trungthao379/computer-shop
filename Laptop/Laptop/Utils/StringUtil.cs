using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Laptop.Utils
{
    public class StringUtil
    {
        /// <summary>
        /// truncate e text with length
        /// </summary>
        /// <param name="text"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string truncate(string text, int length)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            if (length < text.Length)
            {
                StringBuilder sb = new StringBuilder(length + 3);
                for (int i = 0; i < length; i++)
                {
                    sb.Append(text[i]);
                }
                sb.Append("...");
                return sb.ToString();
            }

            return text;
        }

        /// <summary>
        /// format price
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string convertPrice(double price)
        {
            if (price > 99999)
            {
                double m = price / 1000000;
                double temp = price % 1000000;
                double t = temp / 1000;
                double u = temp % 1000;
                return string.Format("{0}.{1}.{2:000}đ", (int)m, (int)t, (int)u);
            }
            else
            {
                double t = price / 1000;
                double u = price % 1000;
                return string.Format("{0}.{1:000}đ", (int)t, (int)u);
            }
        }

        /// <summary>
        /// format a price on sale
        /// </summary>
        /// <param name="price"></param>
        /// <param name="saleOff"></param>
        /// <returns></returns>
        public static string convertPrice(double price, int saleOff)
        {
            price = price * (100 - saleOff) / 100;
            return convertPrice(price);
        }
    }
}