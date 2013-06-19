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
        private const string _diagnostics = @"&diagnostics=true";

        public string GetQuery(QueryParameter parameter, bool asEscapedDataString)
        {
            //var sb = new StringBuilder();
            //sb.Append(@"select%20*%20from%20");
            //sb.Append(table);
            //sb.Append("%20");
            //sb.Append(parameter.Name);
            //sb.Append("=");
            //sb.Append(parameter.Value);
            if (parameter == null)
                parameter = QueryParameter.Empty;
            return BuildQuery(parameter.ParameterString, asEscapedDataString);
        }

        public string GetQuery(QueryParameter[] parameters, bool asEscapedDataString)
        {
            if (parameters.Length < 2)
                throw new ArgumentException("more than one parameter required when passing an array of parameters");
            var parameterString = string.Join(" and ", parameters.Select(p => p.ParameterString));
            return BuildQuery(parameterString, asEscapedDataString);
        }

        private string BuildQuery(string parameterString, bool asEscapedDataString)
        {
            string query = string.IsNullOrEmpty(parameterString)
                               ? string.Format(@"select * from {0}", Table)
                               : string.Format(@"select * from {0} where {1}", Table, parameterString);
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

        public string GetUrl(ReturnType returnType = ReturnType.Json)
        {
            string ret = returnType == ReturnType.Json ? _json : "";
            var url = _baseAddress + GetQuery((QueryParameter)null, true) + ret + _tableDescription + _callback;
            return url;
        }
    }
}
