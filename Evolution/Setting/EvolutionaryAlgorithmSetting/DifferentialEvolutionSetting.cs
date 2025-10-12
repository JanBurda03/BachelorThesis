public record DifferentialEvolutionAlgorithmSetting : EvolutionaryAlgorithmSetting
{
    public int TournamentSize {  get; init; }
    public double AverageElementsChanged { get; init; }

    public DifferentialEvolutionAlgorithmSetting(int hardStop, bool minimizing, int tournamentSize, double averageElementsChanged) : base(hardStop, minimizing)
    {
        if (tournamentSize <= 0)
        {
            throw new ArgumentException("Tournament Size must always be greater than 0");
        }

        TournamentSize = tournamentSize;
        AverageElementsChanged = averageElementsChanged;
    }
}