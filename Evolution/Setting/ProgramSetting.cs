
public readonly record struct ProgramSetting
{
    public ProgramSetting(IOSetting iOSetting, PackingSetting packingSetting, EvolutionSetting evolutionSetting, EvolutionaryAlgorithmSetting evolutionAlgorithmSetting)
    {
        IOSetting = iOSetting;
        PackingSetting = packingSetting;
        EvolutionSetting = evolutionSetting;
        EvolutionAlgorithmSetting = evolutionAlgorithmSetting;
    }

    public IOSetting IOSetting { get; init; }
    public PackingSetting PackingSetting { get; init; }

    public EvolutionSetting EvolutionSetting { get; init; }

    public EvolutionaryAlgorithmSetting EvolutionAlgorithmSetting { get; init; }

    
}

public readonly record struct IOSetting
{ 
    public IOSetting(string sourceJson, string outputJson)
    {
        SourceJson = sourceJson;
        OutputJson = outputJson;
    }
    public string SourceJson { get; init; }
    public string OutputJson { get; init; }
}

public readonly record struct EvolutionSetting
{
    public string AlgorithmName { get; init; }

    public int NumberOfIndividuals { get; init; }

    public int NumberOfGenerations { get; init; }

    public int NumberOfPOHIndividuals { get; init; }



    public string OrderHeuristics { get; init; }

    public bool ShowGraph { get; init; }

    public string EvolutionStatisticsJSON { get; init; }


    public EvolutionSetting(string algorithmName, int numberOfIndividuals, int numberOfGenerations, int numberOfPOHIndividuals, string orderHeuristics, bool showGraph, string evolutionStatisticsJSON)
    {
        AlgorithmName = algorithmName;
        NumberOfIndividuals = numberOfIndividuals;
        NumberOfGenerations = numberOfGenerations;
        NumberOfPOHIndividuals = numberOfPOHIndividuals;
        OrderHeuristics = orderHeuristics;
        ShowGraph = showGraph;
        EvolutionStatisticsJSON = evolutionStatisticsJSON;
    }
}