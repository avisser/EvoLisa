using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GenArt.AST;
using GenArt.Classes;
using GenArt.Core.Models;
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
      var polyChrome = chromosome as PolygonChromosome;
      return FitnessCalculator.GetGeneFitness(polyChrome.GetPolygons(), _sourceColors);
    }
  }
}
