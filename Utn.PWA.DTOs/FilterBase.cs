using System;
namespace Utn.PWA.DTOs
{
    public abstract class FilterBase : ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public FilterBase()
        {
            this.Page = 1;
            this.Limit = 100;
        }

        public abstract object Clone();
    }
}
