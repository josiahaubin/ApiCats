using System;
using System.ComponentModel.DataAnnotations;

namespace cats.Models
{
  public class Dog
  {
    public Dog()
    {
      this.Id = String.Join("", Guid.NewGuid().ToString().Split('-'));
    }

    public Dog(string name, string color)
    {
      Name = name;
      Color = color;
      this.Id = String.Join("", Guid.NewGuid().ToString().Split('-'));
    }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Color { get; set; }
    public string Id { get; set; }
  }
}