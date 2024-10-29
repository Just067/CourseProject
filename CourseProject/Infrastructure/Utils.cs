namespace CourseProject.Infrastructure;

public static class Utils
{

    public static int GetRandom(int valueMin, int valueMax) => Random
        .Shared
        .Next(valueMin, valueMax + 1);

    public static double GetRandom(double valueMin, double valueMax) => Random
        .Shared
        .NextDouble() * (valueMin + (valueMax - valueMin));
}
