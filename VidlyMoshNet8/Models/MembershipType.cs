﻿using System.ComponentModel.DataAnnotations;

namespace VidlyMoshNet8.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFree { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
