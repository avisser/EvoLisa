using System;
using System.Drawing;
using System.IO;
using System.Text;
using GenArt.Classes;
using GeneticSharp.Domain.Chromosomes;
using Google.Protobuf;

namespace GenArt.Core.Models
{
  public class DrawingChromosome : ChromosomeBase
  {
    public static int MaxPoints { get; set; }
    public static int Height { get; set; }
    public static int Width { get; set; }

    public DrawingChromosome(int length) : base(length)
    {
    }

    public override Gene GenerateGene(int geneIndex)
    {
      var p = new Polygon {Brush = RandomBrush()};
      var points = RandomPointCount();
      for (int i = 0; i < points; i++)
      {
        p.Points.Add(RandomPoint());
      }

      using (var ms = new MemoryStream())
      {
        p.WriteTo(new CodedOutputStream(ms));
        return new Gene(ms);
      }
    }

    private PointData RandomPoint()
    {
      return new PointData()
      {
        X = Tools.GetRandomNumber(0, Height-1),
        Y = Tools.GetRandomNumber(0, Width-1)
      };
    }

    private int RandomPointCount()
    {
      return Tools.GetRandomNumber(3, 10);
    }

    private BrushData RandomBrush()
    {
      return new BrushData()
      {
        Red = Tools.GetRandomNumber(0, 255),
        Green = Tools.GetRandomNumber(0, 255),
        Blue = Tools.GetRandomNumber(0, 255),
        Alpha = Tools.GetRandomNumber(10, 60)
      };
    }

    public override IChromosome CreateNew()
    {
      throw new System.NotImplementedException();
    }
  }
}
