namespace Temperature.Model
{
    interface IScale
    {
        string Name { get; }

        double Degrees { get; set; }

        double ConvertToCelsius();

        double ConvertFromCelsius(double celsius);
    }
}