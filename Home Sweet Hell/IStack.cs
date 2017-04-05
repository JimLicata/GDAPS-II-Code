using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Home_Sweet_Hell
{
    /// <summary>
    /// Implement this interface to simulate a stack data structure
    /// </summary>
    interface IStack
    {
        /// <summary>
        /// Gets the number of strings in the stack.  This will not
        /// be directly tied to an attribute called "count"
        /// </summary>
        int Count();

        /// <summary>
        /// Gets whether or not the stack is completely empty.
        /// Also not directly tied to an attribute.
        /// </summary>
        bool IsEmpty();

        /// <summary>
        /// Add the string to the "top" (or end) of the stack
        /// </summary>
        /// <param name="str">The string to add</param>
        void Push(Tile obj);

        /// <summary>
        /// Removes the data on top of the stack and returns it
        /// </summary>
        /// <returns>The most recently added string</returns>
        Tile Pop();

        /// <summary>
        /// Returns the data on top of the stack
        /// </summary>
        /// <returns>The most recently added string</returns>
        Tile Peek();
    }
}
