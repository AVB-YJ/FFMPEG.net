using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SharpFFmpeg
{
    public delegate void FreeQueueItemDelegate<T>(T item);


    public class SizeQueue<T>
    {
        private FreeQueueItemDelegate<T> FreeItemDelegate;

        private readonly Queue<T> queue = new Queue<T>();
        private int maxSize;
        public SizeQueue(int maxSize, FreeQueueItemDelegate<T> FreeItemDelegate)
        {
            this.maxSize = maxSize;
            this.FreeItemDelegate = FreeItemDelegate;
        }
        private bool closing = false;
        public int Size
        {
            get { return maxSize; }
            set
            {
                lock (queue)
                {
                    maxSize = value;
                }
            }
        }

        public void Close()
        {
            lock (queue)
            {
                closing = true;
                Monitor.PulseAll(queue);
            }

        }

        public bool Enqueue(T item)
        {
            lock (queue)
            {
                while (queue.Count >= maxSize)
                {
                    if (closing)
                    {
                        return false;
                    }
                    Monitor.Wait(queue);
                }
                queue.Enqueue(item);
                if (queue.Count == 1)
                {
                    // wake up any blocked dequeue
                    Monitor.PulseAll(queue);
                }
                return true;
            }
        }

        public bool Flush()
        {
            lock (queue)
            {
                foreach (var item in queue)
                    FreeItemDelegate(item);

                queue.Clear();
            }
            return true;

        }

        public bool Dequeue(out T val)
        {
            lock (queue)
            {
                while (queue.Count == 0)
                {
                    if (closing)
                    {
                        val = default(T);
                        return false;
                    }
                    Monitor.Wait(queue);
                }
                T item = queue.Dequeue();
                if (queue.Count == maxSize - 1)
                {
                    // wake up any blocked enqueue
                    Monitor.PulseAll(queue);
                }
                val = item;
                return true;
            }
        }
    }
}
