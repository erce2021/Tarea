using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSis
{
    public class WeatherForm
    {
        public class City
        {

            public double idC { get; set; }
            public string name { get; set; }

            public Coord lat { get; set; }
            public Coord longt { get; set; }

        }
        public class Clima
        {
            public Coord coord;

            public Weather[] weather;

            public Main main;

            public double visibility;

            public double dt;

            public double timezone;

            public int id;

            public string name;

            public double cod;

            public object Wind { get; set; }
        }
        public class Coord
        {
            public double longt { get; set; }
            public double lat { get; set; }
            private double _temp;
            public double temp
            {
                get
                {
                    return _temp;
                }
                set
                {
                    _temp = value - 273.15;
                }
            }
            public double _temp_min;
            public double temp_min
            {
                get
                {
                    return _temp_min;
                }
                set
                {
                    _temp_min = value - 273.15;
                }
            }

            public double _temp_max;
            public double temp_max
            {
                get
                {
                    return _temp_max;
                }
                set
                {
                    _temp_max = value - 273.15;
                }
            }
            private double _feels_like;
            public double feels_like
            {
                get
                {
                    return _feels_like;
                }
                set
                {
                    _feels_like = value - 273.15;
                }
            }
            private double _pressure;
            public double pressure
            {
                get
                {
                    return _pressure;
                }
                set
                {
                    _pressure = value / 1.3332239;
                }
            }
            public int sea_level { get; set; }
            public int humidity { get; set; }

        }
        public class Weather
        {

            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public String icon { get; set; }

        }
        public class Wind
        {
            private double _speed;
            public double speed
            {
                get
                {
                    return _speed;
                }
                set
                {
                    _speed = value * 3.6;
                }
            }

            private double _deg;
            public double deg
            {
                get
                {
                    return _deg;
                }
                set
                {
                    _deg = value;
                }
            }
        }
    }
}
