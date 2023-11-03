using System.Collections.Generic;

namespace SamplePlugin.ClassConfigurations;

public abstract class BasicClass
{
    public Dictionary<string, TickBoxes> options = new Dictionary<string, TickBoxes>();

    public class TickBoxes
    {
        public TickBoxes(string boxDescription, bool reference)
        {
            this.boxDescription = boxDescription;
            test = reference;
        }

        public string boxDescription;
        public bool test;
    }
}
