namespace Temperature.Model
{
    class CelsiusScale : IScale
    {
        public string Name => "°C";

        public double Degrees { get; set; }

        public double ConvertFromCelsius(double celsius)
        {
            return celsius;
        }

        public double ConvertToCelsius()
        {
            return Degrees;
        }
    }
}