namespace Temperature
{
    class Kelvin : IScales
    {
        private double degrees;

        public Kelvin(double degrees)
        {
            if (degrees < 0)
            {
                this.degrees = 0;
            }
            else
            {
                this.degrees = degrees;
            }
        }

        public double GetCelsius()
        {
            return degrees - 273.15;
        }

        public double GetFahrenheit()
        {
            return (degrees - 273.15) * 0.55555556 + 32;
        }

        public double GetKelvin()
        {
            return degrees;
        }
    }
}