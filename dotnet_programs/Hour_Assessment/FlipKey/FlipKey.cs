using System;
using System.Text;
public class FlipKey
{
    public string cleansandinvert(string input)
    {
        if( string.IsNullOrEmpty(input)||input.Length<6)
        {
            return "";
        }
       foreach(char ch in input)
        {
            if(!char.IsLetter(ch))
            return "";
        }
        input=input.ToLower();
        StringBuilder sb=new StringBuilder();
        foreach (char ch in input)
        {
            if ((int)ch%2!=0)
                sb.Append(ch);
        }
        char[] arr=sb.ToString().ToCharArray();
        Array.Reverse(arr);
        for (int i=0;i<arr.Length;i++)
        {
            if (i%2==0)
                arr[i]=char.ToUpper(arr[i]);
        }
        return new string(arr);
    }
}