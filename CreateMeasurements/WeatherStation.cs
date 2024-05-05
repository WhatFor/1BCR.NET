namespace CreateMeasurements;

public record WeatherStation(string Id, double MeanTemperature)
{
    public double Measurement(Random rand)
    {
        var u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
        var u2 = 1.0 - rand.NextDouble();
        var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
        var randNormal = MeanTemperature + 10 * randStdNormal;

        return Math.Round(randNormal * 10.0) / 10.0;
    }
}