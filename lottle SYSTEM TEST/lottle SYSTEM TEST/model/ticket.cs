using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lottle_SYSTEM_TEST.model
{
    public class ticket
    {


        public int award_number_T { get; set; }
        public Guid ticket_id { get; set; }

        public string User_name { get; set; }

      //  public Guid award_id  { get; set; }
 
        public DateTime create_tumes { get; set; }

       public string Awards_name { get; set; }//獎項名稱



    }
}
