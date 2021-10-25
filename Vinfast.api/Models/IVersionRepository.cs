using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;

namespace Vinfast.api.Models
{
    interface IVersionRepository
    {
        IEnumerable<version> GetVersions();
        version GetVersion(int versionId);

    }
}
