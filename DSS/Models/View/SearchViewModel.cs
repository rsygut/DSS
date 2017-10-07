using Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DSS.Models.View
{
    public class SearchViewModel
    {
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [Range(0, Double.PositiveInfinity)]
        [DisplayName("Głebokość")]
        public double? Depth { get; set; }
        [Range(0, Double.PositiveInfinity)]
        [DisplayName("Widoczność")]
        public double? Visibility { get; set; }
        public RequiredPermission? Permission { get; set; }
        public Access? Access { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<Place> Places { get; set; }

        public string County { get; set; }
        public string Province { get; set; }

        public List<string> Counties { get; set; }
        public List<string> Provincies { get; set; }
    }
}