using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Sweet_Hell
{
    class MoveStack: IStack
    {
        private List<Tile> data = new List<Tile>(); // underlying storage

        // number of items in the stack
        public int Count()
        {
            return data.Count;
        }

        // determine if stack is empty
        public bool IsEmpty()
        {
            if (data.Count == 0)
            {
                return true;
            }
            // if count > 0, return false
            return false;
        }

        // return top value, but don't remove it from the stack
        public Tile Peek()
        {
            return data[data.Count - 1]; // top of the stack
        }

        // return top value, and remove it from the stack
        public Tile Pop()
        {
            // get top value
            Tile topValue = data[data.Count - 1];

            // remove it from the list
            data.RemoveAt(data.Count - 1);

            // return the value
            return topValue;
        }

        // add new entry to end of the list
        public void Push(Tile obj)
        {
            data.Add(obj);
        }
    }
}

