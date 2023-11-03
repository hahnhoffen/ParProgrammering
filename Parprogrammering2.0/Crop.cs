using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parprogrammering2._0
{
    internal class Crop : Entity
    {
        public string CropType { get; set; }
        private int Quantity { get; set; }
        public static int nextCropID = 1;
        private int RemoveCrop {  get; set; }
        public Crop(int id, string cropType, int quantity)
            : base(nextCropID)
        {
            nextCropID++;
            Id = id;
            CropType = cropType;
            Quantity = quantity;
        }
        public void AddQuantity(int quantity)
        {
            Quantity += quantity;     
        }
        public override void GetDescription()
        {
            string CropInfo ="Id: " + Id + ". Croptype: " + CropType + ". Quantity: " + Quantity;
            Console.WriteLine(CropInfo);
        }
        public int GetQuantity()
        {
            return Quantity;
        }
        public bool TakeCrop(int quantity)
        {
            if (quantity <= Quantity)
            {
                Quantity -= quantity;
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetCropType()
        {
            return CropType;
        }
    }
}
