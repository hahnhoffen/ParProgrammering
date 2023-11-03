using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parprogrammering2._0
{
    internal class Animal : Entity
    {
        public string Species { get; set; }
        public static int nextAnimalID = 1;
        private List<string> AcceptableCropTypes = new List<string>();
        public bool IsFed;
    public Animal(int id, string species, string name, List<string> acceptableCropTypes)
            : base(nextAnimalID, name)
        {
            nextAnimalID++;
            Id = id;
            Species = species;
            Name = name;
            AcceptableCropTypes = acceptableCropTypes;
            IsFed = false;
        }
        public Animal() { }
        public override void GetDescription()
        {
            string AnimalInfo = "Id: " + Id + ", name: " + Name;
            Console.WriteLine(AnimalInfo);
        }
        public string GetName()
        {
            return Name;
        }
        public List<string> GetAcceptableCropList()
        {
            return AcceptableCropTypes;
        }
        public void Feed(Crop crop)
        {
            if (!IsFed)
            {
                Console.WriteLine("Feeding " + Name + " the " + Species + " with " + crop.CropType);
                if (AcceptableCropTypes.Contains(crop.CropType))
                {
                    Console.WriteLine("How much do you wanna feed the animal?");
                    int input = int.Parse(Console.ReadLine());
                    if (crop.TakeCrop(input))
                    {
                        Console.WriteLine(Name + " has been fed with " + crop.CropType);
                        IsFed = true;
                    }
                    else
                    {
                        Console.WriteLine("Not enough " + crop.CropType + " to feed " + Name);
                    }
                }
                else
                {
                    Console.WriteLine(Name + " does not eat " + crop.CropType);
                }
            }
            else
            {
                Console.WriteLine(Name + " has already been fed in this session");
            }
        }
    }
}
