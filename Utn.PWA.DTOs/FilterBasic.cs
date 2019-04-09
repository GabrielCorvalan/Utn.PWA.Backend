using System;
using Newtonsoft.Json;

namespace Utn.PWA.DTOs
{
    public class FilterBasic : FilterBase
    {
        public string Term { get; set; }

        public FilterBasic() : base()
        {
            this.Limit = 3;
        }


        public override object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
}
