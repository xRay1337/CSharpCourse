namespace Temperature
{
    class Fahrenheit : IScales
    {
        private double degrees;

        public Fahrenheit(double degrees)
        {
            if (degrees < -459.67)
            {
                this.degrees = -459.67;
            }
            else
            {
                this.degrees = degrees;
            }
        }

        public double GetCelsius()
        {
            return (degrees - 32) * 0.55555556;
        }

        public double GetFahrenheit()
        {
            return degrees;
        }

        public double GetKelvin()
        {
            return (degrees - 32) * 0.55555556 + 273.15;
        }
    }
}