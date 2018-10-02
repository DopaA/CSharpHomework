using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAlarm
{
    //声明参数类型
    public class AlarmArgs : EventArgs
    {
        public string Hour;
        public string Minute;
    }
    //声明委托类型
    public delegate void EventHandler(object sender, AlarmArgs e);

    //声明事件源
    public class Alarm
    {
        //声明事件
        public event EventHandler Alarming;
        
        public void OnRemind(string hour,string minute) 
        {
            AlarmArgs alarmArgs = new AlarmArgs
            {
                Hour = hour,
                Minute = minute
            };
            Alarming(this, alarmArgs);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var alarm = new Alarm();
                Console.WriteLine("请输入闹钟时间的小时：");
                string hour = Console.ReadLine();
                Console.WriteLine("请输入闹钟时间的分钟：");
                string minute = Console.ReadLine();
                //注册事件
                alarm.Alarming += Remind;
                alarm.OnRemind(hour, minute);
            }
            catch
            {
                throw new Exception("Unknown error!");
            }
            Console.ReadLine();
        }
        //事件处理
        static void Remind(object sender,AlarmArgs e)
        {
            bool bo = true;
            while (bo)
            {
                if (e.Hour == DateTime.Now.Hour.ToString() && e.Minute == DateTime.Now.Minute.ToString())
                {
                    Console.WriteLine("The time has come! Now is" + DateTime.Now.ToShortTimeString() + "!");
                    break;
                }
            }
        }
    }
}
