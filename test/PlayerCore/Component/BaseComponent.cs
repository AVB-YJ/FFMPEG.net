using System;
using System.Collections.Generic;
using System.Text;
using SharpFFmpeg;
using System.Threading;
using System.Diagnostics;

namespace Multimedia
{

    public class BaseComponent
    {

        private string componentName = string.Empty;
        private DateTime lastRecordTime = DateTime.Now;
        private int count = 0;
        private bool needsLog = false;

        public BaseComponent()
        {

        }

        internal void InitPerfLog(string name)
        {
            componentName = name;
            lastRecordTime = DateTime.Now;
            count = 0;
            needsLog = true;
        }

        internal void RecordLog()
        {
            DateTime now = DateTime.Now;
            count++;
            TimeSpan span = now - lastRecordTime;
            if (span.TotalSeconds >= 2)
            {
                Debug.WriteLine("["+ Thread.CurrentThread.ManagedThreadId.ToString()+"]"+
                    componentName + 
                    ": push out " + count.ToString() + 
                    " packets during " + span.TotalSeconds.ToString() + 
                    " seconds");
                count = 0;
                lastRecordTime = now;
            }
        }

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
            if (needsLog)
                RecordLog();

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

        internal void FlushNext()
        {
            List<IPipe> list = null;
            lock (nextComponents)
            {
                list = new List<IPipe>(nextComponents);
            }
            foreach (IPipe pipe in list)
            {
                pipe.Flush();
            }
        }

        internal void CloseNext()
        {
            List<IPipe> list = null;
            lock (nextComponents)
            {
                list = new List<IPipe>(nextComponents);
            }
            foreach (IPipe pipe in list)
            {
                pipe.Close();
            }
        }

        public delegate void FreeQueueItemDelegate<T>(T item);

        public class SizeQueue<T>
        {
            private FreeQueueItemDelegate<T> FreeItemDelegate;

            private readonly Queue<T> queue = new Queue<T>();
            private  int maxSize;
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
}
