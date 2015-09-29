using Labyrinth.Core.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth.Core.Players
{
    //TODO: Add player possition property, move functionality, validation for move can be  implementet in common validator class! 
    public class Character:ICharacter
    {
        private string name;

        public Character(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
           
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name can't be null or empty string!");
                }
                this.name = value;
            }
        }
    }
}
