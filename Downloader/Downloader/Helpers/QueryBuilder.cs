using System;
using System.Linq;

namespace Downloader.Helpers
{
    public class QueryBuilder
    {
        public QueryBuilder(string table)
        {
            Table = table;
        }

        public string Table { get; set; }
        private const string _baseAddress = @"http://query.yahooapis.com/v1/public/yql?q=";
        private const string _json = " &format=json";
        private const string _tableDescription = @"&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";
        private const string _callback = @"&callback=";

        public string GetQuery(QueryParameter parameter, bool asEscapedDataString)
        {
            //var sb = new StringBuilder();
            //sb.Append(@"select%20*%20from%20");
            //sb.Append(table);
            //sb.Append("%20");
            //sb.Append(parameter.Name);
            //sb.Append("=");
            //sb.Append(parameter.Value);
            string query = string.Format(@"select * from {0} where {1}", Table, parameter.ParameterString);
            if (asEscapedDataString)
                return Uri.EscapeDataString(query);
            return query;
        }

        public string GetQuery(QueryParameter[] parameters, bool asEscapedDataString)
        {
            var parameterString = string.Join(" and ", parameters.Select(p=>p.ParameterString));
            return BuildQuery(asEscapedDataString, parameterString);
        }

        private string BuildQuery( bool asEscapedDataString, string parameterString)
        {
            string query = string.Format(@"select * from {0} where {1}", Table, parameterString);
            if (asEscapedDataString)
                return Uri.EscapeDataString(query);
            return query;
        }

        public string GetUrl(QueryParameter parameter, ReturnType returnType = ReturnType.Json)
        {
            string ret = returnType == ReturnType.Json ? _json : "";
            var url = _baseAddress + GetQuery(parameter, true) + ret + _tableDescription + _callback;
            return url;
        }


        public string GetUrl(QueryParameter[] parameters, ReturnType returnType = ReturnType.Json)
        {
            string ret = returnType == ReturnType.Json ? _json : "";
            var url = _baseAddress + GetQuery(parameters, true) + ret + _tableDescription + _callback;
            return url;
        }
    }
}
