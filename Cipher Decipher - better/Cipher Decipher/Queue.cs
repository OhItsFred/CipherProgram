using System.Collections;
using System.Collections.Generic;

namespace Cipher_Decipher
{
    class Queue<T> : IEnumerable<T>
    {
        List<T> queue = new List<T>();

        // adds an item to the queue
        public void Enqueue(T newValue)
        {
            queue.Add(newValue);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
