using System;
using System.Collections.Generic;
using System.Linq;
public interface IBook
{
    public int Id{get;set;}
    public string Title{get;set;}
    public string Author{get;set;}
    public string Category{get;set;}
    public int price{get;set;}
  
}
public class Book: IBook
{
    public int Id{get;set;}
    public string Title{get;set;}
    public string Author{get;set;}
    public string Category{get;set;}
    public int price{get;set;}
  
}
public interface ILibrarySystem
{
    void AddBook(IBook book, int quantity);
    voidd RemoveBook(Ibook book, int quantity);
    int CalculateTotal();
    List<(string,int)> CategoryTotalPrice();
    List<(string,int,int)> BooksInfo();
    List<(string,string,int)> CategoryAndAuthorWithCount();
}
public class LibrarySystem : ILibrarySystem
{


}
