using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FallBuster.list_torrent;

namespace FallBuster
{
    public class thema_color
    {
        public void change_thema()
        {

        }














        public class name_thema
        {
            public string name { get; set; }

            public override string ToString()
            {
                return name;
            }
        }

        public static class class_name_thema
        {
            public static List<name_thema> get_name_thema()
            {
                var list = new List<name_thema>
                {
                    new name_thema() {
                        name = "светлая",
                    },
                    new name_thema() {
                        name = "темная",
                    },
                    };
            

                return list;
            }
        }

    }
}
