using System.Text.Json;

public class EvolutionStatistics<T>: IEvolutionData<T>
{
    // class used for gaining additional data from the evolution, for example for creating graphs
    public IReadOnlyList<GenerationData<T>> GenerationsFitnesses => _generationsFitnesses.AsReadOnly();

    private readonly List<GenerationData<T>> _generationsFitnesses = new List<GenerationData<T>>();
    public void Update(IReadOnlyList<T> currentPopulation, IReadOnlyList<double> currentFitness, (T, double) currentBest, (T, double) currentGenerationBest, int currentGeneration)
    {
        double average = currentFitness.Sum() / currentFitness.Count;

        _generationsFitnesses.Add(new GenerationData<T>(currentGeneration, currentGenerationBest.Item2, average));

        Console.WriteLine($"Best Fitness of Generation {currentGeneration} is {currentGenerationBest.Item2} with Average of {average}");
    }

    public void Save(string fileName)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(_generationsFitnesses, options);
        File.WriteAllText(fileName, json);
    }
}


