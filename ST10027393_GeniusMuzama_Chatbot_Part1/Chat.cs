using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10027393_GeniusMuzama_Chatbot_Part1
{
    internal class Chat
    {
        /*
        public void UserChat()
        {
            Console.WriteLine("\nYou can ask me about:");
            Console.WriteLine("- Password safety\n- Phishing\n- Safe browsing\n(Type 'exit' to leave)\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYou: ");
                Console.ResetColor();

                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Genius: Please type a question, I'm here to help!");
                    continue;
                }

                if (input == "exit" || input == "quit")
                {
                    Console.WriteLine("Genius: Goodbye! Stay safe online :)");
                    break;
                }

                RespondToUser(input);
            }//while end
        }*/

        public void UserChat()
        {
            Console.WriteLine("\nYou can ask me about:");
            Console.WriteLine("- Password safety\n- Phishing\n- Safe browsing\n(Type 'exit' to leave)\n");

            try
            {
                const int maxAttempts = 10;
                int emptyInputAttempts = 0;

                while (emptyInputAttempts < maxAttempts)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\nYou: ");
                        Console.ResetColor();

                        string input = Console.ReadLine()?.ToLowerInvariant()?.Trim() ?? string.Empty;

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            emptyInputAttempts++;

                            if (emptyInputAttempts >= 3 && emptyInputAttempts < maxAttempts)
                            {
                                Console.WriteLine("Genius: Type 'help' for suggestions or ask a question");
                            }
                            else if (emptyInputAttempts < 3)
                            {
                                Console.WriteLine("Genius: Please type a question, I'm here to help!");
                            }
                            continue;
                        }

                        // Reset empty input counter if valid input received
                        emptyInputAttempts = 0;

                        if (input.Length > 500)
                        {
                            Console.WriteLine("Genius: Let's keep questions under 500 characters please!");
                            continue;
                        }

                        if (input == "exit" || input == "quit")
                        {
                            Console.WriteLine("Genius: Goodbye! Stay safe online :)");
                            break;
                        }

                        RespondToUser(input);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"Genius: Input error - {ex.Message}");
                        if (emptyInputAttempts++ > 2) throw;
                    }
                    finally
                    {
                        Console.ResetColor();
                    }
                }

                if (emptyInputAttempts >= maxAttempts)
                {
                    Console.WriteLine("\nGenius: Session ended due to multiple empty inputs");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Genius: Critical error - {ex.Message}");
            }
        }//user chat end
        public void RespondToUser(string input)
        {
            // Use Contains for flexible matching
            if (input.Contains("how are you"))
            {
                Console.WriteLine("Genius: I'm just a bunch of code, but I'm functioning securely!");
            }
            else if (input == "help")
            {
                Console.WriteLine("Genius: Try these topics:\n- 'password tips'\n- 'phishing examples'\n- 'browsing safety'");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                Console.WriteLine("Genius: My job is to help you learn how to stay safe online. Ask me anything about cybersecurity!");
            }
            else if (input.Contains("ask") || input.Contains("help"))
            {
                Console.WriteLine("Genius: You can ask me about safe passwords, spotting phishing scams, or how to browse safely.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Genius: Always use a strong password—at least 12 characters with numbers, symbols, and both uppercase and lowercase letters.");
                Console.WriteLine("Genius: Never reuse passwords and consider using a password manager.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Genius: Phishing is when scammers pretend to be someone you trust—like a bank—to steal info.");
                Console.WriteLine("Genius: Always check the sender's email and avoid clicking suspicious links.");
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                Console.WriteLine("Genius: Use secure (HTTPS) websites, don't download from unknown sources, and keep your browser updated.");
            }
            else
            {
                Console.WriteLine("Genius: Hmm... I didn’t quite get that. Try asking about passwords, phishing, or safe browsing.");
            }
        }

    }
}
