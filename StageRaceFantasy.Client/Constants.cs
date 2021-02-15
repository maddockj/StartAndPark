using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartAndPark.Client
{
    public class Constants
    {
        public const int CUP_SERIES_ID = 1;
        public static readonly int YEAR = DateTime.Now.Year;

        public const int RACE_TYPE_POINTS = 1;
        public const int RACE_TYPE_NONPOINTS = 2;

        public const int FLAG_STATE_GREEN = 1;
        public const int FLAG_STATE_YELLOW = 2;
    }
}
