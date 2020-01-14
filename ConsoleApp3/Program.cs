using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { Title = "The Shawshank Redemption", Duration = "PT142M", 
                                    Actors = new string[] { "Tim Robbins", "Morgan Freeman", "Bob Gunton" }, 
                                    Favorites =new int[] { 66380, 7002, 9250, 34139 }, Watchlist =new int[] { 15291, 51417, 62289, 6146, 71389, 93707 } });
            movies.Add(new Movie() { Title = "The Godfather" , Duration= "PT175M" ,
                                    Actors=new string[] { "Marlon Brando", "Al Pacino", "James Caan" },
                                    Favorites=new int[] { 15291, 51417, 7001, 9250, 71389, 93707 }, Watchlist= new int[] { 62289, 66380, 34139, 6146 } });
            movies.Add(new Movie() { Title = "The Dark Knight", Duration = "PT152M", 
                                    Actors =new string[] { "Christian Bale", "Heath Ledger", "Aaron Eckhart" },
                                    Favorites =new int[] { 15291, 7001, 9250, 34139, 93707 }, Watchlist =new int[] { 51417, 62289, 6146, 71389 } });
            movies.Add(new Movie() { Title = "Pulp Fiction" , Duration= "PT154M", 
                                    Actors=new string[]{ "John Travolta", "Uma Thurman", "Samuel L. Jackson" },
                                    Favorites= new int[] { 15292, 51417, 62289, 66380, 71389, 93707 }, Watchlist = new int[] { 7001, 9250, 34139, 6146 } });
           
        List<User> users = new List<User>();
            users.Add(new User() {UserId= 15291 , Email= "Constantin_Kuhlman15@yahoo.com",  Friends=new int[] { 7001, 51417, 62289 } });
            users.Add(new User() { UserId = 62289, Email = "Marquise.Borer@hotmail.com", Friends = new int[] { 15291, 7001 } });

            string[] ss = MovieRating.MoviesAnalyzertopFavouriteMoviesAmongFriends(movies, users, 62289);
            foreach(string s in ss)
            {
                Console.WriteLine(s);
            }
    }
    }
    public class Movie
    {
        public string Title { get; set; }
        public string Duration { get; set; }
        public string[] Actors { get; set; }
        public int[] Ratings { get; set; }
        public int[] Favorites { get; set; }
        public int[] Watchlist { get; set; }

    }
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int[] Friends { get; set; }
    }
    // A List object of this TopList class will hold the movie name and rating.
    // After soting the List object we will get top 3 movies.
    class TopList : IComparable<TopList>
    {
        public int Rating { get; set; }
        public string Title { get; set; }

        public TopList(int r, string t)
        {
            Rating = r;
            Title = t;
        }
        public int CompareTo(TopList other)
        {
            if (this.Rating == other.Rating)
            {
                return this.Title.CompareTo(other.Title); // A to Z
            }
            return other.Rating.CompareTo(this.Rating); // Z to A
        }
    }
    class MovieRating
    {
        static List<TopList> topLists = new List<TopList>();
        public static string[] MoviesAnalyzertopFavouriteMoviesAmongFriends(List<Movie> movies, List<User> users, int Id)
        {
            int[] Friends = null;
            foreach (User user in users)
            {
                if (user.UserId == Id)
                    Friends = user.Friends;
            }
            int count = 0;
            foreach (Movie movie in movies)
            {
                foreach (int favorite in movie.Favorites)
                {
                    foreach (int friend in Friends)
                    {
                        if (friend == favorite)
                        {
                            count++;
                            break;
                        }
                    }

                }
                if(count != 0)
                {
                    topLists.Add(new TopList(count, movie.Title));
                }
                count = 0;
            }
            topLists.Sort();
            string[] TopThreeList = new string[3];
            int i = 0;
            if (topLists.Count == 0)
                TopThreeList = null;
            else
            {
                foreach (TopList topList in topLists)
                {
                    TopThreeList[i] = topList.Title;
                    i++;
                    if (i == 3)
                        break;
                }
            }
            
            return TopThreeList;
        }
    }
}