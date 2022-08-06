using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerRunTests.JourneyToMoon
{
    internal class Result
    {
        public static int journeyToMoon(int n, List<List<int>> astronaut)
        {
            Space space = BuildSpace(n, astronaut);

            int result = 0;
            int unassignedAstrounats = n - space.AssignedAstronauts;
            foreach(var o in space.Countries)
            {
                Country country = o;
                while (country != null && country.NextCountry != null)
                {
                    result += o.AstrounautsCount * country.NextCountry.AstrounautsCount;
                    country = country.NextCountry;
                }
                result += (int)Math.Pow(result, unassignedAstrounats);
            }

            return result;
        }

        private static Space BuildSpace(int n, List<List<int>> astronaut)
        {
            Space retval = new Space(n);

            IEnumerator<List<int>> en = astronaut.GetEnumerator();

            int countryCounter = 0;
            Country lastCountry = null;
            while (en.MoveNext())
            {
                var o = en.Current;
                int a0 = o[0];
                int a1 = o[1];

                int countryId = 
                    retval.Astronauts[a0] >= 0 ? retval.Astronauts[a0] :
                    retval.Astronauts[a1] >= 0 ? retval.Astronauts[a1] :
                    countryCounter++;

                Country country;
                if (retval.Countries.Count > countryId)
                {
                    country = retval.Countries[countryId];
                }
                else
                {
                    country = new Country(countryId);
                    if (lastCountry != null)
                    {
                        lastCountry.NextCountry = country;
                    }
                    retval.Countries.Add(country);
                    lastCountry = country;
                }

                if (retval.Astronauts[a0] < 0)
                {
                    retval.Astronauts[a0] = countryId;
                    retval.AssignedAstronauts++;
                    country.AddAstrounaut(a0);
                }

                if (retval.Astronauts[a1] < 0)
                {
                    retval.Astronauts[a1] = countryId;
                    country.AddAstrounaut(a1);
                    retval.AssignedAstronauts++;
                }
            }

            return retval;
        }
    }

    class Space
    {
        public Space(int astrounautsCount)
        {
            Astronauts = new int[astrounautsCount];
            Countries = new List<Country>();

            PrepareAstronauts();
        }

        private void PrepareAstronauts()
        {
            for(int i = 0; i < Astronauts.Length; i++)
            {
                Astronauts[i] = (i + 1) * -1;
            }
        }

        public int[] Astronauts
        {
            get;
        }

        public List<Country> Countries
        {
            get;
        }

        public int AssignedAstronauts
        {
            get;
            set;
        }
            

        public Country UnassignedCountry
        {
            get;
            set;
        }

        public IEnumerable<string> CountriesAsString
        {
            get
            {
                List<string> retval = new List<string>();

                foreach(var o in Countries)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{o.Id} - {o.Astronauts}");
                    retval.Add(sb.ToString());
                }

                return retval;
            }
        }
    }
    
    class Country
    {

        public Country(int id)
        {
            Id = id;
            Astronauts = "";
        }

        public Country(int id, int astrounautsCount)
            : this(id)
        {
            AstrounautsCount = astrounautsCount;
        }

        public void AddAstrounaut(int id)
        {
            AstrounautsCount++;
            Astronauts += $"[{id}]";
        }

        public int Id
        {
            get;
        }

        public int AstrounautsCount
        {
            get;
            private set;
        }

        public Country NextCountry
        {
            get;
            set;
        }

        public string Astronauts
        {
            get;
            set;
        }
    }
}
