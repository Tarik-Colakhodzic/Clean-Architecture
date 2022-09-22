using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Movie : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
