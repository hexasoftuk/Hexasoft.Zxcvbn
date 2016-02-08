namespace Hexasoft.Zxcvbn
{
    public interface IZxcvbnEstimator
    {
        EstimationResult EstimateStrength(string password);
    }
}
