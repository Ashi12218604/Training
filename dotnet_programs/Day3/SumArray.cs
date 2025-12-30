using System;
public class SumArray
    {
      public static int SA(int a = 10, params int[] arr)
    {
        int res = 0;
        foreach(int i in arr)
        {
            res += i;
        }
        res += a;
        return res;
    }  
    }

    // NOMRAL, DEFAULt, PARAMS PARAMETER  <-- ORDER OF PARAMETERS