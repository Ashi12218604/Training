using System;
using System.Collections.Generic;
class Program
{   
         static void Main(string[] args)
    {
        IFilmLibrary library=new FilmLibrary();
        library.AddFilm(new Film("3 Idiots", "Raj Kumar Hirani", 2009));
        library.AddFilm(new Film("Stranger Things", "Duffer Brothers", 2016));
        library.AddFilm(new Film("People we meet on vacations", "Bret Haley", 2026));
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
        Console.WriteLine("\nAll Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"Title: {film.Title} , Director: {film.Director}, Year: {film.Year}");
        }
        Console.WriteLine("\nSearch Result for 'Stranger Things':");
        var searchResult=library.SearchFilm("Stranger Things");
        foreach (var film in searchResult)
        {
            Console.WriteLine($"Title: {film.Title} , Director: {film.Director}, Year: {film.Year}");
        }
        library.RemoveFilm("Stranger Things");
        Console.WriteLine("\nAfter Removal:");
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
    }
}
