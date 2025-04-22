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
            DisplayWelcome();

            //Chat class
            Chat c = new Chat();
            c.UserChat();
        }//main end

        //method that plays chatbot intro 
        static void PlayGreeting()
        {
            /*exception handling with try catch if audio is missing
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
        static void DisplayWelcome()
        {
            string name = UsernameValidation();
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

        //User Name input error handling
        static string UsernameValidation()
        {
            while (true)
            {
                try
                {
                    Console.Write("Please enter your name (or press Enter to continue anonymously): \n");
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.Write("Would you like to continue anonymously? (yes/no): \n");
                        string choice = Console.ReadLine()?.Trim().ToLower();

                        if (choice == "yes" || choice == "y")
                        {
                            return "Guest";
                        }
                        else if (choice == "no" || choice == "n")
                        {
                            Console.WriteLine("Please enter your name to continue.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please answer 'yes' or 'no'.");
                            continue;
                        }
                    }

                    // Validate name contains at least one letter
                    if (!input.Any(char.IsLetter))
                    {
                        throw new ArgumentException("Name must contain at least one letter.");
                    }

                    // Validate reasonable length
                    if (input.Length > 50)
                    {
                        throw new ArgumentException("Name is too long (max 50 characters).");
                    }

                    return input;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Invalid name: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    return "Guest"; // Fallback to anonymous
                }//catch
            }//while end
        }//end username validation

    }//Program class end
}//namespace end
