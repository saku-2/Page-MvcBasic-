using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcBasic.Models
{
    public class Input
    {
        public string Str1 { get; set; }

        public string[] Str2 { get; set; }

        public bool Boo { get; set; }

        public EnumList Str3 { get; set; }
        public string Str4 { get; set; }
        public string Str5 { get; set; }
    }

    public enum EnumList
    {
        [Display(Name = "選択①")]
        Cd1,

        [Display(Name = "選択②")]
        Cd2,

        [Display(Name = "選択③")]
        Cd3
    }
}