using System;
    class Program {
        static void Main (string[] args) {
           
           int NumberOfCities;         
           Console.WriteLine("Enter Number of City in the model: ");                     
           NumberOfCities = int.Parse(Console.ReadLine());

        Dictionary<int,string> cities = new Dictionary<int, string>();
        for (int i = 0; i < NumberOfCities; i++){
            Console.Write("Enter the name of City: ");
            string cityName = Console.ReadLine();
            cities[i] = cityName;
        }

        Dictionary<int,int> outbreaklevels = new Dictionary<int, int>();
        for (int i = 0; i < NumberOfCities; i++){
            Console.Write("Enter the outbreak of City: ");
            int outbreaklevel = int.Parse(Console.ReadLine());
            outbreaklevels[i] = outbreaklevel;
        }

        while (true){
            Console.WriteLine("Enter an event (Outbreak, Vaccinate, Lock down, Spread, or Exit: ");
            string userEvent = Console.ReadLine();
            
            if (userEvent == "outbreak" || userEvent == "Vaccinate" || userEvent == "Lock Down"){
                Console.Write("Enter the city ID: ");
                int cityID = int.Parse(Console.ReadLine());

                if(cityID >= NumberOfCities || cityID < 0 || cityID == NumberOfCities){
                    Console.WriteLine("Invalid ID");
                    continue;
                }
                if(userEvent == "Outbreak") {
                    int outbreaklevel = outbreaklevels[cityID];
                    if(outbreaklevel + 2 <= 3)
                    outbreaklevels[cityID] += 2;

                    int neighboringCityID = cityID +1;
                    if(neighboringCityID < NumberOfCities && outbreaklevels[neighboringCityID] + 1 <= 3)
                    outbreaklevels[neighboringCityID] += 1;
                }
                else if (userEvent == "Vaccinate"){
                    outbreaklevels[cityID]=0;
                }
                else if (userEvent == "Lock down"){
                    if (outbreaklevels[cityID] - 1 >= 0)
                    outbreaklevels[cityID] -= 1;

                    int neighboringCityID = cityID + 1;
                    if (neighboringCityID < NumberOfCities && outbreaklevels[neighboringCityID] - 1 >= 0 )
                    outbreaklevels[neighboringCityID] -= 1;
                }
            }
            else if (userEvent == "Spread"){
                for(int i = 0; i < NumberOfCities; i++){
                    int neighboringCityID = i + 1;
                    if(neighboringCityID < NumberOfCities && outbreaklevels[neighboringCityID] > outbreaklevels[i])
                    outbreaklevels[i] += 1;
                }
            }
            else if (userEvent == "Exit"){
                break;
            }
            else {
                Console.WriteLine("Invalid event");
                continue;
            }
            Console.WriteLine("\nCity ID\t\tCity Name\tOutbreak Level");
            for (int i = 0; i < NumberOfCities; i++){
                Console.WriteLine("{i}\t\t{cities[i]}\t\t{outbreakLevels[i]");
            }

        }
        

           
    }
}