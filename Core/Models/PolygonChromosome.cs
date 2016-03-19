using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using GenArt.Classes;
using GeneticSharp.Domain.Chromosomes;
using Google.Protobuf;

namespace GenArt.Core.Models
{
  public class PolygonChromosome : ChromosomeBase
  {
    private int _activeGenes;
    const int LENGTH = 50;
    public PolygonChromosome() :base(LENGTH)
    {
      _activeGenes = Tools.GetRandomNumber(2, LENGTH);
      for (int i = 0; i < LENGTH; i++)
      {
        ReplaceGene(i, GenerateGene(i));
      }
    }

    public override Gene GenerateGene(int geneIndex)
    {
      var p = new Polygon {Brush = RandomBrush()};
      var points = RandomPointCount();
      for (int i = 0; i < points; i++)
      {
        p.Points.Add(RandomPoint());
      }

      var g = new Gene(p);
      return g;
    }

//    public List<Polygon> GetPolygons()
//    {
//      var polygons = new List<Polygon>();
//      var genes = GetGenes();
//      for (int i = 0; i < _activeGenes; i++)
//      {
//        var ms = new MemoryStream(genes[i].Value as byte[]);
//        polygons.Add(Polygon.Parser.ParseFrom(ms));
//      }
//      return polygons;
//    }

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

    public static BrushData RandomBrush()
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

    public void Mutate(float probability)
    {
      foreach (var polygon in GetPolygons())
      {
//        polygon.
      }
    }

    public IEnumerable<Polygon> GetPolygons()
    {
      return GetGenes().Select(g => g.Value as Polygon);
    }
  }
}
