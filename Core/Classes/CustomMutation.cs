using GenArt.Classes;
using GenArt.Core.Models;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Mutations;

namespace GenArt.Core.Classes
{
  public class CustomMutation : MutationBase
  {
    protected override void PerformMutate(IChromosome chromosome, float probability)
    {
      var poly = chromosome as PolygonChromosome;
      poly.Mutate(probability);
    }
  }
}
