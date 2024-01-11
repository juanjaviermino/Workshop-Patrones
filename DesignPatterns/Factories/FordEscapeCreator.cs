using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    public class FordEscapeCreator : Creator
    {
        public override Vehicle Create()
        {
            var builder = new CarBuilder();
            return builder
                .SetModel("Escape").
                SetColor("Red").
                Build();
        }
    }
}
