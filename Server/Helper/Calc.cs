using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Helper
{
    public static class Calc
    {
        public static Coordenada Convertdd (Coordenada coordenada)
        {

            string ripa = coordenada.Coord;
            string longetitude = ripa.Substring(20, 10);
            string latitude = ripa.Substring(31, 11);

              
            coordenada.Longitude = ConvertDegree(longetitude);
            coordenada.Latitude = ConvertDegree1(latitude);
            coordenada.Raio = "http://maps.google.com/maps?q=" + coordenada.Longitude + "+" + coordenada.Latitude;

            return coordenada;
        }
        public static string ConvertDegree(string text)
        {
            string input = text;
           
            string direction = input.Substring((input.Length - 1), 1);
            string sign = "";

            if ((direction.ToUpper() == "S") || (direction.ToUpper() == "W"))
            {
                sign = "-";
            }
            string num = text.Substring(0, 2);
            string num2 = text.Substring(2, 7);
            double num3 =  Double.Parse(num2) / 60 ;
            string num3str = num3.ToString();
            num.Replace(".", "");
            num2.Replace(".", "");
            num3str.Replace(".", "");
            string num4 = sign + num + num3str.Substring(1, 5);
            



            return num4;
        }
        public static string ConvertDegree1(string text)
        {
            string input = text;

            string direction = input.Substring((input.Length - 1), 1);
            string sign = "";

            if ((direction.ToUpper() == "S") || (direction.ToUpper() == "W"))
            {
                sign = "-";
            }
            string num1 = text.Substring(0,3);
            string num2 = text.Substring(3, 7);
            double num3 = Double.Parse(num2) / 60;
            string num3str = num3.ToString();
            num2.Replace(".", "");
            num1.Replace(".", "");
            num3str.Replace(".", "");
            string num4 = sign + num1 + num3str.Substring(1, 5);
                        // 




            return num4;
        }

        public static double Calcular(double inicio_lat, double inicio_lng, double destino_lat, double destino_lng)
        {
            
            double x1 = inicio_lat;
            double x2 = destino_lat;
            double y1 = inicio_lng;
            double y2 = destino_lng;
            double rlat1 = Math.PI * x1 / 180;
            double rlat2 = Math.PI * x2 / 180;
            double theta = y1 - y2;
            double rtheta = Math.PI * theta / 180;
            double distancia =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            distancia = Math.Acos(distancia);
            distancia = distancia * 180 / Math.PI;
            distancia = distancia * 60 * 1.1515;

            distancia = distancia * 1.609344;
            return distancia*1000;
        }

        public static double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }

    } 
}
