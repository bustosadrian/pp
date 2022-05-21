using System;
using System.Collections.Generic;
using System.Text;

namespace Generix
{
    public class Warehouse<ItemType> where ItemType : Item
    {
        public List<ItemType> Items
        {
            get;
            set;
        }

        public void AddItem(ItemType item)
        {
            Items.Add(item);
        }
    }
}
