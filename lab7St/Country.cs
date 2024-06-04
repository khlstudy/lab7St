using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7St
{
    public class Country
    {
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string CapitalCity { get; set; }
        public int Population { get; set; }
        public double Area { get; set; }
        public double LifeExpectancy { get; set; }
        public bool IsInEU { get; set; }
        public bool IsInNATO { get; set; }
        public double PopulationDensity { get; set; }
        public bool IsAboveAverage { get; set; }


        public Country() { }

        public Country(string name, string continent, string capital, int population, double area, double lifeExpectancy, bool isInEU, bool isInNATO)
        {
            CountryName = name;
            Continent = continent;
            CapitalCity = capital;
            Population = population;
            Area = area;
            LifeExpectancy = lifeExpectancy;
            IsInEU = isInEU;
            IsInNATO = isInNATO;


            // розрахунок густини населення та перевірка, чи вона вище середньої, при створенні об'єкта
            PopulationDensity = CalculatePopulationDensity();
            IsAboveAverage = IsPopulationDensityAboveAverage();
        }

        public double CalculatePopulationDensity()
        {
            return Population / Area;
        }

        public bool IsPopulationDensityAboveAverage()
        {
            double averagePopulationDensity = 40; // середня густота населення Землі
            return CalculatePopulationDensity() > averagePopulationDensity;
        }
    }
}



