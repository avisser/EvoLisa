using System.Linq;
using GenArt.Classes;
using GenArt.Core.Models;

namespace GenArt.Core.Classes
{
  public static class MutationExtensions
  {
    public static void Mutate(this Polygon self, float probability)
    {
      if (Tools.Doit(probability))
      {
        self.Brush = PolygonChromosome.RandomBrush();
      }

      var newPoints = self.Points.Select(p =>
      {
        if (Tools.Doit(probability))
        {
          return PolygonChromosome.RandomPoint();
        }
        else
        {
          return p;
        }
      }).ToList();

      self.Points.Clear();
      self.Points.Add(newPoints);
    }
  }
}
