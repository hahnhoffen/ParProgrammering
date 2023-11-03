using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Parprogrammering2._0
{
    internal class CropManager
    {
        List<Crop> crops = new List<Crop>();
        public CropManager() 
        {
            CropList();
        }
        public void CropManagerMenu()
        {
            bool loop = false;
            while (!loop)
            {
                Console.WriteLine("Which cropsmanager function would you like to do?");
                Console.WriteLine("1, View Crops");
                Console.WriteLine("2, Add Crop");
                Console.WriteLine("3, Remove Crop");
                Console.WriteLine("8, Back to ManagerMenu");
                Console.WriteLine("9, Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewCrops();
                        break;
                    case "2":
                        AddCrop();
                        break;
                    case "3":
                        RemoveCrop();
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
        private void ViewCrops()
        {
            foreach (Crop crop in crops)
            {
                crop.GetDescription();
            }
        }
        public void CropList()
        {
            Crop crop = new Crop(Crop.nextCropID, "barley", 10 );
            crops.Add(crop);
            crops.Add(new Crop(Crop.nextCropID, "wheat", 10));
        }
        private void AddCrop()
        { 
            try
            {
                Console.WriteLine("What Croptype?" );
                string cropType = Console.ReadLine().ToLower();
                Console.WriteLine("How much do you want to add?");
                int quantity = int.Parse(Console.ReadLine());

                Crop existingCrop = crops.Find(c => c.CropType == cropType);
                if (existingCrop != null)
                {
                    existingCrop.AddQuantity(quantity);
                    int updatedQuantity = existingCrop.GetQuantity();
                    Console.WriteLine(quantity + " " + cropType + " added. Total quantity: " + updatedQuantity);
                }
                else
                {
                    crops.Add(new Crop(Crop.nextCropID, cropType, quantity));
                    Console.WriteLine(cropType + " was successfully added with " + quantity);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please write the quantity in numbers.");
            }
        }
        private Crop GetCrop(int id)
        {
            foreach (var crop in crops)
            {
                if (crop.Id == id)
                {
                    return crop;
                }
            }
            return null;
        }
        private int RemoveCrop()
        {
            try
            {
                Console.WriteLine("Current animals: ");
                foreach (Crop crop in crops)
                {
                    crop.GetDescription();
                }
                Console.WriteLine("Which crop would you like to remove? Name the ID. ");
                int id = Convert.ToInt32(Console.ReadLine());

                Crop cropToRemove = GetCrop(id);
                if (cropToRemove != null)
                {
                    crops.Remove(cropToRemove);
                    Console.WriteLine("\nCrop successfully removed\n");
                    return 0;
                }
                else
                {
                    Console.WriteLine("\nThere is no such crop\n");
                    return 1;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input");
                return -1;
            }
        }
        public List<Crop> GetCrops()
        {
            return crops;
        }
    }
}
