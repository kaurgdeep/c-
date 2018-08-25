using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================

            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            var artist = Artists.Where(q=>q.Hometown == "Mount Vernon").ToList();  
            System.Console.WriteLine(artist[0].ArtistName + " " +  artist[0].Age);
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================
            var artist2 = Artists.OrderBy(str => str.Age).ToList();
            System.Console.WriteLine(artist2[0].ArtistName);
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            var artist3 = Artists.Where(q => q.RealName.Contains("William")).ToList();

            foreach(var art in artist3) {
            System.Console.WriteLine(art.RealName);
            }
            
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            var group = Groups.Where(q => q.GroupName.Length <= 8);

            foreach(var member in group) {
                System.Console.WriteLine(member.GroupName);
            }
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            var artist4 = Artists.OrderByDescending(q => q.Age).ToList();
            System.Console.WriteLine(artist4[0].ArtistName +", "+ artist4[1].ArtistName  +","+ artist4[2].ArtistName);
            

            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================

            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
            // var artist6 = Groups.Join(Artists, group2=>group2.Id, artist8=>artist8.GroupId, (group2, artist8) => {group2.Members = artist8; return artist});
            // not working
        }
    }
}
