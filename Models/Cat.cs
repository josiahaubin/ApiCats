using System;
using System.ComponentModel.DataAnnotations;

namespace cats.Models
{
    public class Cat
    {
        public Cat()
        {
            this.Id = String.Join("", Guid.NewGuid().ToString().Split('-'));
        }
        public Cat(string name, string color, int lives)
        {
            this.Name = name;
            this.Color = color;
            this.Lives = lives;
            this.Id = String.Join("", Guid.NewGuid().ToString().Split('-'));
        }

        [Required]
        [MaxLength(10)]
        [MinLength(3)] //NOTE Attributes apply to the value below them
        public string Name { get; set; }
        [Required]
        public string Color { get; set; }
        public int Lives { get; set; }
        public string Id { get; set; }
    }
}