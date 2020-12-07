using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemNet
{
    class KBGenerator
    {
        List<Entity> Entites = new List<Entity>();
        List<Connection> connections = new List<Connection>();
        public IReadOnlyList<Entity> entity => Entites;
        public IReadOnlyList<Connection> connection => connections;

        public KBGenerator()
        {

            Entites.Add(new Entity("Фактор"));//0
            Entites.Add(new Entity("Бюджет"));//1
            Entites.Add(new Entity("Сезон"));//2
            Entites.Add(new Entity("Отдых"));//3
            Entites.Add(new Entity("Весна"));//4
            Entites.Add(new Entity("Зима"));//5
            Entites.Add(new Entity("Лето"));//6
            Entites.Add(new Entity("Осень"));//7
            Entites.Add(new Entity("Низкий"));//8
            Entites.Add(new Entity("Средний"));//9
            Entites.Add(new Entity("Высокий"));//10
            Entites.Add(new Entity("Экскурсия"));//11
            Entites.Add(new Entity("Пляж"));//12
            Entites.Add(new Entity("Горнолыжка"));//13
            Entites.Add(new Entity("Места отдыха"));//14
            Entites.Add(new Entity("Заграничные"));//15
            Entites.Add(new Entity("По стране"));//16
            Entites.Add(new Entity("С визой"));//17
            Entites.Add(new Entity("Без визы"));//18
            Entites.Add(new Entity("Китай"));//19
            Entites.Add(new Entity("Германия"));//20
            Entites.Add(new Entity("Испания"));//21
            Entites.Add(new Entity("Турция"));//22
            Entites.Add(new Entity("Египет"));//23
            Entites.Add(new Entity("ОАЭ"));//24
            Entites.Add(new Entity("Пермь"));//25
            Entites.Add(new Entity("Санкт-Петиербург"));//26
            Entites.Add(new Entity("Сочи"));//27
            Entites.Add(new Entity("Тип поздки"));//28
            Entites.Add(new Entity("Семейная"));//29
            Entites.Add(new Entity("Не семейная"));//30

            
            connections.AddRange(new List<Connection>()
            {
                new Connection("Влияет").SetEntitys(Entites[5], Entites[13]),
                new Connection("Влияет").SetEntitys(Entites[6], Entites[12]),
                new Connection("Влияет").SetEntitys(Entites[9], Entites[13]),
                new Connection("Влияет").SetEntitys(Entites[10], Entites[13]),
                new Connection("Влияет").SetEntitys(Entites[0], Entites[3]),
                new Connection("Влияет").SetEntitys(Entites[28], Entites[14]),
                new Connection("Влияет").SetEntitys(Entites[29], Entites[21]),
                new Connection("Влияет").SetEntitys(Entites[30], Entites[20])
            });
            connections.AddRange(new List<Connection>()
            {
                new Connection("Траты").SetEntitys(Entites[10], Entites[19]),
                new Connection("Траты").SetEntitys(Entites[10], Entites[20]),
                new Connection("Траты").SetEntitys(Entites[10], Entites[21]),
                new Connection("Траты").SetEntitys(Entites[9], Entites[22]),
                new Connection("Траты").SetEntitys(Entites[9], Entites[23]),
                new Connection("Траты").SetEntitys(Entites[10], Entites[24]),
                new Connection("Траты").SetEntitys(Entites[8], Entites[25]),
                new Connection("Траты").SetEntitys(Entites[9], Entites[26]),
                new Connection("Траты").SetEntitys(Entites[9], Entites[27])
            });

            connections.AddRange(new List<Connection>()
            {
                new Connection("Способ отдыха").SetEntitys(Entites[11], Entites[19]),
                new Connection("Способ отдыха").SetEntitys(Entites[11], Entites[20]),
                new Connection("Способ отдыха").SetEntitys(Entites[13], Entites[20]),
                new Connection("Способ отдыха").SetEntitys(Entites[12], Entites[21]),
                new Connection("Способ отдыха").SetEntitys(Entites[13], Entites[21]),
                new Connection("Способ отдыха").SetEntitys(Entites[12], Entites[22]),
                new Connection("Способ отдыха").SetEntitys(Entites[12], Entites[23]),
                new Connection("Способ отдыха").SetEntitys(Entites[12], Entites[24]),
                new Connection("Способ отдыха").SetEntitys(Entites[11], Entites[25]),
                new Connection("Способ отдыха").SetEntitys(Entites[11], Entites[26]),
                new Connection("Способ отдыха").SetEntitys(Entites[12], Entites[27]),
                new Connection("Способ отдыха").SetEntitys(Entites[13], Entites[27])
            });
            connections.AddRange(new List<Connection>()
            {
                new Connection("AKO").SetEntitys(Entites[3], Entites[11]),
                new Connection("AKO").SetEntitys(Entites[3], Entites[12]),
                new Connection("AKO").SetEntitys(Entites[3], Entites[13]),
                new Connection("AKO").SetEntitys(Entites[0], Entites[1]),
                new Connection("AKO").SetEntitys(Entites[0], Entites[2]),
                new Connection("AKO").SetEntitys(Entites[1], Entites[8]),
                new Connection("AKO").SetEntitys(Entites[1], Entites[9]),
                new Connection("AKO").SetEntitys(Entites[1], Entites[10]),
                new Connection("AKO").SetEntitys(Entites[2], Entites[4]),
                new Connection("AKO").SetEntitys(Entites[2], Entites[5]),
                new Connection("AKO").SetEntitys(Entites[2], Entites[6]),
                new Connection("AKO").SetEntitys(Entites[2], Entites[7]),
                new Connection("AKO").SetEntitys(Entites[15], Entites[17]),
                new Connection("AKO").SetEntitys(Entites[15], Entites[18]),
                new Connection("AKO").SetEntitys(Entites[14], Entites[15]),
                new Connection("AKO").SetEntitys(Entites[14], Entites[16]),
                new Connection("AKO").SetEntitys(Entites[28], Entites[29]),
                new Connection("AKO").SetEntitys(Entites[28], Entites[30])
            });
            connections.AddRange(new List<Connection>()
            {
                new Connection("Is_a").SetEntitys(Entites[17], Entites[19]),
                new Connection("Is_a").SetEntitys(Entites[17], Entites[20]),
                new Connection("Is_a").SetEntitys(Entites[17], Entites[21]),
                new Connection("Is_a").SetEntitys(Entites[18], Entites[22]),
                new Connection("Is_a").SetEntitys(Entites[18], Entites[23]),
                new Connection("Is_a").SetEntitys(Entites[18], Entites[24]),
                new Connection("Is_a").SetEntitys(Entites[16], Entites[25]),
                new Connection("Is_a").SetEntitys(Entites[16], Entites[26]),
                new Connection("Is_a").SetEntitys(Entites[16], Entites[27])
            });

        }
    }
}