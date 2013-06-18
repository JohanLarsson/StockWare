using System;
using System.Linq;
using System.Text;

namespace Downloader
{
    public class QueryBuilder
    {
        private const string _baseAddress = @"http://query.yahooapis.com/v1/public/yql?q=";
        private const string _json = " &format=json";
        private const string _tables = @"&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        private const string _callback = @"&callback=";

        public string GetQuery(string table, QueryParameter parameter, bool asEscapedDataString)
        {
            //var sb = new StringBuilder();
            //sb.Append(@"select%20*%20from%20");
            //sb.Append(table);
            //sb.Append("%20");
            //sb.Append(parameter.Name);
            //sb.Append("=");
            //sb.Append(parameter.Value);
            string query = string.Format(@"select * from {0} where {1}", table, BuildParameterString(parameter));
            if (asEscapedDataString)
                return Uri.EscapeDataString(query);
            return query;
        }

        public string GetQuery(string table, QueryParameter[] parameters, bool asEscapedDataString)
        {
            var parameterString = string.Join(" and ", parameters.Select(BuildParameterString));
            return BuildQuery(table, asEscapedDataString, parameterString);
        }

        private string BuildParameterString(QueryParameter parameter)
        {
            return string.Format("{0}='{1}'", parameter.Name, parameter.Value);
        }

        private static string BuildQuery(string table, bool asEscapedDataString, string parameterString)
        {
            string query = string.Format(@"select * from {0} where {1}", table, parameterString);
            if (asEscapedDataString)
                return Uri.EscapeDataString(query);
            return query;
        }

        public string GetUrl(string table, QueryParameter parameter, ReturnType returnType = ReturnType.Json)
        {
            string ret = returnType == ReturnType.Json ? _json : "";
            var url = _baseAddress + GetQuery(table, parameter, true) + ret + _tables + _callback;
            return url;
        }


    }

    public enum ReturnType
    {
        Json,
        Xml
    }
}
