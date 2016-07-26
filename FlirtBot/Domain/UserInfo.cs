using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlirtBot
{
    public class UserInfo
    {
        public string Name { get; set; }
        public Domain.Gender Gender { get; set; }
        public Domain.Intention Intention { get; set;}

    }
}