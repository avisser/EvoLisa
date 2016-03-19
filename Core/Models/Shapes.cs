using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenArt.Classes;

namespace GenArt.Core.Models
{
  public class BrushData
  {
    public int Red { get; set; }
    public int Green { get; set; }
    public int Blue { get; set; }
    public int Alpha { get; set; }

    public void Mutate()
    {
      if (Tools.WillMutate(Settings.ActiveRedMutationRate))
      {
        Red = Tools.GetRandomNumber(Settings.ActiveRedRangeMin, Settings.ActiveRedRangeMax);
      }

      if (Tools.WillMutate(Settings.ActiveGreenMutationRate))
      {
        Green = Tools.GetRandomNumber(Settings.ActiveGreenRangeMin, Settings.ActiveGreenRangeMax);
      }

      if (Tools.WillMutate(Settings.ActiveBlueMutationRate))
      {
        Blue = Tools.GetRandomNumber(Settings.ActiveBlueRangeMin, Settings.ActiveBlueRangeMax);
      }

      if (Tools.WillMutate(Settings.ActiveAlphaMutationRate))
      {
        Alpha = Tools.GetRandomNumber(Settings.ActiveAlphaRangeMin, Settings.ActiveAlphaRangeMax);
      }
    }
  }

  public class PointData
  {
    public int X { get; set; }
    public int Y { get; set; }

    public void Mutate()
    {
      if (Tools.WillMutate(Settings.ActiveMovePointMaxMutationRate))
      {
        X = Tools.GetRandomNumber(0, Tools.MaxWidth);
        Y = Tools.GetRandomNumber(0, Tools.MaxHeight);
      }

      if (Tools.WillMutate(Settings.ActiveMovePointMidMutationRate))
      {
        X =
          Math.Min(
            Math.Max(0,
              X +
              Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMid,
                Settings.ActiveMovePointRangeMid)), Tools.MaxWidth);
        Y =
          Math.Min(
            Math.Max(0,
              Y +
              Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMid,
                Settings.ActiveMovePointRangeMid)), Tools.MaxHeight);
      }

      if (Tools.WillMutate(Settings.ActiveMovePointMinMutationRate))
      {
        X =
          Math.Min(
            Math.Max(0,
              X +
              Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMin,
                Settings.ActiveMovePointRangeMin)), Tools.MaxWidth);
        Y =
          Math.Min(
            Math.Max(0,
              Y +
              Tools.GetRandomNumber(-Settings.ActiveMovePointRangeMin,
                Settings.ActiveMovePointRangeMin)), Tools.MaxHeight);
      }
    }
  }

  public class Polygon
  {
    public BrushData Brush { get; set; }
    public List<PointData> Points { get; set; }

    public Polygon()
    {
      Points = new List<PointData>();
    }

    public void AddPoint()
    {
      Points.Add(PolygonChromosome.RandomPoint());
    }

    public void RemovePoint()
    {
      if (Points.Count == 3)
      {
        return;
      }
      int victim = Tools.GetRandomNumber(0, Points.Count - 1);
      Points.RemoveAt(victim);
    }
  }
}

//syntax = "proto3";
//
//message Polygon {
//  BrushData brush = 1;
//  repeated PointData points = 2;
//}
//
//message PointData {
//  int32 x = 1;
//  int32 y = 2;
//}
//
//message BrushData {
//  int32 Red = 1;
//  int32 Green = 2;
//  int32 Blue = 3;
//  int32 Alpha = 4;
//}