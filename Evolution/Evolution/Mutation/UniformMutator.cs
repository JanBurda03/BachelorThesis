public class PackingVectorUniformCrossover: IUniformCrossover<PackingVector>
{
    private readonly double _averageElementsChangedToFirst; 
    private readonly Random _random;

    public PackingVectorUniformCrossover(double averageElementsChangedToFirst)
    {

        _averageElementsChangedToFirst = averageElementsChangedToFirst;
        _random = new Random();
    }

    public PackingVector Crossover(PackingVector a, PackingVector b)
    {
        if (a.Count != b.Count)
            throw new ArgumentException("PackingVectors must have the same length!");

        double prob = _averageElementsChangedToFirst/a.Count;


        double[] result = new double[a.Count];
        for (int i = 0; i < a.Count; i++)
        {
            // uniform mutation means that every cell in the new individual is chosen from one of the two parents with certain probability
            if (_random.NextDouble() < prob)
            {
                result[i] = a[i];
            }
            else
            {
                result[i] = b[i];
            }

        }
        return new PackingVector(result);
    }
}