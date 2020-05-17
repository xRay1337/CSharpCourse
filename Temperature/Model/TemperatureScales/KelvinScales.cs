namespace Temperature.Model
{
    class KelvinScale : IScale
    {
        public string Name => "°K";

        public double Degrees { get; set; }

        public double ConvertFromCelsius(double celsius)
        {
            return celsius + 273.15;
        }

        public double ConvertToCelsius()
        {
            return Degrees - 273.15;
        }
    }
}