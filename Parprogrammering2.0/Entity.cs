using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parprogrammering2._0
{
    internal abstract class Entity
    {
        protected string Name { get; set; }
        public int Id { get; set; }
        public Entity(int id, string name)
        {
            Name = name;
            Id = id;
        }
        public Entity(){} 
        public Entity(int id)
        {
            Id = id;
        }
        public abstract void GetDescription();
    }
}
