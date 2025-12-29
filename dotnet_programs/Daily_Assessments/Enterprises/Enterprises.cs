using System;
using System.Collections;
using System.Collections.Generic;

class Programs
{
    public static double avgProductPrice;    
    public static int[,] branchSales;  
    public static int branches, months;

    public static void Task1_ProductPriceAnalysis()
    {
        Console.WriteLine("--------------- TASK 1 : PRODUCT PRICE ANALYSIS ----------------");

        Console.WriteLine("Enter number of products:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] products = new int[n];

        for (int i = 0; i < n; i++)
        {
            int price;
            do
            {
                Console.WriteLine("Enter positive price for product " + (i + 1));
                price = Convert.ToInt32(Console.ReadLine());
            }
            while (price <= 0);

            products[i] = price;
        }

        double sum = 0;
        for (int i = 0; i < n; i++)
            sum += products[i];

        avgProductPrice = sum / n;
        Console.WriteLine("Average Price = " + avgProductPrice);

        Array.Sort(products);

        for (int i = 0; i < n; i++)
        {
            if (products[i] < avgProductPrice)
                products[i] = 0;
        }

        Array.Resize(ref products, products.Length + 5);

        for (int i = n; i < products.Length; i++)
            products[i] = (int)avgProductPrice;

        Console.WriteLine("\nFinal Product Array:");
        for (int i = 0; i < products.Length; i++)
            Console.WriteLine("Index " + i + " -> " + products[i]);
    }

    public static void Task2_BranchSales()
    {
        Console.WriteLine("\n--------------- TASK 2 : BRANCH SALES ANALYSIS ----------------");

        Console.WriteLine("Enter number of branches:");
        branches = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter number of months:");
        months = Convert.ToInt32(Console.ReadLine());

        branchSales = new int[branches, months];

        for (int i = 0; i < branches; i++)
        {
            Console.WriteLine("\nEnter sales for Branch " + (i + 1));
            for (int j = 0; j < months; j++)
            {
                branchSales[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        int highestSale = int.MinValue;

        for (int i = 0; i < branches; i++)
        {
            int total = 0;
            for (int j = 0; j < months; j++)
            {
                total += branchSales[i, j];
                if (branchSales[i, j] > highestSale)
                    highestSale = branchSales[i, j];
            }
            Console.WriteLine("Total Sales for Branch " + (i + 1) + " = " + total);
        }

        Console.WriteLine("Highest Monthly Sale Across All Branches = " + highestSale);
    }

    public static void Task3_JaggedPerformance()
    {
        Console.WriteLine("\n--------------- TASK 3 : PERFORMANCE JAGGED ARRAY ----------------");

        int[][] jagged = new int[branches][];

        for (int i = 0; i < branches; i++)
        {
            int count = 0;

            for (int j = 0; j < months; j++)
            {
                if (branchSales[i, j] >= avgProductPrice)
                    count++;
            }

            jagged[i] = new int[count];

            int idx = 0;

            for (int j = 0; j < months; j++)
            {
                if (branchSales[i, j] >= avgProductPrice)
                {
                    jagged[i][idx] = branchSales[i, j];
                    idx++;
                }
            }
        }

        Console.WriteLine("\nJagged Array (Sales >= Average Product Price):");
        for (int i = 0; i < branches; i++)
        {
            Console.Write("Branch " + (i + 1) + ": ");
            if (jagged[i].Length == 0)
                Console.Write("No qualifying values");
            else
            {
                for (int j = 0; j < jagged[i].Length; j++)
                    Console.Write(jagged[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static void Task4_CustomerCleaning()
    {
        Console.WriteLine("\n--------------- TASK 4 : CUSTOMER TRANSACTION CLEANING ----------------");

        Console.WriteLine("Enter number of customer transactions:");
        int t = Convert.ToInt32(Console.ReadLine());

        List<int> customers = new List<int>();

        for (int i = 0; i < t; i++)
        {
            Console.WriteLine("Enter Customer ID:");
            customers.Add(Convert.ToInt32(Console.ReadLine()));
        }

        HashSet<int> hs = new HashSet<int>(customers);
        List<int> cleaned = new List<int>(hs);

        Console.WriteLine("\nCleaned Customer List:");
        foreach (int x in cleaned)
            Console.WriteLine(x);

        Console.WriteLine("Duplicates Removed = " + (customers.Count - cleaned.Count));
    }

    public static void Task5_TransactionFiltering()
    {
        Console.WriteLine("\n--------------- TASK 5 : FINANCIAL TRANSACTION FILTER ----------------");

        Console.WriteLine("Enter number of transactions:");
        int trans = Convert.ToInt32(Console.ReadLine());

        Dictionary<int, double> dict = new Dictionary<int, double>();

        for (int i = 0; i < trans; i++)
        {
            Console.WriteLine("\nEnter Transaction ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            if (dict.ContainsKey(id))
            {
                Console.WriteLine("Duplicate ID – Enter Again");
                i--;
                continue;
            }

            Console.WriteLine("Enter Amount:");
            double amount = Convert.ToDouble(Console.ReadLine());

            dict.Add(id, amount);
        }

        SortedList<int, double> sortedHigh = new SortedList<int, double>();

        foreach (KeyValuePair<int, double> kv in dict)
        {
            if (kv.Value >= avgProductPrice)
                sortedHigh.Add(kv.Key, kv.Value);
        }

        Console.WriteLine("\nHigh Value Transactions (Sorted):");
        foreach (KeyValuePair<int, double> kv in sortedHigh)
            Console.WriteLine("ID: " + kv.Key + " Amount: " + kv.Value);
    }

    public static void Task6_ProcessFlow()
    {
        Console.WriteLine("\n--------------- TASK 6 : PROCESS FLOW STACK & QUEUE ----------------");

        Console.WriteLine("Enter number of operations:");
        int ops = Convert.ToInt32(Console.ReadLine());

        Queue<string> q = new Queue<string>();
        Stack<string> s = new Stack<string>();

        for (int i = 0; i < ops; i++)
        {
            Console.WriteLine("Enter operation name:");
            string op = Console.ReadLine();
            q.Enqueue(op);
            s.Push(op);
        }

        Console.WriteLine("\nProcessing Queue (FIFO):");
        while (q.Count > 0)
            Console.WriteLine(q.Dequeue());

        Console.WriteLine("\nUndo Last Two Operations:");
        for (int i = 0; i < 2 && s.Count > 0; i++)
            Console.WriteLine("Undone: " + s.Pop());
    }

    public static void Task7_LegacyRisk()
    {
        Console.WriteLine("\n--------------- TASK 7 : LEGACY DATA RISK ----------------");

        Console.WriteLine("Enter number of users:");
        int u = Convert.ToInt32(Console.ReadLine());

        Hashtable ht = new Hashtable();
        ArrayList al = new ArrayList();

        for (int i = 0; i < u; i++)
        {
            Console.WriteLine("\nEnter Username:");
            string user = Console.ReadLine();

            Console.WriteLine("Enter Role:");
            string role = Console.ReadLine();

            ht[user] = role;

            al.Add(user);
            al.Add(role);
        }

        Console.WriteLine("\nHashtable (Key-Value Mapping):");
        foreach (DictionaryEntry d in ht)
            Console.WriteLine(d.Key + " -> " + d.Value);

        Console.WriteLine("\nArrayList (Mixed Data Risk):");
        foreach (var x in al)
            Console.WriteLine(x);

        Console.WriteLine("\nMixed storage is risky because:");
        Console.WriteLine("- No type safety");
        Console.WriteLine("- Hard to identify pairs");
        Console.WriteLine("- Prone to runtime errors\n");
    }

}