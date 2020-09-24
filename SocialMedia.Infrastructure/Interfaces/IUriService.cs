using System;
using SocialMedia.Core.QueryFilters;

namespace SocialMedia.Infrastruncture.Interfaces
{
    public interface IUriService
    {
        Uri getPostPaginatedUri(PostQueryFilter filter, string actionUrl);
    }
}