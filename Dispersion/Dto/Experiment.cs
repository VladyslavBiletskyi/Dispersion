using System.Collections.Generic;

namespace Dispersion.Dto
{
    class Experiment
    {
        public int Number { get; set; }

        public IList<double> Results { get; set; }
    }
}
