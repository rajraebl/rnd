using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare.Utilities.Azure.RedisCache.Common
{
    public enum CommandOperation : byte
    {
        None = 0,
        Error = 1,
        CleanFullCache = 2,
        CleanNamedCache = 3,
        CleanRegion = 4,
        Help = 5
    }

    public enum CacheName
    {
        DEFAULT = 0, PARTNERDATACACHE = 1, RESULTS = 2
    }
}
