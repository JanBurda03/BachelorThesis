
public class PackingVectorDifferentialEvolutionTriple : PackingVectorDifferentialEvolution
{
    protected readonly double _scaleFactor;
    public PackingVectorDifferentialEvolutionTriple(IReadOnlyList<PackingVector> initialPopulation, IMultipleFitnessEvaluator<PackingVector> fitnessEvaluator, DifferentialEvolutionTripleAlgorithmSetting setting, IEvolutionData<PackingVector>? data = null):base(initialPopulation, fitnessEvaluator, setting, data)
    {
        _scaleFactor = setting.ScaleFactor;
    }

    protected override PackingVector GetDonor()
    {
        // donor is created from three randomly selected packing vectors using arithmetic operations

        PackingVector v1 = _selector.Select(CurrentGenerationPopulation, CurrentGenerationFitness, 1).individual;
        PackingVector v2 = _selector.Select(CurrentGenerationPopulation, CurrentGenerationFitness, 1).individual;
        PackingVector v3 = _selector.Select(CurrentGenerationPopulation, CurrentGenerationFitness, 1).individual;

        return v1 + _scaleFactor * (v2 - v3);

        
    }
}