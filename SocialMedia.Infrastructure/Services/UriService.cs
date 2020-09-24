using System;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastruncture.Interfaces;

namespace SocialMedia.Infrastruncture.Services
{
    public class UriService: IUriService
    {
        private readonly string baseUrl;
        public UriService(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public Uri getPostPaginatedUri(PostQueryFilter filter, string actionUrl)
        {
            string url = $"{baseUrl}{actionUrl}";
            return new Uri(url);
        }
        
    }
}