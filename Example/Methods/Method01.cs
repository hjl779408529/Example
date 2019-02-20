using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Methods
{
    public delegate void Trans(string info);
    public delegate void End();
    class Method01
    {
        public event Trans Info;
        public event End End;
        public bool on_off = false;//运行、暂停切换
        public bool stop = false;//停止
        Thread thread;
        IEnumerable<object> Loop()
        {
            for (int i = 0; i < 1000; i++)
            {
                Info?.Invoke(i.ToString());
                Thread.Sleep(500);
                yield return new object();
            }

        }
        /// <summary>
        /// 循环结构
        /// 获取枚举数
        /// </summary>
        void Runtime()
        {
            IEnumerator<object> Flag = Loop().GetEnumerator();
            //Flag.Reset();
            do
            {
                //停止
                if (stop)
                {
                    return;
                }
                //暂停
                do
                {
                    Thread.Sleep(100);
                    if (stop)
                    {
                        return;
                    }
                }
                while (on_off);
            }
            while (Flag.MoveNext()) ;
            End?.Invoke();
        }
        /// <summary>
        /// 启动运行
        /// </summary>
        public void ThreadStart()
        {
            thread = new Thread(Runtime);
            thread.Start();
            Info?.Invoke("启动运行！！！");
        }
        /// <summary>
        /// 暂停运行
        /// </summary>
        public void ThreadPause()
        {
            on_off = true;
            Info?.Invoke("暂停运行！！！");
        }
        /// <summary>
        /// 恢复运行
        /// </summary>
        public void ThreadResume()
        {
            on_off = false;
            Info?.Invoke("继续运行！！！");
        }
        /// <summary>
        /// 终止运行
        /// </summary>
        public void ThreadStop()
        {
            stop = true;
            Info?.Invoke("终止运行！！！");
            do
            {
                Thread.Sleep(100);
            }
            while (thread.IsAlive);
            on_off = false;
            stop = false;
        }        

    }
    class Method02
    {
        public event Trans Info;
        public event End End; 
        Thread thread;
        ManualResetEvent ma;
        public bool on_off = false;//运行、暂停切换
        public bool stop = false;//停止
        /// <summary>
        /// 启动运行
        /// </summary>
        public void ThreadStart()
        {
            thread = new Thread(Runtime);
            thread.Start();
            Info?.Invoke("启动运行！！！");
        }
        /// <summary>
        /// 暂停运行
        /// </summary>
        public void ThreadPause()
        {
            on_off = true;
            Info?.Invoke("暂停运行！！！");
        }
        /// <summary>
        /// 恢复运行
        /// </summary>
        public void ThreadResume()
        {
            on_off = false;
            ma.Set();
            Info?.Invoke("继续运行！！！");
        }
        /// <summary>
        /// 终止运行
        /// </summary>
        public void ThreadStop()
        {
            stop = true;
            Info?.Invoke("终止运行！！！");
            do
            {
                Thread.Sleep(100);
            }
            while(thread.IsAlive);
            on_off = false;
            stop = false;
        }
        /// <summary>
        /// 循环结构
        /// </summary>
        public void Runtime() 
        {
            for (int i = 0; i < 1000; i++)
            {
                if (stop)//退出
                {
                    return;
                }
                if (on_off)//运行和暂停切换
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                Info?.Invoke("计数：" + i.ToString());
                Thread.Sleep(500);
            }
            End?.Invoke();
        }
    }
}
