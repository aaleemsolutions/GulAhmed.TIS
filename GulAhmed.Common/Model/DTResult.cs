﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Common.Model
{
    public class DTResult<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; } = new List<T>();
    }

    public abstract class DTRow
    {
        public virtual string DT_RowId
        {
            get { return null; }
        }

        public virtual string DT_RowClass
        {
            get { return null; }
        }
        public virtual object DT_RowData
        {
            get { return null; }
        }
    }

    public class DTParameters
    {
        public int Draw { get; set; }
        public List<DTColumn> Columns { get; set; }
        public List<DTOrder> Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DTSearch Search { get; set; } = new DTSearch();
        public string SortOrder
        {
            get
            {
                return Columns != null && Order != null && Order.Count > 0
                    ? (Columns[Order[0].Column].Data + (Order[0].Dir == DTOrderDir.DESC ? " " + Order[0].Dir : string.Empty))
                    : null;
            }
        }
    }

    public class DTColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DTSearch Search { get; set; } = new DTSearch();
    }

    public class DTOrder
    {
        public int Column { get; set; }
        public DTOrderDir Dir { get; set; }
    }

    public enum DTOrderDir
    {
        ASC,
        DESC
    }

    public class DTSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
}
