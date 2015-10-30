using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IRender
    {
        void render();
    }

    public class TextBox : IRender
    {

        public void render()
        {
            Console.WriteLine("input type=text");
        }
    }
    public class Button : IRender
    {

        public void render()
        {
            Console.WriteLine("input type=button");
        }
    }

    public class InputFactory
    {
        public static IRender GetInputItem(int i)
        {
            IRender item;

            switch (i)
            {
                case 1:
                    item = new TextBox();
                    break;
                case 2:
                    item = new Button();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return item;

        }
    }

    public class Factory
    {
        public static void FactoryMain()
        {
            var Item = InputFactory.GetInputItem(1);
            Item.render();
        }
    }
}
