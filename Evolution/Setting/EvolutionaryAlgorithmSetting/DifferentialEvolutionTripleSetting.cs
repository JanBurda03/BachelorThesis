

public record DifferentialEvolutionTripleAlgorithmSetting : DifferentialEvolutionAlgorithmSetting
{
    public double ScaleFactor {  get; init; }

    public DifferentialEvolutionTripleAlgorithmSetting(int hardStop, bool minimizing, int tournamentSize, double crossoverProbability, double scaleFactor) : base(hardStop, minimizing, tournamentSize, crossoverProbability)
    {
        ScaleFactor = scaleFactor;
    }

    
}