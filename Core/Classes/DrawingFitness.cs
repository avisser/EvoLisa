using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GenArt.AST;
using GenArt.Classes;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Fitnesses;
using Google.Protobuf;

namespace GenArt.Core.Classes
{
  public class DrawingFitness : IFitness
  {
    private Color[,] _sourceColors;

    public DrawingFitness(Color[,] sourceColors)
    {
      _sourceColors = sourceColors;
    }

    public double Evaluate(IChromosome chromosome)
    {
      var polygons = new List<Polygon>();

      foreach (var gene in chromosome.GetGenes())
      {
        var ms = new MemoryStream(gene.Value as byte[]);
        polygons.Add(Polygon.Parser.ParseFrom(ms));
//        var dnaPolygon = new DnaPolygon(polygon);

      }
      return FitnessCalculator.GetGeneFitness(polygons, _sourceColors);
    }
  }
}
