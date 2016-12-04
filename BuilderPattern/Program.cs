using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建指挥者和构造者
            Director director = new Director();
            IBuilder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            //老板让员工b1去组长第一台电脑
            director.IConstruct(b1);
            //组装完。组装人员搬来组装好的电脑
            Computer computer1 = b1.GetComputer();
            computer1.Show();
            //老板让员工b1去组长第一台电脑
            director.Construct(b2);
            Computer computer2 = b2.GetComputer();
            computer2.Show();
            Console.ReadLine();
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }

        public void IConstruct(IBuilder builder)
        {
            builder.BuildPartCPU();
            builder.BuildPartMainBoard();
        }
    }
    /// <summary>
    /// 电脑类
    /// </summary>
    public class Computer
    {
        private IList<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("电脑开始在组装.....");
            foreach(string part in parts)
            {
                Console.WriteLine("组件" + part + "已经装好");
            }
            Console.WriteLine("电脑组装好了");
        }
    }
    /// <summary>
    /// 抽象建造者，这个场景下为 "组装人" ，这里也可以定义为接口
    /// </summary>
    public abstract class Builder
    {
        //装CPU
        public abstract void BuildPartCPU();
        //装主板
        public abstract void BuildPartMainBoard();
        //获得组装好的电脑
        public abstract Computer GetComputer();
    }
    /// <summary>
    /// 建造者接口，这个场景下为 "组装人" 
    /// </summary>
    public interface IBuilder
    {
        void BuildPartCPU();
        void BuildPartMainBoard();
        Computer GetComputer();
    }
    /// <summary>
    /// 具体的创建者ConcreteBuilder1
    /// </summary>
    public class ConcreteBuilder1 : IBuilder
    {
        Computer computer = new Computer();
        public void BuildPartCPU()
        {
            computer.Add("CPU1");
        }

        public void BuildPartMainBoard()
        {
            computer.Add("Main board1");
        }

        public Computer GetComputer()
        {
            return computer;
        }
    }
    /// <summary>
    /// 具体创建者ConcreteBuilder2
    /// </summary>

    public class ConcreteBuilder2:Builder
    {
        Computer computer = new Computer();
        public override void BuildPartCPU()
        {
            computer.Add("CPU2");
        }

        public override void BuildPartMainBoard()
        {
            computer.Add("Main board2");
        }

        public override Computer GetComputer()
        {
            return computer;
        }
    }
}
