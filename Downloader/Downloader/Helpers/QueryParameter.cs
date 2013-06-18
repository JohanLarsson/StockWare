﻿using System.Linq;

namespace Downloader.Helpers
{
    public class QueryParameter
    {
        public QueryParameter(string name, string value)
        {
            Name = name;
            Values =new string[]{ value};
        }

        public QueryParameter(string name, string[] values)
        {
            Name = name;
            Values = values;
        }

        public string Name { get; private set; }
        public string[] Values { get; private set; }


        public string ParameterString
        {
            get
            {
                if(Values.Length==1)
                    return string.Format("{0}='{1}'", Name, Values[0]);
                return string.Format("{0} in ({1})", Name, string.Join(",", Values.Select(v => "'" + v + "'")));
            }
        }
    }
}