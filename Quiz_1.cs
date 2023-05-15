using System;

namespace COVIDSimulation
{
    class City
    {
        public int id;
        public string name;
        public int level;

        public City(int id, string name, int level)
        {
            this.id = id;
            this.name = name;
            this.level = level;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of cities: ");
            int n = int.Parse(Console.ReadLine());

            City[] cities = new City[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter city {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter number of cities connected to {name}: ");
                int numConnectedCities = int.Parse(Console.ReadLine());

                int[] connectedCities = new int[numConnectedCities];
                Console.Write("Enter IDs of connected cities (separated by space): ");

                for (int j = 0; j < numConnectedCities; j++)
                {
                    int id = int.Parse(Console.ReadLine());

                    while (id < 0 || id >= i || id == j)
                    {
                        Console.WriteLine("Invalid ID. Please enter again.");
                        id = int.Parse(Console.ReadLine());
                    }

                    connectedCities[j] = id;
                }

                cities[i] = new City(i, name, 0);
            }

            Console.WriteLine("\nCities and their initial level of outbreak:");

            foreach (City city in cities)
            {
                Console.WriteLine("{city.id} {city.name} {city.level}");
            }

            Console.Write("\nEnter event (Outbreak/Vaccinate/Lockdown): ");
            string eventType = Console.ReadLine();

            while (eventType != "Outbreak" && eventType != "Vaccinate" && eventType != "Lockdown")
            {
                Console.WriteLine("Invalid event. Please enter again.");
                eventType = Console.ReadLine();
            }

            Console.Write("Enter city ID: ");
            int cityId = int.Parse(Console.ReadLine());

            switch (eventType)
            {
                case "Outbreak":
                    Console.Write("Enter level of outbreak: ");
                    int level = int.Parse(Console.ReadLine());
                    cities[cityId].level = level;
                    break;
                case "Vaccinate":
                    cities[cityId].level--;
                    break;
                case "Lockdown":
                    cities[cityId].level++;
                    break;
            }

            Console.WriteLine("\nUpdated cities and their level of outbreak:");

            foreach (City city in cities)
            {
                Console.WriteLine("{city.id} {city.name} {city.level}");
            }

            Console.ReadLine();
        }
    }
}
