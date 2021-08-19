using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottle_SYSTEM_TEST.model
{
    public class Person
    {




        public string Name { get; set; }//人的名稱
        public Guid lottleId { get; set; }//每張抽獎券的號碼

        public int SqlId { get; set; }//每筆資料的編號

        public static DateTime Now { get; }

    




    }
}
