using System;

namespace Napilnik1
{
    public class Good
    {
        public string Name { get; private set; }

        public Good(string name)
        {
            if (name == "" || name == null)
                throw new ArgumentException($"Good name cannot be empty");

            Name = name;
        }
    }
}
