using System;
using System.Text.RegularExpressions;
namespace LogProcessing{
public class LogParser
{
    private readonly string validLineRegexPattern=@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
    private readonly string splitLineRegexPattern=@"<\*\*\*>|<====>|<\^\*>";
    private readonly string quotedPasswordRegexPattern="\"password\"";
    private readonly string endofLineRegexPattern=@"end-of-line\d+";
    private readonly string weakPasswordRegexPattern=@"password[a-zA-Z0-9]+";
    public bool IsValid(string text)
    {
        return Regex.IsMatch(text,validLineRegexPattern);
    }
    public string[] SplitLogLine(String text)
    {
        return Regex.Split(text,splitLineRegexPattern);
    }
    public int countquotespass(string lines)
    {
        return Regex.Matches(lines,quotedPasswordRegexPattern,RegexOptions.IgnoreCase).Count;
    }
    public string removelinetext(string line)
    {
        return Regex.Replace(line,endofLineRegexPattern,"").Trim();
    }
public string[] listlineswithapss(string[] lines)
    {
        string[] output=new string[lines.Length];
        for (int i=0;i<lines.Length;i++)
        {
            Match match=Regex.Match(lines[i],weakPasswordRegexPattern,RegexOptions.IgnoreCase
            );
            if(match.Success)
            output[i]=match.Value+": "+lines[i];
            else
            output[i]="----:"+lines[i];
        }
        return output;
    }
}
}