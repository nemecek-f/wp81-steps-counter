using System.Collections.Generic;
using Steppy.BusinessLayer.Models;

namespace Steppy.BusinessLayer.Interfaces
{
    public interface IStepStatsProvider
    {
        int StepsToday { get; }
        IEnumerable<StepsHistory> StepsHistory { get; }
    }
}