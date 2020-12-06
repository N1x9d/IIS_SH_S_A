using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemNet
{
    class LogicalMashine
    {
        KBGenerator KBGenerator;
        IReadOnlyList<Entity> eneties;
        IReadOnlyList<Connection> connections;

        public LogicalMashine()
        {
            KBGenerator = new KBGenerator();
            connections = KBGenerator.connection;
            eneties = KBGenerator.entity;
        }
        public bool HierarchicalQuestion(string Parent, string Children)
        {
            Entity CurrentChildren=null;
            foreach(var enety in eneties)
            {
                if(enety.Name== Children)
                {
                    CurrentChildren = enety;
                }
            }
            bool v = false ;
            bool Answer = false;
            do
            {
                v = false;
                foreach (var conn in CurrentChildren.Connections)
                {
                    if (conn.Parent.Name != CurrentChildren.Name)
                    {
                        if (conn.ConnectionType == "AKO" || conn.ConnectionType == "Is_a")
                        {
                            if (conn.Parent.Name == Parent)
                            {
                                Answer = true;
                                break;
                            }
                            else
                            {
                                CurrentChildren = conn.Parent;
                                v = true;
                                break;
                            }
                        }
                    }
                }
            } while (v);
            return Answer;
        }
        public string СommunicationQuestion(string nameEntity)
        {
            string Budget=null;

            Entity CurrentChildren = null;
            foreach (var enety in eneties)
            {
                if (enety.Name == nameEntity)
                {
                    CurrentChildren = enety;
                }
            }
            foreach (var conn in CurrentChildren.Connections)
            {
                if (conn.ConnectionType == "Траты")
                {
                    Budget=conn.Parent.Name;
                }
            }
            return Budget;
        }
        public bool EntityQuestion(string Country, string SeasonName)
        {
            Entity CurrentParrent = null;
            Entity CurrentChildren = null;
            Entity Season = null;

            foreach (var enety in eneties)
            {
                if (enety.Name == Country)
                {
                    CurrentParrent = enety;
                }
            }
            foreach (var conn in CurrentParrent.Connections)
            {
                if (conn.ConnectionType == "Способ отдыха")
                {
                    CurrentParrent = conn.Parent;
                }
            }
            foreach (var enety in eneties)
            {
                if (enety.Name == SeasonName)
                {
                    CurrentChildren = enety;
                }
            }
            foreach (var enety in eneties)
            {
                if (enety.Name == "Сезон")
                {
                    Season = enety;
                }
            }

            foreach (var conn in Season.Connections)
            {
                if (conn.ConnectionType == "AKO")
                {
                    var conProm = conn.Successor;
                   foreach(var conn1 in conProm.Connections)
                    {
                        if (conn1.ConnectionType == "Влияет")
                        {
                            if(conn1.Successor.Name== CurrentParrent.Name && conn1.Parent.Name== CurrentChildren.Name)
                            {
                                return true;
                            }
                            else if(conn1.Successor.Name == CurrentParrent.Name && conn1.Parent.Name != CurrentChildren.Name)
                            {
                                return false;
                            }
                        }
                        
                    }
                }
            }
            return true;
        }
    }
}
