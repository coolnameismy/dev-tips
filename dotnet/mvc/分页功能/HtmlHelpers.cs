using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Objects.DataClasses;

namespace BiosealMVCWeb.Models
{
    public static class HtmlHelpers
    {
        public static string UrlSet(this HtmlHelper helper, HttpRequestBase request, string queryName, object queryValue)
        {
            if (queryName != null && queryValue != null)
            {
                string path = request.Path;
                NameValueCollection query = new NameValueCollection(request.QueryString);
                query.Set(queryName, queryValue.ToString());
                return CreateUrl(path, query);
            }
            return request.RawUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="request"></param>
        /// <param name="queryName"></param>
        /// <param name="queryValue"></param>
        /// <returns></returns>
        public static string UrlAdd(this HtmlHelper helper, HttpRequestBase request, string queryName, object queryValue)
        {
            if (queryName != null && queryValue != null)
            {
                string path = request.Path;
                NameValueCollection query = new NameValueCollection(request.QueryString);
                query.Add(queryName, queryValue.ToString());
                return CreateUrl(path, query);
            }
            return request.RawUrl;
        }

        public static string UrlRemove(this HtmlHelper helper, HttpRequestBase request, string queryName)
        {
            if (queryName != null)
            {
                string path = request.Path;
                NameValueCollection query = new NameValueCollection(request.QueryString);
                query.Remove(queryName);
                return CreateUrl(path, query);
            }
            return request.RawUrl;
        }

        public static string UrlRemove(this HtmlHelper helper, HttpRequestBase request, string queryName, object queryValue)
        {
            if (queryName != null && queryValue != null)
            {
                string path = request.Path;
                NameValueCollection query = new NameValueCollection(request.QueryString);

                string[] values = query.GetValues(queryName);
                List<string> vs = values.ToList();
                vs.Remove(queryValue.ToString());
                query.Remove(queryName);
                foreach (var item in vs)
                {
                    query.Add(queryName, item);
                }

                return CreateUrl(path, query);
            }
            return request.RawUrl;
        }

        private static string CreateUrl(string path, NameValueCollection query)
        {
            string url = path;
            if (query != null && query.Count != 0)
            {
                url += "?";
                for (int i = 0; i < query.Count; i++)
                {
                    string key = query.GetKey(i);
                    string[] values = query.GetValues(key);
                    for (int j = 0; j < values.Length; j++)
                    {
                        url += key + "=" + values[j] + "&";
                    }
                }

                url = url.TrimEnd('&');
            }
            return url;
        }
    }
}