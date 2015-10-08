using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*http://www.dotnet-tricks.com/Tutorial/designpatterns/23JE110913-Command-Design-Pattern---C
     * Command pattern falls under Behavioral Pattern
     * In this pattern, a request is wrapped under an object as a command and passed to invoker object. 
     * Invoker object pass the command to the appropriate object which can handle it and that object executes the command. 
     * This handles the request in traditional ways like as queuing and callbacks.
   When to use it?

    Need to implement callback functionalities.

    Need to support Redo and Undo functionality for commands.

    Sending requests to different receivers which can handle it in different ways.

    Need for auditing and logging of all changes via commands.
    */

    //The Command Interface
    public interface ICommand
    {
        void Execute();
    }

    //Invoker Class (switch dont know if it will switch-on a fan or light or cooler)
    public class Switch
    {
        List<ICommand> commands = new List<ICommand>();

        public void StoreAndExecute(ICommand cmd)
        {
            commands.Add(cmd);
            cmd.Execute();
        }
    }

    //Receiver class, ultimately this will receive command. it could be a TV, Freez, Fan, Light

    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light in On");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is Off");
        }
    }


    //concrete command class
    public class OnCommand : ICommand
    {
        private Light _light;

        public OnCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.TurnOn();
        }
    }

    public class OffCommand : ICommand
    {
        private Light _light;

        public OffCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            _light.TurnOff();
        }
    }


    //now create on and off command by passing the light object
    //then invoke via invoker
    class CommandPattern
    {
        public static void CommandPatternMain()
        {
            Light light = new Light();

            ICommand commandOn = new OnCommand(light);
            ICommand commandOff = new OffCommand(light);

            Switch s = new Switch();
            s.StoreAndExecute(commandOn);
            s.StoreAndExecute(commandOff);

        }
    }
    
}
