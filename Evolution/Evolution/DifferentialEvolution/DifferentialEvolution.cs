

public class DifferentialEvolution<T> : EvolutionaryBase<T>
{

    protected readonly int _tournamentSize;

    protected readonly IUniformCrossover<T> _crossover;
    protected readonly TournamentSelector<T> _selector;

    public DifferentialEvolution(IReadOnlyList<T> initialPopulation, IMultipleFitnessEvaluator<T> fitnessEvaluator, IUniformCrossover<T> crossover, int tournamentSize, DifferentialEvolutionAlgorithmSetting setting, IEvolutionData<T>? data = null): base(initialPopulation, fitnessEvaluator, setting, data)
    {
        _tournamentSize = tournamentSize;

        _crossover = crossover;

        _selector = new TournamentSelector<T>(_fitnessComparer);

    }



    protected override void NextGeneration()
    {
        CurrentGeneration++;

        // selecting individuals to be mutated
        IReadOnlyList<T> selected = _selector.SelectMultiple(CurrentGenerationPopulation, CurrentGenerationFitness, CurrentGenerationPopulation.Count, _tournamentSize).individuals;

        // mutation and their evaluation
        IReadOnlyList<T> crossovered = Crossover(selected);
        IReadOnlyList<double> crossoveredFitness = _fitnessEvaluator.EvaluateFitnesses(crossovered);


        // indiviual replaces only if it is better that the original
        T[] newPopulation = new T[crossovered.Count];
        double[] newPopulationFitness = new double[crossoveredFitness.Count];

        for (int i = 0; i < newPopulation.Length; i++)
        {
            if (_fitnessComparer.Compare(crossoveredFitness[i], CurrentGenerationFitness[i]) < 0)
            {
                newPopulation[i] = crossovered[i];
                newPopulationFitness[i] = crossoveredFitness[i];
            }
            else
            {
                newPopulation[i] = CurrentGenerationPopulation[i];
                newPopulationFitness[i] = CurrentGenerationFitness[i];
            }
        }



        // new population consists of the selected and then evaluated individuals
        CurrentGenerationPopulation = newPopulation;
        CurrentGenerationFitness = newPopulationFitness;


       
    }

    protected IReadOnlyList<T> Crossover(IReadOnlyList<T> selected)
    {
        T[] mutated = new T[selected.Count];


        for (int i = 0;i < selected.Count; i++)
        {
            // uniformly mutating selected individual with random individual from the same generation (_selector.Select with tournament size 1 selects random individual)      

            mutated[i] = _crossover.Crossover(GetDonor(), selected[i]);
        }


        return mutated;
    }

    protected virtual T GetDonor()
    {
        // donor is a random packing vector from the population
        return _selector.Select(CurrentGenerationPopulation, CurrentGenerationFitness, 1).individual;
    }
}




