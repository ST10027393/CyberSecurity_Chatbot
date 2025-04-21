using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10027393_GeniusMuzama_Chatbot_Part1
{
    internal class Chat
    {
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
                    Console.WriteLine("Bot: Please type a question, I'm here to help!");
                    continue;
                }

                if (input == "exit" || input == "quit")
                {
                    Console.WriteLine("Bot: Goodbye! Stay safe online 🛡️");
                    break;
                }

                RespondToUser(input);
            }
        }

        public void RespondToUser(string input)
        {
            // Use Contains for flexible matching
            if (input.Contains("how are you"))
            {
                Console.WriteLine("Bot: I'm just a bunch of code, but I'm functioning securely! 😊");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                Console.WriteLine("Bot: My job is to help you learn how to stay safe online. Ask me anything about cybersecurity!");
            }
            else if (input.Contains("ask") || input.Contains("help"))
            {
                Console.WriteLine("Bot: You can ask me about safe passwords, spotting phishing scams, or how to browse safely.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Bot: Always use a strong password—at least 12 characters with numbers, symbols, and both uppercase and lowercase letters.");
                Console.WriteLine("Bot: Never reuse passwords and consider using a password manager.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Bot: Phishing is when scammers pretend to be someone you trust—like a bank—to steal info.");
                Console.WriteLine("Bot: Always check the sender's email and avoid clicking suspicious links.");
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                Console.WriteLine("Bot: Use secure (HTTPS) websites, don't download from unknown sources, and keep your browser updated.");
            }
            else
            {
                Console.WriteLine("Bot: Hmm... I didn’t quite get that. Try asking about passwords, phishing, or safe browsing.");
            }
        }

    }
}
