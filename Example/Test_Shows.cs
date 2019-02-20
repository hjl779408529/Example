using Example.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    public delegate void Work();
    public partial class Test_Shows : Form
    {
        public Test_Shows()
        {
            InitializeComponent();
        }
        //变量定义区
        bool running = false;//运行中标志
        bool pausing = false;//暂停中标志
        //事件定义区
        public event Work StartEvent;
        public event Work PauseEvent;
        public event Work ResumeEvent;
        public event Work StopEvent;
        //定义方法
        Method01 method01 = new Method01();
        Method02 method02 = new Method02();
        Method03 method03 = new Method03();
        Method04 method04 = new Method04();
        /// <summary>
        /// 移除事件绑定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="c"></param>
        /// <param name="name"></param>
        static void RemoveEvent<T>(T c, string name)
        {
            Delegate[] invokeList = GetObjectEventList(c, name);
            if (invokeList != null)
            {
                foreach (Delegate del in invokeList)
                {
                    typeof(T).GetEvent(name).RemoveEventHandler(c, del);
                }
            }            
        }
        ///  <summary>     
        /// 获取对象事件     
        ///  </summary>     
        ///  <param name="p_Object">对象 </param>     
        ///  <param name="p_EventName">事件名 </param>     
        ///  <returns>委托列 </returns>     
        public static Delegate[] GetObjectEventList(object p_Object, string p_EventName)
        {
            FieldInfo _Field = p_Object.GetType().GetField(p_EventName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            if (_Field == null)
            {
                return null;
            }
            object _FieldValue = _Field.GetValue(p_Object);
            if (_FieldValue != null && _FieldValue is Delegate)
            {
                Delegate _ObjectDelegate = (Delegate)_FieldValue;
                return _ObjectDelegate.GetInvocationList();
            }
            return null;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="info"></param>
        public void Info(string info)
        {
            this.Invoke((EventHandler)delegate
            {
                displayWindow.AppendText(info + "\r\n");
            });
        }
        /// <summary>
        /// 启动按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            if (running)//运行中
            {
                return;
            }
            else
            {
                Start.Enabled = false;
                SelectMethod.Enabled = false;
                StartEvent?.Invoke();
                running = true;
            }
        }
        /// <summary>
        /// 停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stop_Click(object sender, EventArgs e)
        {
            if (running)//运行中
            {
                StopEvent?.Invoke();
                running = false;
                pausing = false;
                Start.Enabled = true;
                pause.Enabled = true;
                resume.Enabled = true;
                stop.Enabled = true;
                SelectMethod.Enabled = true;
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 暂停按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pause_Click(object sender, EventArgs e)
        {
            if (running)//运行中
            {
                if (pausing)//暂停中
                {
                    return;
                }
                else
                {
                    PauseEvent?.Invoke();
                    pausing = true;
                    pause.Enabled = false;
                }
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 恢复按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resume_Click(object sender, EventArgs e)
        {
            if (running)//运行中
            {
                if (pausing)//暂停中
                {
                    ResumeEvent?.Invoke();
                    pausing = false;
                    pause.Enabled = true;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 程序运行结束事件
        /// </summary>
        private void exit()
        {
            this.Invoke((EventHandler)delegate
            {
                Info("退出事件触发");
            });
        }
        /// <summary>
        /// 方式选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectMethod_ValueChanged(object sender, EventArgs e)
        {
            switch (SelectMethod.Value)
            {
                case 1:
                    //移除事件
                    RemoveEvent<Method01>(method01, "Info");
                    //绑定事件
                    method01.Info += Info;
                    //移除事件
                    RemoveEvent<Test_Shows>(this, "StartEvent");
                    RemoveEvent<Test_Shows>(this, "PauseEvent");
                    RemoveEvent<Test_Shows>(this, "ResumeEvent");
                    RemoveEvent<Test_Shows>(this, "StopEvent");
                    //绑定事件
                    StartEvent += method01.ThreadStart;
                    PauseEvent += method01.ThreadPause;
                    ResumeEvent += method01.ThreadResume;
                    StopEvent += method01.ThreadStop;
                    break;
                case 2:
                    //移除事件
                    RemoveEvent<Method02>(method02, "Info");
                    //绑定事件
                    method02.Info += Info;
                    //移除事件
                    RemoveEvent<Test_Shows>(this, "StartEvent");
                    RemoveEvent<Test_Shows>(this, "PauseEvent");
                    RemoveEvent<Test_Shows>(this, "ResumeEvent");
                    RemoveEvent<Test_Shows>(this, "StopEvent");
                    //绑定事件
                    RemoveEvent<Test_Shows>(this, "Work");
                    StartEvent += method02.ThreadStart;
                    PauseEvent += method02.ThreadPause;
                    ResumeEvent += method02.ThreadResume;
                    StopEvent += method02.ThreadStop;
                    break;
                case 3:
                    //移除事件
                    RemoveEvent<Method03>(method03, "Info");
                    //绑定事件
                    method03.Info += Info;
                    //移除事件
                    RemoveEvent<Test_Shows>(this, "StartEvent");
                    RemoveEvent<Test_Shows>(this, "PauseEvent");
                    RemoveEvent<Test_Shows>(this, "ResumeEvent");
                    RemoveEvent<Test_Shows>(this, "StopEvent");
                    //绑定事件
                    RemoveEvent<Test_Shows>(this, "Work");
                    StartEvent += method03.ThreadStart;
                    PauseEvent += method03.ThreadPause;
                    ResumeEvent += method03.ThreadResume;
                    StopEvent += method03.ThreadStop;
                    break;
                case 4:
                    //移除事件
                    RemoveEvent<Method04>(method04, "Info");
                    //绑定事件
                    method04.Info += Info;
                    //移除事件
                    RemoveEvent<Test_Shows>(this, "StartEvent");
                    RemoveEvent<Test_Shows>(this, "PauseEvent");
                    RemoveEvent<Test_Shows>(this, "ResumeEvent");
                    RemoveEvent<Test_Shows>(this, "StopEvent");
                    //绑定事件
                    RemoveEvent<Test_Shows>(this, "Work");
                    StartEvent += method04.ThreadStart;
                    PauseEvent += method04.ThreadPause;
                    ResumeEvent += method04.ThreadResume;
                    StopEvent += method04.ThreadStop;
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 双击清除日志记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            displayWindow.Text = "";
        }
    }
}
