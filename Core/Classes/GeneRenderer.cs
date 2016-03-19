using System.Collections.Generic;
using System.Drawing;
using GenArt.AST;
using GenArt.Core.Models;

namespace GenArt.Classes
{
  public static class GeneRenderer
  {
    //Render a Drawing
    public static void Render(IEnumerable<Polygon> polygons, Graphics g, int scale)
    {
      g.Clear(Color.Black);

      foreach (Polygon polygon in polygons)
        Render(polygon, g, scale);
    }

    //Render a polygon
    private static void Render(Polygon polygon, Graphics g, int scale)
    {
      var brush = GetGdiBrush(polygon.Brush);

      var points = GetGdiPoints(polygon.Points, scale);
      g.FillPolygon(brush, points); //(brush, points);
    }

    //Convert a list of DnaPoint to a list of System.Drawing.Point's
    private static Point[] GetGdiPoints(IList<PointData> points, int scale)
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
    private static System.Drawing.Brush GetGdiBrush(BrushData b)
    {
      return new SolidBrush(Color.FromArgb(b.Alpha, b.Red, b.Green, b.Blue));
    }
  }
}