using System;
using System.Collections.Generic;

namespace RithV.FX.EntityDTO
{
    public class RequestObject<TWc> where TWc : class
    {
        public List<GenericFilter> Filters { get; set; }
        public TWc ReqObject { get; set; }
        public bool IsFilter { get; set; }

        public RequestObject()
        {
            Filters = new List<GenericFilter>();
        }

    }

    public class GenericFilter
    {
        public Conditions Condition { get; set; }

        public string ColumnName { get; set; }

        public dynamic ColumnData { get; set; }
        public dynamic ColumnData2 { get; set; }

        public Type ColumnType { get; set; }

        public bool HasValue { get; set; }
    }

    public enum Conditions
    {
        And = 0,
        Or = 1,
        Between = 2,
        Lessthan = 3,
        Greaterthan = 4,
        Like = 5
    }
}