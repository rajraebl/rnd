using System;

// FIRST IMPLEMENT THE FACTORY PATTERN MORE THAN 1 TIME
//THEN THOSE INDIVIDUAL FACTORIES (TEXTFACTORY AND BUTTONFACTORY) BOTH WILL IMPLEMENT ANOTHER ABSTRACT CLASS (UIABSTRACTCLASS)
//THAT ABSTRACT FACTORY CLASS WILL HAVE A METHOD THAT WILL RETURN THE IRENDER (TEXTBOX,TEXTBOX1,BUTTON,BUTTON1)
//THE OUTPUT WILL COME FIRST FACTORY WILL BE DECIDED THEN ONE OF ITS PRODUCT WILL BE DECIDED.
//http://www.codeproject.com/Articles/28309/Design-pattern-FAQ-Part-Training#Canyouexplainfactorypattern
//GOAL: CLIENT CAN NOT ACCESS CONCRETECLASS, THEN HE ALSO CAN NOT ACCESS FACTORY.
//TO GET THE PRODUCT HE'LL NEED TO GO TO FIRST ABSTRACTFACTORY--->FACTORY---->PRODUCT

//https://vivekcek.wordpress.com/2013/03/17/simple-factory-vs-factory-method-vs-abstract-factory-by-example/

namespace DesignPatterns_
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

    public abstract class UIAbstractFactory //abstract class without any abstract method
    {
        public static IRender getUIObject(int i)
        {
            if (i == 1)
            {
                return TextFactory.GetText(2);
            }
            else
            {
                return ButtonFactory.GetButton(1);

            }
        }
    }

    public class ButtonFactory : AbstractFactory
    {
        public static IRender GetButton(int i)
        {
            IRender item;

            switch (i)
            {
                case 1:
                    item = new Button();
                    break;
                case 2:
                    item = new Button1();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return item;

        }
    }
    public class TextFactory : UIAbstractFactory
    {
        public static IRender GetText(int i)
        {
            IRender item;

            switch (i)
            {
                case 1:
                    item = new TextBox();
                    break;
                case 2:
                    item = new TextBox1();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return item;

        }
    }

    public class AbstractFactory
    {
        public static void AbstractFactoryMain()
        {
            var Item = UIAbstractFactory.getUIObject(1);
            Item.render();
        }
    }


    public class TextBox1 : IRender
    {

        public void render()
        {
            Console.WriteLine("input type=text1");
        }
    }
    public class Button1 : IRender
    {

        public void render()
        {
            Console.WriteLine("input type=button1");
        }
    }

}
