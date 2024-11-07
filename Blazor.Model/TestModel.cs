using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace Blazor.Model
{
    [Table("TestModel")]
    public class TestModel: PersistPoco
    {
        [Display(Name = "name")]
        public string name { get; set; }

        [Display(Name = "age")]
        public int age { get; set; }
    }
}
