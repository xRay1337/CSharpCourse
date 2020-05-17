namespace Temperature.Model
{
    class FahrenheitScale : IScale
    {
        public string Name => "°F";

        public double Degrees { get; set; }

        public double ConvertFromCelsius(double celsius)
        {
            return (celsius * (5.0 / 9.0)) + 32;
        }

        public double ConvertToCelsius()
        {
            return (Degrees - 32) * (5.0 / 9.0);
        }
    }
}