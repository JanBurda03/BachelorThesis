public record class EvolutionaryAlgorithmSetting
{
    public EvolutionaryAlgorithmSetting(int? hardStop, bool minimizing)
    {
        HardStop = hardStop;
        Minimizing = minimizing;
    }

    public bool Minimizing { get; init; }
    public int? HardStop { get; init; }

}
