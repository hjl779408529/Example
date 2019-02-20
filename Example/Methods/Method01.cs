using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Methods
{
    public delegate void Trans(string info);
    public delegate void Work();
    /// <summary>
    /// IEnumerator实现
    /// </summary>
    class Method01
    {
        public event Trans Info;
        public event Work End;
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
    /// <summary>
    /// ManualResetEvent 实现
    /// </summary>
    class Method02
    {
        public event Trans Info;
        public event Work StartCode; //启动执行代码
        public event Work WorkCode; //启动执行代码
        public event Work PauseCode; //暂停执行代码
        public event Work ResumeCode; //恢复执行代码
        public event Work StopCode; //停止执行代码
        public event Work EndCode; //结束执行代码
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
            StartCode?.Invoke();
        }
        /// <summary>
        /// 暂停运行
        /// </summary>
        public void ThreadPause()
        {
            on_off = true;
            Info?.Invoke("暂停运行！！！");
            PauseCode?.Invoke();
        }
        /// <summary>
        /// 恢复运行
        /// </summary>
        public void ThreadResume()
        {
            on_off = false;
            ma.Set();
            Info?.Invoke("继续运行！！！");
            ResumeCode?.Invoke();
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
                    StopCode?.Invoke();
                    return;
                }
                if (on_off)//运行和暂停切换
                {
                    ma = new ManualResetEvent(false);
                    ma.WaitOne();
                }
                Info?.Invoke("计数：" + i.ToString());
                WorkCode?.Invoke();
                Thread.Sleep(500);
            }
            EndCode?.Invoke();
        }
    }
    /// <summary>
    /// System.Timers.Timer实现
    /// </summary>
    class Method03
    {
        public event Trans Info;
        public event Work StartCode; //启动执行代码
        public event Work WorkCode; //启动执行代码
        public event Work PauseCode; //暂停执行代码
        public event Work ResumeCode; //恢复执行代码
        public event Work StopCode; //停止执行代码
        public event Work EndCode; //结束执行代码
        System.Timers.Timer timer;
        int count;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Method03()
        {
            
        }
        /// <summary>
        /// 启动运行
        /// </summary>
        public void ThreadStart()
        {
            timer = new System.Timers.Timer(500);
            timer.Elapsed += Runtime;
            timer.AutoReset = true;
            timer.Enabled = true;
            count = 0;
            timer.Start();
            Info?.Invoke("启动运行！！！");
            StartCode?.Invoke();
        }
        /// <summary>
        /// 暂停运行
        /// </summary>
        public void ThreadPause()
        {
            timer.Enabled = false;
            Info?.Invoke("暂停运行！！！");
            PauseCode?.Invoke();
        }
        /// <summary>
        /// 恢复运行
        /// </summary>
        public void ThreadResume()
        {
            timer.Enabled =true;
            Info?.Invoke("继续运行！！！");
            ResumeCode?.Invoke();
        }
        /// <summary>
        /// 终止运行
        /// </summary>
        public void ThreadStop()
        {
            timer.Dispose();
            Info?.Invoke("终止运行！！！");
        }
        /// <summary>
        /// 循环结构
        /// </summary>
        public void Runtime(object sender, EventArgs e)
        {
            count++;
            Info?.Invoke("计数：" + count.ToString());
            WorkCode?.Invoke();            
            if (count == 1000) EndCode?.Invoke();
        }
    }
    /// <summary>
    /// System.Threading.Timer实现
    /// </summary>
    class Method04
    {
        public event Trans Info;
        public event Work StartCode; //启动执行代码
        public event Work WorkCode; //启动执行代码
        public event Work PauseCode; //暂停执行代码
        public event Work ResumeCode; //恢复执行代码
        public event Work StopCode; //停止执行代码
        public event Work EndCode; //结束执行代码
        System.Threading.Timer timer;
        int count;
        /// <summary>
        /// 构造函数
        /// </summary>
        public Method04()
        {

        }
        /// <summary>
        /// 启动运行
        /// </summary>
        public void ThreadStart()
        {
            timer = new Timer(Runtime,null,Timeout.Infinite,Timeout.Infinite);
            timer.Change(0, 500);
            count = 0;
            Info?.Invoke("启动运行！！！");
            StartCode?.Invoke();
        }
        /// <summary>
        /// 暂停运行
        /// </summary>
        public void ThreadPause()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            Info?.Invoke("暂停运行！！！");
            PauseCode?.Invoke();
        }
        /// <summary>
        /// 恢复运行
        /// </summary>
        public void ThreadResume()
        {
            timer.Change(0, 500);
            Info?.Invoke("继续运行！！！");
            ResumeCode?.Invoke();
        }
        /// <summary>
        /// 终止运行
        /// </summary>
        public void ThreadStop()
        {
            timer.Dispose();
            Info?.Invoke("终止运行！！！");
        }
        /// <summary>
        /// 循环结构
        /// </summary>
        public void Runtime(object sender)
        {
            count++;
            Info?.Invoke("计数：" + count.ToString());
            WorkCode?.Invoke();
            if (count == 1000) EndCode?.Invoke();
        }
    }
}
