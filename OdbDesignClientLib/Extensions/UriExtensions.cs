using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Odb.Client.Lib.Extensions
{
    public static class UriExtensions
    {
        public static string GetQueryParameter(this Uri uri, string key)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            //var queryParams = HttpUtility.ParseQueryString(NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query);
            //var returnUrl = queryParams[RETURN_URL_QUERY_NAME] ?? "";

            return default;
        }
    }
}
