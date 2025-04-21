using System.Media;

namespace ST10027393_GeniusMuzama_Chatbot_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Company logo GC Security (genius cyber security) made using ascii
            * I used patorjk ascii converter
            *  - https://patorjk.com/software/taag/#p=display&f=Graffiti&t=GC%20SECURITY
            */
            string asciiLogo = @"

  _________________     _____________________________  ____ _____________.___________________.___.
 /  _____/\_   ___ \   /   _____/\_   _____/\_   ___ \|    |   \______   \   \__    ___/\__  |   |
/   \  ___/    \  \/   \_____  \  |    __)_ /    \  \/|    |   /|       _/   | |    |    /   |   |
\    \_\  \     \____  /        \ |        \\     \___|    |  / |    |   \   | |    |    \____   |
 \______  /\______  / /_______  //_______  / \______  /______/  |____|_  /___| |____|    / ______|
        \/        \/          \/         \/         \/                 \/                \/       
";
            Console.WriteLine(asciiLogo);

            //Greeting intro
            PlayGreeting();

            // Display personalized greeting
            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            DisplayWelcome(name);

            //Chat class
            Chat c = new Chat();
            c.UserChat();
        }//main end

        //method that plays chatbot intro 
        static void PlayGreeting()
        {
            /*exception handling with try catch in audio is missing
            *or inaccessible
            */
            try
            {
                SoundPlayer player = new SoundPlayer("media/intro.wav");
                player.PlaySync(); 
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The intro sound file was not found.");
                Console.WriteLine("Please ensure audio indicated " +
                    "exists in the correct location.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occurred while playing the greeting: {e.Message}");
            }//try-catch end
        }//greeting method end


        //Welcome method
        static void DisplayWelcome(string name)
        {
            string welcomeArt = @"

 __      _____________.__  _________  ________      _____  ___________
/  \    /  \_   _____/|  | \_   ___ \ \_____  \    /     \ \_   _____/
\   \/\/   /|    __)_ |  | /    \  \/  /   |   \  /  \ /  \ |    __)_ 
 \        / |        \|  |_\     \____/    |    \/    Y    \|        \
  \__/\  / /_______  /|____/\______  /\_______  /\____|__  /_______  /
       \/          \/              \/         \/         \/        \/ 

";
            Console.WriteLine(welcomeArt);
            Console.WriteLine($"\nHi {name}!");
            Console.WriteLine("Welcome to GC Security's Chatbot");
            Console.WriteLine("How may I assist you today?");
        }

    }//Program class end
}//namespace end
