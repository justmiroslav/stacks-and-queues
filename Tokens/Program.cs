internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter an expression: ");
        string expression = Console.ReadLine();
        List<string> opers1 = new List<string> { "+", "-", "*", "/", "^", "(", ")" };
        List<string> opers2 = new List<string> { "+", "-", "*", "/", "^"};
        Queue<string> queue = new Queue<string>();
        MyStack<string> stack = new MyStack<string>(50);
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
            if (!opers1.Contains(s))
            {
                queue.Enqueue(s);
            }
            else if (opers2.Contains(s))
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
                    string lastOper = stack.Peek();
                    if (lastOper == "+" || lastOper == "-")
                    {
                        lastPriority = 1;
                    }
                    else if (lastOper == "*" || lastOper == "/")
                    {
                        lastPriority = 2;
                    }
                    else if (lastOper == "^")
                    {
                        lastPriority = 3;
                    }

                    if (curPriority <= lastPriority)
                    {
                        lastOper = stack.Pop();
                        queue.Enqueue(lastOper);
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

        foreach (var q in queue)
        {
            if (q is null)
            {
                continue;
            }
            if (opers2.Contains(q))
            {
                double operand2 = Double.Parse(stack.Pop());
                double operand1 = Double.Parse(stack.Pop());
                double result = 0;
                if (q == "+")
                {
                    result = operand1 + operand2;
                }
                else if (q == "-")
                {
                    result = operand1 - operand2;
                }
                else if (q == "*")
                    result = operand1 * operand2;
                else if (q == "/")
                    result = operand1 / operand2;
                else if (q == "^")
                {
                    result = Math.Pow(operand1, operand2);
                }
                stack.Push(result.ToString());
            }
            else if (!opers2.Contains(q))
            {
                double newQ = double.Parse((string)q);
                stack.Push(newQ.ToString());
            }
        }
        double final = double.Parse(stack.Pop());
        Console.WriteLine($"Result: {final}");
    }
}