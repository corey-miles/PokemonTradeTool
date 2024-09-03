namespace PokemonTradeToolConsole
{
    internal class PokemonRedBlueSaveFile(string path) : PokemonSaveFile(path)
    {
        protected override int Party_Size_Offset => 0x2F2C;
        protected override int Party_Data_Base_Offset => 0x2F34;
        protected override int Pokemon_Data_Size => 0x2C;

        protected override int Species_Offset => 0x0;
        protected override int Level_Offset => 0x21;
        protected override int EV_Offset => 0x11; // 10 bytes
        protected override int IV_Offset => 0x1B; // 2 bytes
        
        // protected override string Player_Name => throw new NotImplementedException();
    }
}