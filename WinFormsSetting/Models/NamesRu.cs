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

        public NamesRu()
        {
            LbNames = new List<string>() { "Автозапуск", "Тёмный фон", "Полный экран", "Язык" };
            BtnNames = new List<string>() { "Закрыть", "Сохранить", "Сбросить", "Очистить" };
        }
    }
}
