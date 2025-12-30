using System;
/* parameters with default values
 must be placed at the end of the parameter list, and cannot be in the middle of non-default arguments*/
class Named
{
    string name;
    int age;
    string city;
    char gender;
    public Named(string name,int age,string city,char gender='M')
    {
        this.name=name;
        this.age=age;
        this.city=city;
        this.gender=gender;
    }
}
