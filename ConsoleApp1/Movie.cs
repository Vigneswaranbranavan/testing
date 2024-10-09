using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Movie
    {
        public int MovieId;
        public string Title;
        public string Director;
        public decimal RentalPrice;



        public override string ToString()
        {
            return $"ID: {MovieId}, Title: {Title}, Director: {Director}, RentalPrice: {RentalPrice}";
        }
    }
  
}
