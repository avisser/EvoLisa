﻿using System.Drawing;
using AutoMapper;
using GenArt.AST;
using GenArt.Core.Models;

namespace GenArt.Core
{
  public class AutomapperConfig
  {
    public static void Setup()
    {
      Mapper.CreateMap<PointData, DnaPoint>();

      Mapper.CreateMap<BrushData, DnaBrush>();

    }
  }
}
