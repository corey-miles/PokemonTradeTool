namespace PokemonTradeToolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string path1, path2;
            PokemonSaveFile save1, save2;

            // ASSUMPTION - Path1 is Yellow, Path2 is Blue

            /*
            Console.WriteLine("Please enter file path of save1:");
            path1 = GetPath();

            Console.WriteLine("Please enter file path of save2:");
            path2 = GetPath();
            */

            path1 = "C:\\Users\\corey\\OneDrive\\Desktop\\mGBA\\Gen1\\PokemonYellow.sav";
            path2 = "C:\\Users\\corey\\OneDrive\\Desktop\\mGBA\\Gen1\\PokemonBlue.sav";
        

            save1 = new PokemonYellowSaveFile(path1);
            save2 = new PokemonRedBlueSaveFile(path2);

            PrintDuelParty(save1, save2);

            int t1, t2;
            char confirm;

            Console.WriteLine();

            Console.Write("Enter column 1 index to trade: ");
            t1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter column 2 index to trade: ");
            t2 = Convert.ToInt32(Console.ReadLine());
            Console.Write(
                $"Trade {save1.GetPokemonAtIndex(t1).GetSpecies()} for {save2.GetPokemonAtIndex(t2).GetSpecies()} (Y/N):"
            );
            confirm = Console.ReadKey().KeyChar;
        }

        static string GetPath()
        {
            string? path = Console.ReadLine();
            while (path == null)
            {
                Console.WriteLine("Invalid input...");
                path = Console.ReadLine();
            }
            return path;
        }

        static void PrintDuelParty(PokemonSaveFile s1, PokemonSaveFile s2)
        {
            bool s1_high = s1.GetPartySize() >= s2.GetPartySize();
            for (int i = 0; s1_high ? i < s1.GetPartySize() : i < s2.GetPartySize(); i++)
            {
                PrintDuelPartyIndice(s1, s2, i);
            }
        }

        static void PrintDuelPartyIndice(PokemonSaveFile s1, PokemonSaveFile s2, int index)
        {
            if (index < s1.GetPartySize() && index < s2.GetPartySize())
            {
                Console.WriteLine(
                    $"{s1.GetPokemonAtIndex(index).GetSpecies(), -20} {s2.GetPokemonAtIndex(index).GetSpecies(), -20}"
                );
            }
            else if (index < s1.GetPartySize() && !(index < s2.GetPartySize()))
            {
                Console.WriteLine(
                    s1.GetPokemonAtIndex(index).GetSpecies()
                );
            }
            else
            {
                Console.WriteLine(
                    $"{"", -20} {s2.GetPokemonAtIndex(index).GetSpecies(), -20}"
                );
            }
        }
    
        static void 
    }
}