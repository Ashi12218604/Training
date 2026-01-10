using System;
using System.Collections.Generic;
using System.Linq;
namespace DialingCodesApp
{
    public static class DialingCodes
    {
        public static Dictionary<int,string>GetEmptyDictionary()
        {
            return new Dictionary<int,string>();  
        }
    public static Dictionary<int,string>GetExistingDictionary()
        {
     Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "United States of America");
            dict.Add(55, "Brazil");
            dict.Add(91, "India");
            return dict;
        }
public static Dictionary<int,string> AddCountryToEmptyDictionary(int countrycode,string countryname)
    {
        Dictionary<int,string> dict=new Dictionary<int,string>();
        dict[countrycode]=countryname;
        return dict;    
    }
    public static Dictionary<int,string> AddCountryToExistingDictionary(Dictionary<int,string>existingdictionary,int countrycode,string countryname)
        {
            existingdictionary[countrycode]=countryname;
            return existingdictionary;
        }
    public static string GetCountryNameFromDictionary(Dictionary<int,string> existingdictionary, int countrycode)
        {
            if(existingdictionary.ContainsKey(countrycode))
            {
                return existingdictionary[countrycode];
            }
            return ""; 
        }
    public static bool CheckCodeExists(Dictionary<int,string>existingdictionary,int countrycode)
        {
            if(existingdictionary.ContainsKey(countrycode))
            {
                return true;
            }
            else 
            return false;
        }
    public static Dictionary<int,string> UpdateDictionary(Dictionary<int,string> existingdictionary, int countrycode, string countryname)
        {
            if(existingdictionary.ContainsKey(countrycode))
            {
                existingdictionary[countrycode]=countryname;
            }
            return existingdictionary;
        }
    public static Dictionary<int,string> RemoveCountryFromDictionary(Dictionary<int,string> existingdictionary,int countrycode)
        {
            if(existingdictionary.ContainsKey(countrycode))
            {
                existingdictionary.Remove(countrycode);
            }
            return existingdictionary;
        }
    public static string FindLongestCountryName(Dictionary<int,string> existingdictionary)
        {
            if(existingdictionary.Count==0)
            return "";
            string longest="";
            foreach(var v in existingdictionary)
            {
                if(v.Value.Length>longest.Length)
                    longest=v.Value;
            }
            return longest;
        }
    }        
}