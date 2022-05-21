using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generix
{
    public class AlmacenWarehouse : Warehouse<Fiambre>
    {
        public AlmacenWarehouse()
        {
            foreach(var o in Items)
            {
                var fiambre = (Fiambre)o;
            }
        }

    }
}
