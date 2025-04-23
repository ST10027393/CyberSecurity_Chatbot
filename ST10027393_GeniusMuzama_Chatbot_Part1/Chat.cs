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
            // Display menu with styling
            ChatStyler.PrintHeader("GC Security Chatbot");
            ChatStyler.PrintMenu(new string[] {
                "Password safety",
                "Phishing scams",
                "Safe browsing",
                "Type 'exit' to quit"
            });

            try
            {
                const int maxAttempts = 10;
                int emptyInputAttempts = 0;

                while (emptyInputAttempts < maxAttempts)
                {
                    try
                    {
                        // Get user input with styled prompt
                        ChatStyler.PrintUserMessage(""); // Creates empty user bubble
                        Console.SetCursorPosition(7, Console.CursorTop - 1); // Position cursor after "YOU: "

                        string input = Console.ReadLine()?.ToLowerInvariant()?.Trim() ?? string.Empty;

                        if (string.IsNullOrWhiteSpace(input))
                        {
                            emptyInputAttempts++;

                            if (emptyInputAttempts >= 3 && emptyInputAttempts < maxAttempts)
                            {
                                ChatStyler.PrintWarning("Type 'help' for suggestions or ask a question");
                            }
                            else if (emptyInputAttempts < 3)
                            {
                                ChatStyler.TypeWithEffect("Please type a question, I'm here to help!",
                                    color: ChatStyler.Colors.System);
                            }
                            continue;
                        }

                        // Reset counter on valid input
                        emptyInputAttempts = 0;

                        if (input.Length > 500)
                        {
                            ChatStyler.PrintWarning("Let's keep questions under 500 characters please!");
                            continue;
                        }

                        if (input == "exit" || input == "quit")
                        {
                            ChatStyler.TypeWithEffect("Goodbye! Stay safe online :)",
                                color: ChatStyler.Colors.Bot);
                            break;
                        }

                        // Show thinking animation before responding
                        ChatStyler.ShowThinking();
                        RespondToUser(input);
                    }
                    catch (IOException ex)
                    {
                        ChatStyler.PrintWarning($"Input error: {ex.Message}");
                        if (emptyInputAttempts++ > 2) throw;
                    }
                }

                if (emptyInputAttempts >= maxAttempts)
                {
                    ChatStyler.PrintWarning("Session ended due to multiple empty inputs");
                }
            }
            catch (Exception ex)
            {
                ChatStyler.PrintWarning($"Critical error: {ex.Message}");
            }
        }

        public void RespondToUser(string input)
        {
            // Format all responses using styled bubbles
            if (input.Contains("how are you"))
            {
                ChatStyler.PrintBotMessage("I'm just a bunch of code, but I'm functioning securely!");
            }
            else if (input == "help")
            {
                ChatStyler.PrintBotMessage("Try these topics:\n" +
                    "• 'password tips'\n" +
                    "• 'phishing examples'\n" +
                    "• 'browsing safety'\n\n" +
                    "Or ask me anything about cybersecurity!");
            }
            else if (input.Contains("purpose") || input.Contains("what do you do"))
            {
                ChatStyler.PrintBotMessage("My job is to help you learn how to stay safe online.\n" +
                    "I can explain:\n" +
                    "• Password best practices\n" +
                    "• How to spot scams\n" +
                    "• Secure browsing techniques");
            }
            else if (input.Contains("password"))
            {
                ChatStyler.PrintBotMessage("Password Security Tips:\n" +
                    "- At least 12 characters\n" +
                    "- Mix of uppercase & lowercase\n" +
                    "- Numbers and special symbols\n" +
                    "- Never reuse passwords\n\n" +
                    "Consider using a password manager!");
            }
            else if (input.Contains("phishing"))
            {
                ChatStyler.PrintBotMessage("Phishing Alert:\n" +
                    "Scammers pretend to be trusted entities to steal your info.\n\n" +
                    "Red flags:\n" +
                    "- Urgent/threatening language\n" +
                    "- Suspicious sender addresses\n" +
                    "- Requests for sensitive data");
            }
            else if (input.Contains("safe browsing") || input.Contains("browsing"))
            {
                ChatStyler.PrintBotMessage("Safe Browsing Guidelines:\n" +
                    "• Look for HTTPS in URLs\n" +
                    "• Don't download from untrusted sites\n" +
                    "• Keep browser/plugins updated\n" +
                    "• Use ad-blockers to avoid malvertising");
            }
            else
            {
                ChatStyler.PrintBotMessage("Hmm... I didn't quite understand that.\n" +
                    "Try asking about:\n" +
                    "- Password security\n" +
                    "- Phishing scams\n" +
                    "- Safe browsing practices\n\n" +
                    "Or type 'help' for more options.");
            }
        }

    }
}
