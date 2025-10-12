public static class EvolutionaryAlgorithms
{

    private static readonly Dictionary<
        string,
        Func<IReadOnlyList<PackingVector>, IMultipleFitnessEvaluator<PackingVector>, EvolutionaryAlgorithmSetting, IEvolutionData<PackingVector>?, 
            IEvolutionary<PackingVector>>
    > EvolutionaryAlgorithmDictionary = new()
    {
        { "Differential Evolution",
            (population, fitnessEvaluator, setting, evolutionData) =>
                new PackingVectorDifferentialEvolution(population, fitnessEvaluator, (DifferentialEvolutionAlgorithmSetting)setting, evolutionData)
        },
        { "Differential Evolution Triple",
            (population, fitnessEvaluator, setting, evolutionData) =>
                new PackingVectorDifferentialEvolutionTriple(population, fitnessEvaluator, (DifferentialEvolutionTripleAlgorithmSetting)setting, evolutionData)
        },

    };

    public static string[] EvolutionaryAlgorithmsArray => EvolutionaryAlgorithmDictionary.Keys.ToArray();

    public static IEvolutionary<PackingVector> GetEvolutionaryAlgorithm(string name, IReadOnlyList<PackingVector> initialPopulation, IMultipleFitnessEvaluator<PackingVector> fitnessEvaluator, EvolutionaryAlgorithmSetting setting, IEvolutionData<PackingVector>? evolutionData)
    {
        if (EvolutionaryAlgorithmDictionary.TryGetValue(name, out var factory))
            return factory(initialPopulation, fitnessEvaluator, setting, evolutionData);

        throw new ArgumentException($"Unknown evolutionary algorithm: {name}");
    }
}
