﻿using System;
using System.Collections.Generic;

namespace KickoffProject.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Cdetails { get; set; }

        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
