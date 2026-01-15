using System;
public sealed class WorkItem
{
    public int Id{get;set;};
    public string Name{get;set;}
    public SDLCStage Stage{get;set;}
    public HashSet<integer> DependencyIds=new HashSet<integer>(){get;set;}
    public 
}