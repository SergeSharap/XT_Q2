using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Award
    {
        private string title;

        public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        public Guid Id { get; private set; }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length > 40 || String.IsNullOrEmpty(value))
                    throw new ArgumentException("The title must be less than 41 characters and not empty");
                else
                    title = value;
            }
        }
    }
}
