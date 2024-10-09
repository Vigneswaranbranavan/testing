namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            int option;
            var MovieManager = new MovieManager();
            MovieManager.createTable();

            while (check)
            {
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. View All Movies");
                Console.WriteLine("3. Update Movie");
                Console.WriteLine("4. Delete a Movie");
                Console.WriteLine("5. Exit");

                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddMovie(MovieManager);
                        break;
                    case 5:
                        Console.WriteLine("Exit");
                        check = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }

            void AddMovie(MovieManager movieManager)
            {
                Console.Write("1. Enter Title: ");
                string title = Console.ReadLine();
                string capitalizedTitle = char.ToUpper(title[0]) + title.Substring(1);

                Console.Write("2. Enter Director: ");
                string director = Console.ReadLine();

                decimal rentalPrice = GetValidRentalPrice();

                var movie = new Movie
                {
                    Title = capitalizedTitle,
                    Director = director,
                    RentalPrice = rentalPrice
                };

                movieManager.AddMovie(movie);
            }
            decimal GetValidRentalPrice()
            {
                decimal rentalPrice;

                Console.Write("3. Enter RentalPrice: ");
                rentalPrice = Convert.ToDecimal(Console.ReadLine());

                while (rentalPrice <= 0)
                {
                    Console.WriteLine("Rental Price must be a positive value...");
                    Console.Write("Re-enter RentalPrice: ");
                    rentalPrice = Convert.ToDecimal(Console.ReadLine());
                }

                return rentalPrice;
            }
        }
    }
}
     