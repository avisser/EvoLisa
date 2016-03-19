using System;
using System.Drawing;
using System.IO;
using System.Text;
using GenArt.Classes;
using GeneticSharp.Domain.Chromosomes;
using Google.Protobuf;

namespace GenArt.Core.Models
{
  public class PolygonChromosome : ChromosomeBase
  {
    public static int MaxPoints { get; set; }
    public static int Height { get; set; }
    public static int Width { get; set; }

    public PolygonChromosome() : base(10)
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
        var g = new Gene(ms);
        return g;
      }
    }

    private PointData RandomPoint()
    {
      var point = new PointData();
      var randomX = Tools.GetRandomNumber(0, Tools.MaxWidth);
      var randomY = Tools.GetRandomNumber(0, Tools.MaxHeight);
      point.X = Math.Min(Math.Max(0, randomX + Tools.GetRandomNumber(-3, 3)), Tools.MaxWidth);
      point.Y = Math.Min(Math.Max(0, randomY + Tools.GetRandomNumber(-3, 3)), Tools.MaxHeight);

      return point;
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
      return new PolygonChromosome();
    }
  }
}
