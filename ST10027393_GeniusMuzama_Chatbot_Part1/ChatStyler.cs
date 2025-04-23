using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10027393_GeniusMuzama_Chatbot_Part1
{
    internal class ChatStyler
    {
        // Color scheme
        public static class Colors
        {
            public static ConsoleColor Bot = ConsoleColor.White;
            public static ConsoleColor User = ConsoleColor.Green;
            public static ConsoleColor System = ConsoleColor.Yellow;
            public static ConsoleColor Warning = ConsoleColor.Red;
            public static ConsoleColor Highlight = ConsoleColor.Magenta;
        }

        // Typing effect with configurable speed
        public static void TypeWithEffect(string text, int speed = 30, ConsoleColor? color = null)
        {
            Console.ForegroundColor = color ?? Colors.Bot;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);

                if (char.IsPunctuation(c))
                    Thread.Sleep(speed * 4); // Longer pause for punctuation
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Section headers
        public static void PrintHeader(string title)
        {
            Console.ForegroundColor = Colors.System;
            string border = new string('═', title.Length + 4);
            Console.WriteLine($"\n╔{border}╗");
            Console.WriteLine($"║  {title.ToUpper()}  ║");
            Console.WriteLine($"╚{border}╝");
            Console.ResetColor();
        }

        // Chat bubbles
        public static void PrintUserMessage(string message)
        {
            Console.ForegroundColor = Colors.User;
            Console.WriteLine($"\n YOU: {message}");
            Console.ResetColor();
        }

        public static void PrintBotMessage(string message)
        {
            Console.ForegroundColor = Colors.Bot;
            string[] lines = message.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            int maxLength = 0;
            foreach (var line in lines)
            {
                if (line.Length > maxLength) maxLength = line.Length;
            }

            Console.WriteLine("\n ┌" + new string('─', maxLength + 2) + "┐");
            foreach (var line in lines)
            {
                Console.WriteLine($" │ {line.PadRight(maxLength)} │");
            }
            Console.WriteLine(" └" + new string('─', maxLength + 2) + "┘");
            Console.ResetColor();
        }

        // Warning messages
        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = Colors.Warning;
            Console.WriteLine($"\n {message}");
            Console.ResetColor();
        }

        // Menu display
        public static void PrintMenu(string[] options)
        {
            Console.ForegroundColor = Colors.System;
            Console.WriteLine("\n" + new string('*', 30));
            Console.WriteLine("  Available Options:");

            foreach (var option in options)
            {
                Console.WriteLine($"  • {option}");
            }

            Console.WriteLine(new string('*', 30));
            Console.ResetColor();
        }

        // Thinking animation
        public static void ShowThinking(int seconds = 2)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\nThinking ");

            for (int i = 0; i < seconds * 2; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        // Highlight important text
        public static void HighlightText(string text)
        {
            Console.ForegroundColor = Colors.Highlight;
            Console.Write(text);
            Console.ResetColor();
        }

        // Divider line
        public static void PrintDivider(char symbol = '─', int length = 40)
        {
            Console.ForegroundColor = Colors.System;
            Console.WriteLine("\n" + new string(symbol, length));
            Console.ResetColor();
        }

        //ASCII art styler
        public static void PrintCenteredAsciiArt(string asciiArt, ConsoleColor color = ConsoleColor.Green)
        {
            // Save current console color
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            // Split the ASCII art into lines
            string[] lines = asciiArt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            // Get console width (minimum 80 to prevent weird wrapping)
            int consoleWidth = Math.Max(Console.WindowWidth, 80);

            foreach (string line in lines)
            {
                // Calculate centered position
                int leftPadding = (consoleWidth - line.Length) / 2;
                leftPadding = Math.Max(0, leftPadding); // Ensure padding isn't negative

                // Print the centered line
                Console.WriteLine(line.PadLeft(leftPadding + line.Length));
            }

            // Restore original color
            Console.ForegroundColor = originalColor;
        }
    }
}
