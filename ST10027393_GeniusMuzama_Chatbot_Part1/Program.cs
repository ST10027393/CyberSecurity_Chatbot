using System.Media;

namespace ST10027393_GeniusMuzama_Chatbot_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Intro Class

            //Brand logo
            Welcome.Logo();

            //Greeting intro
            Welcome.PlayGreeting();

            // Display personalized greeting
            Welcome.DisplayWelcome();

            //Chat class - in this class I attempted to use non static methods hence the instantiation
            Chat c = new Chat();
            c.UserChat();
        }//main end

    }//Program class end
}//namespace end
