using System.Collections.Generic;

namespace FallBuster
{
    public class list_program
    {
        public class item_program
        {
            public string name { get; set; }
            public string description { get; set; }
            public string img { get; set; }
            public string link { get; set; }

            public override string ToString()
            {
                return name +"|razdel|"+link;
            }
        }

        public static class class_list_program
        {
            public static List<item_program> getitem_programs()
            {
                var list = new List<item_program>
                {
                    new item_program() { 
                        name = "discord", 
                        description = "приложение для голосового, видео и текстового общения", 
                        img = @"images\program\discord.png", 
                        link = @"https://discord.com/api/downloads/distributions/app/installers/latest?channel=stable&platform=win&arch=x86" },
                    new item_program() { 
                        name = "telegram", 
                        description = "кроссплатформенная система мгновенногообмена сообщениями (мессенджер)", 
                        img = @"images\program\telegram.png", 
                        link = @"https://telegram.org/dl/desktop/win64" },
                    new item_program() { 
                        name = "notepad++", 
                        description = "удобный и многофункциональный текстовый редактор", 
                        img = @"images\program\notepad.png", 
                        link = @"https://github.com/notepad-plus-plus/notepad-plus-plus/releases/download/v8.4.8/npp.8.4.8.Installer.x64.exe" },
                    new item_program() { 
                        name = "qbittorrent", 
                        //description = "свободный кроссплатформенный клиент\nфайлообменной сети BitTorrent", 
                        description = "НЕДОСТУПНО", 
                        img = @"images\program\qbittorrent.png", 
                        link = @"" },
                    new item_program() { 
                        name = "steam", 
                        description = "онлайн-сервис цифрового распространения компьютерных игр и программ", 
                        img = @"images\program\steam.png", 
                        link = @"https://cdn.akamai.steamstatic.com/client/installer/SteamSetup.exe" },
                    new item_program() { 
                        name = "visual studio professional", 
                        description = "интегрированная среда разработки (IDE)", 
                        img = @"images\program\VS.png", 
                        link = @"https://c2rsetup.officeapps.live.com/c2r/downloadVS.aspx?sku=professional&channel=Release&version=VS2022&source=VSLandingPage&includeRecommended=true&cid=2030" },
                    new item_program() { 
                        name = "github desktop",
                        description = "веб-сервис для хостинга IT-проектов и их совместной разработки", 
                        img = @"images\program\github.png", 
                        link = @"https://central.github.com/deployments/desktop/desktop/latest/win32" },
                    new item_program() { 
                        name = "nvidia geforce experience", 
                        description = "утилита ориентирована на помощь пользователям получить более комфортный игровой процесс в играх", 
                        img = @"images\program\nvidia.png", 
                        link = @"https://ru.download.nvidia.com/GFE/GFEClient/3.26.0.160/GeForce_Experience_v3.26.0.160.exe" },
                    new item_program() { 
                        name = "MSIAfterburner", 
                        description = "самая известная и широко используемая утилита для разгона видеокарт", 
                        img = @"images\program\msi.png", 
                        //link = @"https://download.msi.com/uti_exe/vga/MSIAfterburnerSetup.zip?__token__=exp=1674390279~acl=/*~hmac=1b026b2f74c9da76530169c1717e9e48905ae636a0148e2a3df94281ba3d47d6" },
                        link = @"https://download.msi.com/uti_exe/vga/MSIAfterburnerSetup.zip?__token__=exp=1679108103~acl=/*~hmac=d5ce87475d1faf39149268442f0cff2218cdc80b4de1fb6699888b4fd46732f2" },
                    new item_program() { 
                        name = "ZET GAMING Immortality Pro Wireless", 
                        description = "индивидуальное ПО для мыши", 
                        img = @"images\program\zetgaming.png", 
                        link = @"https://ftp.dns-shop.ru/oth/M/mys-besprovodnaaprovodnaa-zet-gaming-immortality-pro-wireless-zgw-imp3370-bk-cernyj_drajver.zip" },
                    new item_program() { 
                        name = "ccleaner", 
                        description = "НЕДОСТУПНО", 
                        img = @"images\program\ccleaner.png", 
                        link = @"" },
                    new item_program() { 
                        name = "speccy", 
                        description = "НЕДОСТУПНО", 
                        img = @"images\program\speccy.png", link = @"" },
                    new item_program() {
                        name = "planetvpn",
                        description = "полностью бесплатный ВПН сервис без ограничений по трафику и скорости",
                        img = @"images\program\planetvpn.png",
                        link = @"https://freevpnplanet.com/link/platform/" },
                     new item_program() {
                        name = "anydesk",
                        description = "доступ к любому устройству в любое время. в любом месте. всегда быстро и безопасно.",
                        img = @"images\program\anydesk.png",
                        link = @"https://anydesk.com/ru/downloads/windows?dv=win_exe" },
                     new item_program() {
                        name = "CrystalDisklnfo",
                        description = "программа для тестирования производительности жёстких дисков и ssd накопителей",
                        img = @"images\program\CrystalDisklnfo.png",
                        link = @"https://crystalmark.info/redirect.php?product=CrystalDiskInfoInstaller" },
                     new item_program() {
                        name = "opera",
                        description = "веб-браузер и пакет прикладных программ для работы в интернете",
                        img = @"images\program\opera.png",
                        link = @"https://www.opera.com/ru/computer/thanks?ni=stable&os=windows&edition=Yx+05" },
                     new item_program() {
                        name = "operaGX",
                        description = "opera gx — это специальная геймерская версия браузера opera.",
                        img = @"images\program\OperaGX.png",
                        link = @"https://www.opera.com/ru/computer/thanks?ni=eapgx&os=windows&edition=Yx+GX" },
                     new item_program() {
                        name = "Yandex",
                        description = "быстрый и безопасный браузер со встроенной технологией активной защиты protect",
                        img = @"images\program\yandex.png",
                        link = @"https://browser.yandex.ru/download?banerid=6301000000&statpromo=true" },
                     new item_program() {
                        name = "Chrome",
                        description = "браузер, разрабатываемый компанией Google на основе свободного браузера Chromium и движка Blink",
                        img = @"images\program\googlechrome.png",
                        link = @"https://www.google.ru/chrome/thank-you.html?statcb=0&installdataindex=empty&defaultbrowser=0#" },
                     new item_program() {
                        name = "Epic games",
                        description = "популярный лаунчер для игр",
                        img = @"images\program\epicgames.png",
                        link = @"https://launcher-public-service-prod06.ol.epicgames.com/launcher/api/installer/download/EpicGamesLauncherInstaller.msi" },
                };

                return list;
            }
        }
    }
}
