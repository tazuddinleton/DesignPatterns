using System;
using System.Collections.Generic;
using System.Text;

namespace SpecificationPattern.ValueObjects
{
    // Kids' movies are rated G or PG
    public enum MpaaRating
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4
    }
}
