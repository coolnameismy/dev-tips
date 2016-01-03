using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Reflection;

namespace FooConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            LYW liuyanwei = new LYW();
            Type type = liuyanwei.GetType();
           // Program.getMember(type);

            //转换类型使用晚期绑定
            // LYW lateBindingLYW = (LYW)getSelfObject(type);lateBindingLYW.speak();
            //反射获取方法使用晚期绑定的类
            object lateBindingLYW = getSelfObject(type);

            MethodInfo method = type.GetMethod("speak");
            method.Invoke(lateBindingLYW, null);//对象，参数


            Console.ReadLine();
        }

        //反射获取方法
        static public void getMethor(Type t)
        {
            foreach (var method in t.GetMethods())
            {
                Console.WriteLine(method.Name);
            }
        }

        //反射获取成员
        static public void getMember(Type t)
        {
            foreach (var member in t.GetMembers())
            {
                Console.WriteLine(member.Name);
            }
        }

        //晚期绑定，还原反射类
        static public object getSelfObject(Type t)
        {
            object obj = Activator.CreateInstance(t);
            return obj;

        }

    }
    public class LYW
    {
        public string name { get; set; }
        public string age { get; set; }
        public string gender { get; set; }

        public void speak()
        {
            Console.WriteLine("hello");
        }
    }
}
