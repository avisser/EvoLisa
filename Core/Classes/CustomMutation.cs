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
      if (Tools.GetRandomNumber(0, 1000) > probability*1000)
      {
        var poly = chromosome as PolygonChromosome;
        poly.Mutate(probability);

      }
    }
  }
}
