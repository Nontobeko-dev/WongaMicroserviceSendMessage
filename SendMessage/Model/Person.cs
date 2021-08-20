using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SendMessage.Model
{
    class Person
    {
        [Required]
        public string name { get; set; }
    }
}
