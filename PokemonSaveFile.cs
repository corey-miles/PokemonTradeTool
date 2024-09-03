namespace PokemonTradeToolConsole
{
    internal abstract class PokemonSaveFile
    {
        protected abstract int Party_Size_Offset { get; }
        protected abstract int Party_Data_Base_Offset { get; }
        protected abstract int Pokemon_Data_Size { get; }

        protected abstract int Species_Offset { get; }
        protected abstract int Level_Offset { get; }
        protected abstract int EV_Offset { get; }
        protected abstract int IV_Offset { get; }

        private string path;
        private byte[] data;
        private PokemonData[] pokemonInParty;

        public PokemonSaveFile(string path)
        {
            this.path = path;
            data = File.ReadAllBytes(path);
            pokemonInParty = PopulatePokemonData();
        }

        private PokemonData[] PopulatePokemonData()
        {
            PokemonData[] temp = new PokemonData[data[Party_Size_Offset]];
            for (int i = 0; i < temp.Length; i++)
            {
                int origin_offset = Party_Data_Base_Offset + Pokemon_Data_Size * i;
                temp[i] = new PokemonData(
                    data[origin_offset + Species_Offset],
                    data[origin_offset + Level_Offset],
                    new ArraySegment<byte>(
                        data, origin_offset + IV_Offset, 2
                    ).ToArray(),
                    new ArraySegment<byte>(
                        data, origin_offset + EV_Offset, 10
                    ).ToArray()
                );
            }
            return temp;
        }
    
        public void PrintParty()
        {
            foreach(PokemonData pokemon in pokemonInParty)
            {
                Console.WriteLine($"Species: {pokemon.GetSpecies()} Level: {pokemon.GetLevel()}");
                Console.WriteLine($"HP: {pokemon.GetStats()[0]}, ATK: {pokemon.GetStats()[1]}, DEF: {pokemon.GetStats()[2]}, SPECIAL: {pokemon.GetStats()[3]}, SPEED: {pokemon.GetStats()[4]}");
                Console.WriteLine();
            }
        }

        public int GetPartySize()
        {
            return pokemonInParty.Length;
        }

        public PokemonData GetPokemonAtIndex(int index)
        {
            return pokemonInParty[index];
        }
    }
}
