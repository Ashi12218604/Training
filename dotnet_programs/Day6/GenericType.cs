using System;

   public class Repository<T> where T : class // where T denotes by reference type and T  is a placeholder for a type
    // only refernce types are allowed- arrays, string, class, object
{
    public T Data;
}
public class Customer
    {
        public string name;

    }
