using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Models
{
    public class NamesRu : Names
    {
        public override List<string> LbNames { get; set; }
        public override List<string> BtnNames { get; set; }
        public override List<string> BtnNamesMF { get; set; }
        public override Dictionary<string, string> LbNamesWebUC { get; set; }
        public override Dictionary<string, string> BtnNamesWebUC { get; set; }

        public NamesRu()
        {
            LbNames = new List<string>() { "Автозапуск", "Тёмный фон", "Полный экран", "Язык" };
            BtnNames = new List<string>() { "Закрыть", "Сохранить", "Сбросить", "Очистить" };
            BtnNamesMF = new List<string>() { "По умолчанию", "Пользовательский", "Загрузка" };

            LbNamesWebUC = new Dictionary<string, string>()
            {
                { "Name", "Имя" },
                { "Link", "Ссылка" },
                { "State", "Статус" }
            };

            BtnNamesWebUC = new Dictionary<string, string>()
            {
                { "Save", "Сохранить" },
                { "Close", "Закрыть" },
                { "Message", "Сообщение" }
            };
        }
    }
}
