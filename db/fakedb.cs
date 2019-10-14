using System.Collections.Generic;
using cats.Models;

namespace cats.DB
{
  public static class FakeDB
  {
    public static List<Cat> Cats = new List<Cat>(){
            new Cat("Garfield", "Orange", 2),
            new Cat("Tom", "Grey", 1),
            new Cat("Felix", "Black", 6)
        };

    public static List<Dog> Dogs = new List<Dog>()
    {
        new Dog("Fiddo", "Brown"),
        new Dog("Doge", "Yellow"),
        new Dog("Dog, The Bounty Hunter", "White")
    };
  }
}