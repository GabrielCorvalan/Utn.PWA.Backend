﻿using System;
using System.Collections.Generic;

namespace Utn.PWA.DTOs
{
    public class PagedCollectionResponse<T> where T: class
    {
        public IEnumerable<T> Items { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
    }
}
