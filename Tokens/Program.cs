internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter an expression: ");
        string expression = Console.ReadLine();
        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();
        string[] tokens = new string[50];
        int priority = 0;
        string buffer = "";
        int i = 0;

        foreach (char e in expression)
        {
            if (Char.IsDigit(e))
            {
                buffer += e;
            }
            else if (Char.IsWhiteSpace(e))
            {
                if (buffer != "")
                {
                    tokens[i] = buffer;
                    buffer = "";
                    i++;
                }
            }
            else if (e == '+' || e == '-' || e == '*' || e == '/' || e == '^' || e == '(' || e == ')')
            {
                if (buffer != "")
                {
                    tokens[i] = buffer;
                    buffer = "";
                    i++;
                }
                tokens[i] = e.ToString();
                i++;
            }
        }
        if (buffer != "")
        {
            tokens[i] = buffer;
        }
        foreach (string s in tokens)
        {
            if (!(s == "+" || s == "-" || s == "*" || s == "/" || s == "^" || s == "(" || s == ")"))
            {
                queue.Enqueue(s);
            }
            else if (s == "+" || s == "-" || s == "*" || s == "/" || s == "^")
            {
                Dictionary<string, int> priorities = new Dictionary<string, int>
                {
                    { "+", 1 },
                    { "-", 1 },
                    { "*", 2 },
                    { "/", 2 },
                    { "^", 3 }
                };
                int curPriority = priorities[s];
                while (stack.Count > 0 && (stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "^"))
                {
                    queue.Enqueue(stack.Pop());
                }
                if (stack.Count > 0 && (stack.Peek() == "+" || stack.Peek() == "-"))
                {
                    int lastPriority = 1;
                    string lastOperator = stack.Peek();
                    if (lastOperator == "+" || lastOperator == "-")
                    {
                        lastPriority = 1;
                    }
                    else if (lastOperator == "*" || lastOperator == "/")
                    {
                        lastPriority = 2;
                    }
                    else if (lastOperator == "^")
                    {
                        lastPriority = 3;
                    }

                    if (curPriority <= lastPriority)
                    {
                        lastOperator = stack.Pop();
                        queue.Enqueue(lastOperator);
                    }
                }

                stack.Push(s);
            }
            else if (s == "(")
            {
                stack.Push(s);
            }
            else if (s == ")")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                {
                    queue.Enqueue(stack.Pop());
                }

                if (stack.Count > 0 && stack.Peek() == "(")
                {
                    stack.Pop();
                }
            }
        }

        while (stack.Count > 0)
        {
            string lastOperator = stack.Pop();
            queue.Enqueue(lastOperator);
        }

        foreach (var token in queue)
        {
            if (token is null)
            {
                continue;
            }
            if (token == "+" || token == "-" || token == "*" || token == "/" || token == "^")
            {
                double operand2 = Double.Parse(stack.Pop());
                double operand1 = Double.Parse(stack.Pop());
                double result = 0;
                
                if (token == "+")
                {
                    result = operand1 + operand2;
                }
                else if (token == "-")
                {
                    result = operand1 - operand2;
                }
                else if (token == "*")
                    result = operand1 * operand2;
                else if (token == "/")
                    result = operand1 / operand2;
                else if (token == "^")
                {
                    result = Math.Pow(operand1, operand2);
                }

                stack.Push(result.ToString());
            }
            else if (!(token == "+" || token == "-" || token == "*" || token == "/" || token == "^"))
            {
                double value = double.Parse(token);
                stack.Push(value.ToString());
            }
        }
        double finalResult = double.Parse(stack.Pop());
        Console.WriteLine($"Result: {finalResult}");;
    }
}