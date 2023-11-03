using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parprogrammering2._0
{
    internal class AnimalManager
    {
        List<string> acceptableCropTypes = new List<string>();
        List<Animal> animals = new List<Animal>();
        public AnimalManager()
        {
            AnimalList();
        }
        public void AnimalManagerMenu(CropManager cropManager)
        {

            bool animalMenu = false;
            while (!animalMenu)
            {
                Console.WriteLine("Which animalmanager function would you like to do?");
                Console.WriteLine("1, View Animals");
                Console.WriteLine("2, Add Animal");
                Console.WriteLine("3, Remove Animal");
                Console.WriteLine("4, Feed Animal");
                Console.WriteLine("8, Back to ManagerMenu");
                Console.WriteLine("9, Exit");
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        ViewAnimals();
                        break;
                    case "2":
                        AddAnimal();
                        break;
                    case "3":
                        RemoveAnimal();
                        break;
                    case "4":
                        FeedAnimal(cropManager.GetCrops());
                        break;
                    case "8":
                        return;
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                }
            }
        }
        private void ViewAnimals()
        {
            foreach (Animal animal in animals)
            {
                Console.Write("Id: " + animal.Id + ". Species: " + animal.Species + ". Name: " + animal.GetName() + ". Acceptable crops: ");

                if (animal.GetAcceptableCropList().Count == 0)
                {
                    Console.Write("There is no acceptable crop");
                }
                else
                {
                    foreach (string cropType in animal.GetAcceptableCropList())
                    {
                        Console.Write(cropType + " ");
                    }
                }
                Console.WriteLine("");
            }
        }
        public void AnimalList()
        {
            Animal animal = new Animal(Animal.nextAnimalID, "Pig", "Niko", acceptableCropTypes = new List<string> {"barley"});
            animals.Add(animal);
            animals.Add(new Animal(Animal.nextAnimalID, "Pig", "Daniel", acceptableCropTypes = new List<string> { "barley" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Pig", "Tim", acceptableCropTypes = new List<string> { "barley" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Pig", "Robert", acceptableCropTypes = new List<string> { "barley" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Chicken", "Jonas", acceptableCropTypes = new List<string> { "wheat" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Chicken", "Rasmus", acceptableCropTypes = new List<string> { "wheat" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Chicken", "Kristofer", acceptableCropTypes = new List<string> { "wheat" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Chicken", "Toft", acceptableCropTypes = new List<string> { "wheat" }));
            animals.Add(new Animal(Animal.nextAnimalID, "Chicken", "Halling", acceptableCropTypes = new List<string> { "wheat" }));
        }
        private Animal GetAnimal(int id)
        {
            foreach (var animal in animals)
            {
                if (animal.Id == id)
                {
                    return animal;
                }
            }
            return null;
        }
        private void AddAnimal()
        {
            List<string> acceptableCropTypes = new List<string>();
            Console.WriteLine("What species?");
            string species = Console.ReadLine().ToLower();
            Console.WriteLine("What name?");
            string name = Console.ReadLine().ToLower();
            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("1, Add an acceptable crop type for the " + species);
                Console.WriteLine("2, No more acceptable crop");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        string acceptableCropType = Console.ReadLine().ToLower();
                        acceptableCropTypes.Add(acceptableCropType);
                        break;
                    case "2":
                        loop = true;
                        break;
                }

            }
            animals.Add(new Animal(Animal.nextAnimalID, species, name, acceptableCropTypes));
            Console.WriteLine(name + " was successfully added!");
        }
        private int RemoveAnimal()
        {
            try
            {
                Console.WriteLine("Current animals: ");
                foreach (Animal animal in animals)
                {
                    animal.GetDescription();
                }
                Console.WriteLine("Which animal would you like to remove? Name the ID. ");
                int id = Convert.ToInt32(Console.ReadLine());

                Animal animalToRemove = GetAnimal(id);
                if (animalToRemove != null)
                {
                    animals.Remove(animalToRemove);
                    Console.WriteLine("\nAnimal successfully removed\n");
                    return 0; 
                }
                else
                {
                    Console.WriteLine("\nThere is no such animal\n");
                    return 1; 
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");
                return -1; 
            }
        }
        public void FeedAnimal(List<Crop> crops)
        {
            bool loop = false;
            while (!false)
            {   
                Console.WriteLine("1, Feed animal");
                Console.WriteLine("2, Back to menu");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":

                        Console.WriteLine("Name of the animal would you like to feed?");
                        ViewAnimals();
                        string animalName = Console.ReadLine().ToLower();
                        Console.WriteLine("What crop do you wanna feed the animal with?");
                        string cropTypeInput = Console.ReadLine().ToLower();
                        Animal selectedAnimal = null;
                        Crop selectedCrop = null;

                        foreach (Crop crop in crops)
                        {
                            if (crop.GetCropType().ToLower() == cropTypeInput)
                            {
                                selectedCrop = crop;
                                break;
                            }
                        }
                        foreach (Animal animal in animals)
                        {
                            if (animal.GetName().ToLower() == animalName)
                            {
                                selectedAnimal = animal;
                                break;
                            }
                        }
                        if (selectedAnimal != null && selectedCrop != null)
                        {
                            selectedAnimal.Feed(selectedCrop); // Assuming the Feed method requires a Crop object as a parameter
                        }
                        else
                        {
                            Console.WriteLine("Animal or crop not found");
                        }
                        break;
                    case "2":
                        loop = false;
                        return;
                        default : Console.WriteLine("Something went wrong");
                        break;
                }
            }
        }
    }
}
