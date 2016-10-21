using System;

namespace Geo_Comm4Net
{
    /// <summary>
    /// 十进制度和度分秒转换类
    /// </summary>
    public class UnitConverter
    {
        /// <summary>
        /// 度分秒转十进制度
        /// </summary>
        /// <param name="dms"></param>
        /// <returns></returns>
        public static double Dms2Degree(Dms dms)
        {
            if (null != dms)
            {
                var decD = new decimal(dms.Degree);
                var decM = new decimal(dms.Minute);
                var decS = new decimal(dms.Second);
                var dec60 = new decimal(60.0);

                var decDDouble = decD + (decM / dec60) + (decS / dec60 / dec60);
                return decimal.ToDouble(decDDouble);
            }

            return 0;
        }

        /// <summary>
        /// 十进制度转度分秒
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Dms Degree2Dms(double d)
        {
            var dec = new decimal(d);
            var dec60 = new decimal(60.0);
            var cd = new Dms { Degree = decimal.ToInt32(dec) };
            var min = decimal.Multiply(dec - new decimal(cd.Degree), dec60);
            cd.Minute = decimal.ToInt32(min);
            var sec = min - new decimal(cd.Minute);
            cd.Second = decimal.ToDouble(decimal.Multiply(sec, dec60));
            return cd;
        }
    }

    public class Dms
    {
        public int Degree { get; set; }
        public int Minute { get; set; }
        public Double Second { get; set; }
    }
}