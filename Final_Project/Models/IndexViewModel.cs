using Final_Project.Models;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PL.Models
{
    public class IndexViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}