using SpecificationPattern.Repositories;
using SpecificationPattern.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecificationPattern
{
    class MovieClieint
    {


        static void Main(string[] args)
        {

            MovieListViewModel model = new MovieListViewModel();
            model.ForKidsOnly = true;
            model.LoadMovies();
            Display(model);            
        }





        static void Display(MovieListViewModel model)
        {
            List<string> columns = new List<string>() { "Name", "Realease Date", "Genre", "MPAA", "Rating" };

            StringBuilder columnBuilder = new StringBuilder();
            columnBuilder.Append("|");
            columns.ForEach(col =>
            {

                int left = (30 - col.Length) / 2;
                int right = ((30 - col.Length) / 2);

                columnBuilder.Append('-', left);
                columnBuilder.Append(col);

                columnBuilder.Append('-', right);
                columnBuilder.Append("|");
            });

            //Console.WriteLine($"------Name------ | ------Release Date------ | ------Genre------ | ------MPAA------ | ------Rating------ |");
            Console.WriteLine(columnBuilder.ToString());

            StringBuilder rowBuilder = new StringBuilder();
            rowBuilder.Append("| ");
            foreach (var item in model.Movies)
            {
                rowBuilder.AddTableData(item.Title);
                rowBuilder.AddTableData(item.RealeaseDate.ToShortDateString());

                rowBuilder.AddTableData(item.Genre);
                rowBuilder.AddTableData(item.MpaaRating.ToString());
                rowBuilder.AddTableData(string.Format("{0:N2}", item.Rating));
                rowBuilder.Append("\n");
            }
            Console.WriteLine(rowBuilder.ToString());
            Console.WriteLine($"{model.Movies.Count} movies are displayed.");
        }

    }

    
}
