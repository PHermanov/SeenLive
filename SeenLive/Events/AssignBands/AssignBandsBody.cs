using System;
using System.Collections.Generic;

namespace SeenLive.Events.AssignBands;

public class AssignBandsBody
{
    public HashSet<int> BandIds { get; init; } = new();
}