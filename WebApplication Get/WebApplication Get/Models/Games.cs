using System;
using System.Collections.Generic;

namespace WebApplication_Get.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Release { get; set; }
        public string Country { get; set; }
        public string Studio  { get; set; }
        public string Age_Classification { get; set; }

        public static implicit operator List<object>(Games v)
        {
            throw new NotImplementedException();
        }
    }
}
