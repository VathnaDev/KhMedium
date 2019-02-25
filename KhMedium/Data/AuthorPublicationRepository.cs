using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Entities;

namespace KhMedium.Data
{
    public class AuthorPublicationRepository : Repository<AuthorPublication>, IAuthorPublicationRepository
    {
        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;

        public AuthorPublicationRepository(DbContext context) : base(context)
        {
        }
    }
}