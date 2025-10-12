public readonly record struct GenerationData<T>
{
    public GenerationData(int generationNumber, double bestFitness, double averageFitness)
    {
        GenerationNumber = generationNumber;
        BestFitness = bestFitness;
        AverageFitness = averageFitness;
    }

    public int GenerationNumber { get; init; }
    public readonly double BestFitness { get; init; }
    public readonly double AverageFitness { get; init; }
}