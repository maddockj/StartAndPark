using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StartAndPark.Domain
{
    public class Tier
    {
        public static readonly ReadOnlyCollection<string> TIERS = 
            new List<string>{ "A", "B", "C", "D" }.AsReadOnly();
    }
}
