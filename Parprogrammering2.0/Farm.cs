using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parprogrammering2._0
{
    internal class Farm
    {        
        public void MainMenu()
        {
            AnimalManager animalManager = new AnimalManager();
            CropManager cropManager = new CropManager();
            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("Which manager system would you like to enter?");
                Console.WriteLine("1, Animalmanager");
                Console.WriteLine("2, Cropmanager");
                Console.WriteLine("9, Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        animalManager.AnimalManagerMenu(cropManager);
                        break;
                    case "2":
                        cropManager.CropManagerMenu();
                        break;
                    case "9":
                        loop = true;
                        return;
                }
            }
        }
    }
}
