using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class StringHelper
    {
        public static string CutString(string str, int length)
        {

            if (str.Length > length)
            {
                return str.Substring(0, length) + "...";

            }
            else
            {
                return str;
            }
        }

        public static string CutString(object str, int length)
        {
            if (str == null)
            {
                return string.Empty;
            }
            if (str.ToString().Length > length)
            {
                return str.ToString().Substring(0, length) + "...";
            }
            else
            {
                return str.ToString();
            }
        }



        /// <summary>
        /// 获取指定字节长度的中英文混合字符串
        /// </summary>
        public static string GetStringByByte(string str, int len)
        {
            string result = string.Empty;// 最终返回的结果
            int byteLen = System.Text.Encoding.Default.GetByteCount(str);// 单字节字符长度
            int charLen = str.Length;// 把字符平等对待时的字符串长度
            int byteCount = 0;// 记录读取进度
            int pos = 0;// 记录截取位置
            if (byteLen > len)
            {
                for (int i = 0; i < charLen; i++)
                {
                    if (Convert.ToInt32(str.ToCharArray()[i]) > 255)// 按中文字符计算加2
                        byteCount += 2;
                    else// 按英文字符计算加1
                        byteCount += 1;
                    if (byteCount > len)// 超出时只记下上一个有效位置
                    {
                        pos = i;
                        break;
                    }
                    else if (byteCount == len)// 记下当前位置
                    {
                        pos = i + 1;
                        break;
                    }
                }

                if (pos >= 0)
                    result = str.Substring(0, pos);
            }
            else
                result = str;

            return result;
        }

        public static string ArrayToString(string[] Arr,string separator)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(separator))
            {
                separator = " ";
            }

            for (int i = 0; i < Arr.Length; i++)
            {
                if (i > 0) sb.Append(separator);
                sb.Append(Arr[i]);
            }

            return sb.ToString();

        }

        /// <summary>
        /// 获取空格字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string MakeSpaceString(int length)
        {
            StringBuilder strSB = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                strSB.Append(" ");
            }
            return strSB.ToString();
        }


    }
}
