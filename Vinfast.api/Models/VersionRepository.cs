using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinfast.models;

namespace Vinfast.api.Models
{
    public class VersionRepository : IVersionRepository
    {
        private readonly AppDbContext appDbContext;
        public VersionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public version GetVersion(int versionId)
        {
            return appDbContext.versions.FirstOrDefault(d => d.VersionId == versionId);
        }

        public IEnumerable<version> GetVersions()
        {
            return appDbContext.versions;
        }
    }
}
