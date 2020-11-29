using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemNet
{
    class Connection
    {
        public Entity Parent { get; private set; }
        public Entity Successor { get; private set; }
        public string ConnectionType { get; private set; }

        public Connection(Entity parent, Entity successor, string connectionType)
        {
            Parent = parent;
            Successor = successor;
            ConnectionType = connectionType;
        }

        public Connection( string connectionType)
        {
           
            ConnectionType = connectionType;
        }

        public Connection SetEntitys(Entity parent, Entity successor)
        {
            Parent = parent;
            Successor = successor;
            parent.AddConnection(this);
            successor.AddConnection(this);
        }
    }
}
