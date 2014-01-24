using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Threading;

namespace Multimedia
{

    public class BaseComponent
    {

        internal List<IPipe> nextComponents = new List<IPipe>();

        internal void AddPipe(IPipe pipe)
        {
            lock (nextComponents)
            {
                nextComponents.Add(pipe);
            }
        }

        internal void PushToNext(object obj)
        {
            List<IPipe> list = null;
            lock (nextComponents)
            {
                list = new List<IPipe>(nextComponents);
            }
            foreach (IPipe pipe in list)
            {
                pipe.OnReceiveData(obj);
            }
        }

        internal void StartNext()
        {
            List<IPipe> list = null;
            lock (nextComponents)
            {
                list = new List<IPipe>(nextComponents);
            }
            foreach (IPipe pipe in list)
            {
                pipe.Start();
            }
        }

        internal void StopNext()
        {
            List<IPipe> list = null;
            lock (nextComponents)
            {
                list = new List<IPipe>(nextComponents);
            }
            foreach (IPipe pipe in list)
            {
                pipe.Stop();
            }
        }

        public class SizeQueue<T>
        {
            private readonly Queue<T> queue = new Queue<T>();
            private  int maxSize;
            public SizeQueue(int maxSize) { this.maxSize = maxSize; }
            private bool closing = false;
            public int Size
            {
                get { return maxSize; }
                set
                {
                    lock(queue)
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
}
