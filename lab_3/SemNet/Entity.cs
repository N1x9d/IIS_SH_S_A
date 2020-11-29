using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemNet
{
    class Entity
    {
        public string Name { get; set; }
        public List<Connection> Connections { get; set; }

        public Entity (string name)
        {
            Name = name;
            Connections = new List<Connection>();
        }

        public void AddConnection(Connection con)
        {
            Connections.Add(con);
        }

        public void AddConnection(List<Connection> cons)
        {
            Connections.AddRange(cons);
        }
    }
}
