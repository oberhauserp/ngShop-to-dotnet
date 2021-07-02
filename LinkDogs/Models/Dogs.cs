using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace App
{
    public class Dog
    {
        public string id { get; set; }
        public string name { get; set; }
        public string thumbnail { get; set; }
        public string image { get; set; }
    }
}