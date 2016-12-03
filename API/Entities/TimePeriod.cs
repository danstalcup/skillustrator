using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skillustrator.Api.Entities
{
    public class TimePeriod : LookupBase
    {
        public const string LessThanOneMonth = "LESS_ONE_MONTH";

        public const string OneToSixMonths = "ONE_TO_SIX_MONTHS";

        public const string SixToTwelveMonths = "SIX_TO_TWELVE_MONTHS";

        public const string OneToTwoYears = "ONE_TO_TWO_YEARS";

        public const string MoreThanTwoYears = "MORE_TWO_YEARS";
    }
}
