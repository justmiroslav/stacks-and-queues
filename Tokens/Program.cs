class Program
{
    static void Main()
    {
        Console.Write("Enter an expression: ");
        string expression = Console.ReadLine() ?? throw new InvalidOperationException();

        List<string> tokens = new List<string>();
        string buffer = "";

        for (int i = 0; i < expression.Length; i++)
        {
            char c = expression[i];

            if (Char.IsDigit(c))
            {
                buffer += c;
            }
            else if (c == ' ')
            {
                if (buffer.Length > 0)
                {
                    tokens.Add(buffer);
                    buffer = "";
                }
            }
            else
            {
                if (buffer.Length > 0)
                {
                    tokens.Add(buffer);
                    buffer = "";
                }
                tokens.Add(c.ToString());
            }
        }

        if (buffer.Length > 0)
        {
            tokens.Add(buffer);
        }

        foreach (string token in tokens)
        {
            Console.WriteLine(token);
        }
    }
}