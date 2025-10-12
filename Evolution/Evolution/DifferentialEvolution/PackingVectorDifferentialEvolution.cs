public class PackingVectorDifferentialEvolution : DifferentialEvolution<PackingVector>
{    
    public PackingVectorDifferentialEvolution(IReadOnlyList<PackingVector> initialPopulation, IMultipleFitnessEvaluator<PackingVector> fitnessEvaluator, DifferentialEvolutionAlgorithmSetting setting, IEvolutionData<PackingVector>? data = null) : base(initialPopulation, fitnessEvaluator, new PackingVectorUniformCrossover(setting.AverageElementsChanged), setting.TournamentSize, setting, data)
    {}
}