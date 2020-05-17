using Temperature.Model;

namespace Temperature.Controller
{
    static class ScalesControl
    {
        public static IScale[] GetScales()
        {
            return new IScale[] { new CelsiusScale(), new FahrenheitScale(), new KelvinScale() };
        }
    }
}
