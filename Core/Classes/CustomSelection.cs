using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using GenArt.Core.Models;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;

namespace GenArt.Core.Classes
{
  public class CustomSelection : SelectionBase
  {
    public CustomSelection(int minNumberChromosomes) : base(minNumberChromosomes)
    {
    }

    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {
      var results = generation.Chromosomes.OrderBy(c => c.Fitness).Take(number).ToList();

      results.Skip(number/2).Each(c => (c as PolygonChromosome).Mutate());

      return results;
    }
  }
}
