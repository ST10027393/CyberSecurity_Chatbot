using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ST10027393_GeniusMuzama_Chatbot_Part1
{
    internal class Welcome
    {
        public static void Logo() 
        {
            string asciiLogo = @"
  _________________     _____________________________  ____ _____________.___________________.___.
 /  _____/\_   ___ \   /   _____/\_   _____/\_   ___ \|    |   \______   \   \__    ___/\__  |   |
/   \  ___/    \  \/   \_____  \  |    __)_ /    \  \/|    |   /|       _/   | |    |    /   |   |
\    \_\  \     \____  /        \ |        \\     \___|    |  / |    |   \   | |    |    \____   |
 \______  /\______  / /_______  //_______  / \______  /______/  |____|_  /___| |____|    / ______|
        \/        \/          \/         \/         \/                 \/                \/       
";
            ChatStyler.PrintCenteredAsciiArt(asciiLogo, ConsoleColor.Green);
        }

        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("media/intro.wav");
                ChatStyler.TypeWithEffect("Initializing audio greeting...", color: ChatStyler.Colors.System);
                player.PlaySync();
            }
            catch (FileNotFoundException)
            {
                ChatStyler.PrintWarning("Error: The intro sound file was not found.");
                ChatStyler.TypeWithEffect("Please ensure 'media/intro.wav' exists in the correct location.", 
                    color: ChatStyler.Colors.System);
            }
            catch (Exception e)
            {
                ChatStyler.PrintWarning($"Audio error: {e.Message}");
            }
        }

        public static void DisplayWelcome()
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
            Console.Clear();
            ChatStyler.PrintCenteredAsciiArt(welcomeArt, ConsoleColor.Cyan);
            
            ChatStyler.TypeWithEffect($"\nHi {name}!", 40, ChatStyler.Colors.Bot);
            ChatStyler.TypeWithEffect("Welcome to GC Security's Chatbot", 30, ChatStyler.Colors.Bot);
            ChatStyler.PrintDivider('~', 50);
            ChatStyler.TypeWithEffect("How may I assist you today?", 30, ChatStyler.Colors.Bot);
        }

        public static string UsernameValidation()
        {
            int attempts = 0;
            const int maxAttempts = 3;

            while (attempts < maxAttempts)
            {
                try
                {
                    ChatStyler.TypeWithEffect("Please enter your name (or press Enter to continue anonymously):", 
                        color: ChatStyler.Colors.System);
                    
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(input))
                    {
                        ChatStyler.TypeWithEffect("Would you like to continue anonymously? (yes/no):", 
                            color: ChatStyler.Colors.System);
                        
                        string choice = Console.ReadLine()?.Trim().ToLower();

                        if (choice == "yes" || choice == "y") return "Guest";
                        if (choice == "no" || choice == "n") continue;
                        
                        ChatStyler.PrintWarning("Invalid choice. Please answer 'yes' or 'no'.");
                        attempts++;
                        continue;
                    }

                    if (!input.Any(char.IsLetter))
                        throw new ArgumentException("Name must contain at least one letter");

                    if (input.Length > 50)
                        throw new ArgumentException("Name is too long (max 50 characters)");

                    return input;
                }
                catch (ArgumentException ex)
                {
                    attempts++;
                    ChatStyler.PrintWarning(ex.Message);
                    ChatStyler.TypeWithEffect($"Attempts remaining: {maxAttempts - attempts}", 
                        color: ChatStyler.Colors.System);
                }
                catch (Exception ex)
                {
                    ChatStyler.PrintWarning($"Unexpected error: {ex.Message}");
                    return "Guest";
                }
            }

            ChatStyler.TypeWithEffect("Maximum attempts reached. Continuing as Guest...", 
                color: ChatStyler.Colors.Warning);
            return "Guest";
        }//end username validation
    }
}
