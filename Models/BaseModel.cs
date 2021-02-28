using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcBasic.Models
{
    /// <summary>
    /// 全てのモデルをここで定義（1回目）
    /// </summary>
    public class BaseModel
    {
        public int Id { get; set; }

        [DisplayName("氏名")]
        public string Name { get; set; }

        [DisplayName("メールアドレス")]
        public string Email { get; set; }

        [DisplayName("生年月日")]
        public DateTime? Birth { get; set; }

        [DisplayName("既婚")]
        public bool Married { get; set; }

        [DisplayName("自己紹介")]
        public string Memo { get; set; }


        public short Status { get; set; }
        public DateTime? Date{ get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Member> MemberList { get; set; }
        public IEnumerable<SelectListItem> SelectedMember { get; set; } = new List<SelectListItem>();
        public List<string> SelectedMemberKeyList { get; set; } = new List<string>();
        public List<string> SelectedMemberValueList { get; set; } = new List<string>();



        public IEnumerable<SelectListItem> UnSelectMember { get; set; } = new List<SelectListItem>();
        public List<string> UnSelectedMemberKeyList { get; set; } = new List<string>();
        public List<string> UnSelectedMemberValueList { get; set; } = new List<string>();



        public short UdFlg { get; set; }
        public short DelFlg { get; set; }
    }
}