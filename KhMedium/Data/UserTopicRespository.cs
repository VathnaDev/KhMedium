using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using KhMedium.Data.Core;
using KhMedium.Entities;

namespace KhMedium.Data
{
    public class UserTopicRespository : Repository<UserTopic>, IUserTopicRepository
    {
        public UserTopicRespository(DbContext context) : base(context)
        {
        }

        public KhMediumEntities KhMediumContext => Context as KhMediumEntities;
    }
}