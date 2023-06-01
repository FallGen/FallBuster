using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallBuster
{
    public class list_torrent
    {

        public class item_torrent
        {
            public string name { get; set; }
            public string description { get; set; }
            public string img { get; set; }
            public string link { get; set; }

            public override string ToString()
            {
                return name + "|razdel|" + link;
            }
        }
        public static class class_item_torrent
        {
            public static List<item_torrent> getitem_torrent()
            {
                var list = new List<item_torrent>
                {
                    new item_torrent() {
                        name = "discord",
                        description = "приложение для голосового, видео и текстового общения",
                        img = @"images\program\discord.png",
                        link = @"https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x86" },
                    };

                return list;
            }
        }

    }
}
