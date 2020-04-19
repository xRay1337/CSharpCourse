namespace Temperature
{
    class Celsius : IScales
    {
        private double degrees;

        public Celsius(double degrees)
        {
            if (degrees < -273.15)
            {
                this.degrees = -273.15;
            }
            else
            {
                this.degrees = degrees;
            }
        }

        public double GetCelsius()
        {
            return degrees;
        }

        public double GetFahrenheit()
        {
            return degrees * 1.8 + 32;
        }

        public double GetKelvin()
        {
            return degrees + 273.15;
        }
    }
}