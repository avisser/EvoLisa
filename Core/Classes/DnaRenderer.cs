﻿using System;
using System.Collections.Generic;
using System.Drawing;
using GenArt.AST;

namespace GenArt.Classes
{
  public static class DnaRenderer
  {
    //Render a Drawing
    public static void Render(DnaDrawing drawing, Graphics g, int scale)
    {
      g.Clear(Color.Black);

      foreach (DnaPolygon polygon in drawing.Polygons)
        Render(polygon, g, scale);
    }

    //Render a polygon
    private static void Render(DnaPolygon polygon, Graphics g, int scale)
    {
      var brush = GetGdiBrush(polygon.Brush);

      var points = GetGdiPoints(polygon.Points, scale);
      try
      {
        g.FillPolygon(brush, points); //(brush, points);
      }
      catch (Exception e)
      {
        int i = 0;
        i++;
      }
    }

    //Convert a list of DnaPoint to a list of System.Drawing.Point's
    private static Point[] GetGdiPoints(IList<DnaPoint> points, int scale)
    {
      var pts = new Point[points.Count];
      int i = 0;
      foreach (var pt in points)
      {
        pts[i++] = new Point() {
          X = pt.X*scale, 
          Y = pt.Y*scale
        };
      }
      return pts;
    }

    //Convert a DnaBrush to a System.Drawing.Brush
    private static System.Drawing.Brush GetGdiBrush(DnaBrush b)
    {
      return new SolidBrush(Color.FromArgb(b.Alpha, b.Red, b.Green, b.Blue));
    }
  }
}