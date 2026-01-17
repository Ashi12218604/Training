using System;
using System.Collections.Generic;
using System.Linq;
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilm(string query);
    int GetTotalFilmCount();
}
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films=new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        if (film!=null)
        {
            _films.Add(film);
        }
    }
    public void RemoveFilm(string title)
    {
        var film =_films.FirstOrDefault(f =>f.Title.Equals(title,StringComparison.OrdinalIgnoreCase));
       if(film!=null)
        {
            _films.Remove(film);
        }     
    }
    public List<IFilm> GetFilms()
    {
        return _films;
    }
    public List<IFilm> SearchFilm(string query)
    {
          return _films.Where(f =>f.Title.Contains(query,StringComparison.OrdinalIgnoreCase)||
          f.Director.Contains(query,StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public int GetTotalFilmCount()
    {
        return _films.Count;
    }

}



