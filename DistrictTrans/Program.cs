using System;

namespace DistrictTrans
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(PointTrans("30.270983, 120.172840;"));
            double pointTempLng = 120.172840;
            double pointTempLat = 30.270983;
            new GPS().gcj_encrypt(pointTempLat, pointTempLng, ref pointTempLat, ref pointTempLng);
            Console.WriteLine(pointTempLat);
            Console.WriteLine(pointTempLng);
            Console.ReadKey();
        }



        /// <summary>
        /// 坐标加偏到适配高德坐标
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static string PointTrans(string points)
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(points) && points.Contains(";"))
            {
                string[] arrPoints = points.Split(';');
                foreach (var item in arrPoints)
                {
                    string url = string.Format("http://restapi.amap.com/v3/assistant/coordinate/convert?key=07c9d2e7c963daed09de8ca3e43bcc7c&locations={0}&coordsys=gps", item);
                    System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                    System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
                    System.IO.Stream responseStream = response.GetResponseStream();
                    System.IO.StreamReader sr = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    string responseText = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    responseStream.Close();

                    string jsonData = responseText;
                    int index = jsonData.IndexOf("locations");
                    string ext = jsonData.Substring(index + 12);
                    int index2 = ext.IndexOf("\"");
                    string ext2 = ext.Substring(0, index2);
                    int index3 = ext2.IndexOf(",");
                    string ext3 = ext2.Substring(0, index3);
                    string ext4 = ext2.Substring(index3 + 1);

                    result += string.Format("{0},{1};", ext3, ext4);
                }
            }
            return result.Trim(';');
        }

        public class GPS
        {
            public Double PI = 3.14159265358979324;
            public Double x_pi = 3.14159265358979324 * 3000.0 / 180.0;
            public void delta(Double lat, Double lon, ref Double dLat, ref Double dLon)
            {
                Double a = 6378245.0; //  a: 卫星椭球坐标投影到平面地图坐标系的投影因子。
                Double ee = 0.00669342162296594323; //  ee: 椭球的偏心率。
                dLat = transformLat(lon - 105.0, lat - 35.0);
                dLon = transformLon(lon - 105.0, lat - 35.0);
                Double radLat = lat / 180.0 * this.PI;
                Double magic = Math.Sin(radLat);
                magic = 1 - ee * magic * magic;
                var sqrtMagic = Math.Sqrt(magic);
                dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * this.PI);
                dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * this.PI);
            }

            public Double transformLat(Double x, Double y)
            {
                var ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
                ret += (20.0 * Math.Sin(6.0 * x * this.PI) + 20.0 * Math.Sin(2.0 * x * this.PI)) * 2.0 / 3.0;
                ret += (20.0 * Math.Sin(y * this.PI) + 40.0 * Math.Sin(y / 3.0 * this.PI)) * 2.0 / 3.0;
                ret += (160.0 * Math.Sin(y / 12.0 * this.PI) + 320 * Math.Sin(y * this.PI / 30.0)) * 2.0 / 3.0;
                return ret;
            }

            public Double transformLon(Double x, Double y)
            {
                var ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
                ret += (20.0 * Math.Sin(6.0 * x * this.PI) + 20.0 * Math.Sin(2.0 * x * this.PI)) * 2.0 / 3.0;
                ret += (20.0 * Math.Sin(x * this.PI) + 40.0 * Math.Sin(x / 3.0 * this.PI)) * 2.0 / 3.0;
                ret += (150.0 * Math.Sin(x / 12.0 * this.PI) + 300.0 * Math.Sin(x / 30.0 * this.PI)) * 2.0 / 3.0;
                return ret;
            }

            public void gcj_encrypt(Double wgsLat, Double wgsLon, ref Double lat, ref Double lon)
            {
                if (outOfChina(wgsLat, wgsLon))
                {
                    lat = wgsLat;
                    lon = wgsLon;
                }

                Double dLat = 0;
                Double dLon = 0;
                delta(wgsLat, wgsLon, ref dLat, ref dLon);
                lat = wgsLat + dLat;
                lon = wgsLon + dLon;
            }

            public bool outOfChina(Double lat, Double lon)
            {
                if (lon < 72.004 || lon > 137.8347)
                    return true;
                if (lat < 0.8293 || lat > 55.8271)
                    return true;
                return false;
            }
        }
    }
}
