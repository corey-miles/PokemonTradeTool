namespace PokemonTradeToolConsole
{
    internal class PokemonData
    {
        // STATS = [HP, ATTACK, DEFENSE, SPEED, SPECIAL]
        private string species;
        private int[] bases;
        private int level;
        private int[] ivs;
        private int[] evs;
        private int[] stats;

        // DICTIONARIES

        private static readonly Dictionary<byte, string> DictionarySpecies = new Dictionary<byte, string>
        {
            {0x1, "Rhydon"},
            {0x2, "Kangaskhan"},
            {0x3, "Nidoran♂"},
            {0x4, "Clefairy"},
            {0x5, "Spearow"},
            {0x6, "Voltorb"},
            {0x7, "Nidoking"},
            {0x8, "Slowbro"},
            {0x9, "Ivysaur"},
            {0x0A, "Exeggutor"},
            {0x0B, "Lickitung"},
            {0x0C, "Exeggcute"},
            {0x0D, "Grimer"},
            {0x0E, "Gengar"},
            {0x0F, "Nidoran♀"},
            {0x10, "Nidoqueen"},
            {0x11, "Cubone"},
            {0x12, "Rhyhorn"},
            {0x13, "Lapras"},
            {0x14, "Arcanine"},
            {0x15, "Mew"},
            {0x16, "Gyarados"},
            {0x17, "Shellder"},
            {0x18, "Tentacool"},
            {0x19, "Gastly"},
            {0x1A, "Scyther"},
            {0x1B, "Staryu"},
            {0x1C, "Blastoise"},
            {0x1D, "Pinsir"},
            {0x1E, "Tangela"},
            {0x1F, "MissingNo. (Scizor)"},
            {0x20, "MissingNo. (Shuckle)"},
            {0x21, "Growlithe"},
            {0x22, "Onix"},
            {0x23, "Fearow"},
            {0x24, "Pidgey"},
            {0x25, "Slowpoke"},
            {0x26, "Kadabra"},
            {0x27, "Graveler"},
            {0x28, "Chansey"},
            {0x29, "Machoke"},
            {0x2A, "Mr. Mime"},
            {0x2B, "Hitmonlee"},
            {0x2C, "Hitmonchan"},
            {0x2D, "Arbok"},
            {0x2E, "Parasect"},
            {0x2F, "Psyduck"},
            {0x30, "Drowzee"},
            {0x31, "Golem"},
            {0x32, "MissingNo. (Heracross)"},
            {0x33, "Magmar"},
            {0x34, "MissingNo. (Ho-Oh)"},
            {0x35, "Electabuzz"},
            {0x36, "Magneton"},
            {0x37, "Koffing"},
            {0x38, "MissingNo. (Sneasel)"},
            {0x39, "Mankey"},
            {0x3A, "Seel"},
            {0x3B, "Diglett"},
            {0x3C, "Tauros"},
            {0x3D, "MissingNo. (Teddiursa)"},
            {0x3E, "MissingNo. (Ursaring)"},
            {0x3F, "MissingNo. (Slugma)"},
            {0x40, "Farfetchd"},
            {0x41, "Venonat"},
            {0x42, "Dragonite"},
            {0x43, "MissingNo. (Magcargo)"},
            {0x44, "MissingNo. (Swinub)"},
            {0x45, "MissingNo. (Piloswine)"},
            {0x46, "Doduo"},
            {0x47, "Poliwag"},
            {0x48, "Jynx"},
            {0x49, "Moltres"},
            {0x4A, "Articuno"},
            {0x4B, "Zapdos"},
            {0x4C, "Ditto"},
            {0x4D, "Meowth"},
            {0x4E, "Krabby"},
            {0x4F, "MissingNo. (Corsola)"},
            {0x50, "MissingNo. (Remoraid)"},
            {0x51, "MissingNo. (Octillery)"},
            {0x52, "Vulpix"},
            {0x53, "Ninetales"},
            {0x54, "Pikachu"},
            {0x55, "Raichu"},
            {0x56, "MissingNo. (Delibird)"},
            {0x57, "MissingNo. (Mantine)"},
            {0x58, "Dratini"},
            {0x59, "Dragonair"},
            {0x5A, "Kabuto"},
            {0x5B, "Kabutops"},
            {0x5C, "Horsea"},
            {0x5D, "Seadra"},
            {0x5E, "MissingNo. (Skarmory)"},
            {0x5F, "MissingNo. (Houndour)"},
            {0x60, "Sandshrew"},
            {0x61, "Sandslash"},
            {0x62, "Omanyte"},
            {0x63, "Omastar"},
            {0x64, "Jigglypuff"},
            {0x65, "Wigglytuff"},
            {0x66, "Eevee"},
            {0x67, "Flareon"},
            {0x68, "Jolteon"},
            {0x69, "Vaporeon"},
            {0x6A, "Machop"},
            {0x6B, "Zubat"},
            {0x6C, "Ekans"},
            {0x6D, "Paras"},
            {0x6E, "Poliwhirl"},
            {0x6F, "Poliwrath"},
            {0x70, "Weedle"},
            {0x71, "Kakuna"},
            {0x72, "Beedrill"},
            {0x73, "MissingNo. (Houndoom)"},
            {0x74, "Dodrio"},
            {0x75, "Primeape"},
            {0x76, "Dugtrio"},
            {0x77, "Venomoth"},
            {0x78, "Dewgong"},
            {0x79, "MissingNo. (Kingdra)"},
            {0x7A, "MissingNo. (Phanpy)"},
            {0x7B, "Caterpie"},
            {0x7C, "Metapod"},
            {0x7D, "Butterfree"},
            {0x7E, "Machamp"},
            {0x7F, "MissingNo. (Donphan)"},
            {0x80, "Golduck"},
            {0x81, "Hypno"},
            {0x82, "Golbat"},
            {0x83, "Mewtwo"},
            {0x84, "Snorlax"},
            {0x85, "Magikarp"},
            {0x86, "MissingNo. (Porygon2)"},
            {0x87, "MissingNo. (Stantler)"},
            {0x88, "Muk"},
            {0x89, "MissingNo. (Smeargle)"},
            {0x8A, "Kingler"},
            {0x8B, "Cloyster"},
            {0x8C, "MissingNo. (Tyrogue)"},
            {0x8D, "Electrode"},
            {0x8E, "Clefable"},
            {0x8F, "Weezing"},
            {0x90, "Persian"},
            {0x91, "Marowak"},
            {0x92, "MissingNo. (Hitmontop)"},
            {0x93, "Haunter"},
            {0x94, "Abra"},
            {0x95, "Alakazam"},
            {0x96, "Pidgeotto"},
            {0x97, "Pidgeot"},
            {0x98, "Starmie"},
            {0x99, "Bulbasaur"},
            {0x9A, "Venusaur"},
            {0x9B, "Tentacruel"},
            {0x9C, "MissingNo. (Smoochum)"},
            {0x9D, "Goldeen"},
            {0x9E, "Seaking"},
            {0x9F, "MissingNo. (Elekid)"},
            {0xA0, "MissingNo. (Magby)"},
            {0xA1, "MissingNo. (Miltank)"},
            {0xA2, "MissingNo. (Blissey)"},
            {0xA3, "Ponyta"},
            {0xA4, "Rapidash"},
            {0xA5, "Rattata"},
            {0xA6, "Raticate"},
            {0xA7, "Nidorino"},
            {0xA8, "Nidorina"},
            {0xA9, "Geodude"},
            {0xAA, "Porygon"},
            {0xAB, "Aerodactyl"},
            {0xAC, "MissingNo. (Raikou)"},
            {0xAD, "Magnemite"},
            {0xAE, "MissingNo. (Entei)"},
            {0xAF, "MissingNo. (Suicune)"},
            {0xB0, "Charmander"},
            {0xB1, "Squirtle"},
            {0xB2, "Charmeleon"},
            {0xB3, "Wartortle"},
            {0xB4, "Charizard"},
            {0xB5, "MissingNo. (Larvitar)"},
            {0xB6, "MissingNo. Kabutops Fossil (Pupitar)"},
            {0xB7, "MissingNo. Aerodactyl Fossil (Tyranitar)"},
            {0xB8, "MissingNo. Ghost (Lugia)"},
            {0xB9, "Oddish"},
            {0xBA, "Gloom"},
            {0xBB, "Vileplume"},
            {0xBC, "Bellsprout"},
            {0xBD, "Weepinbell"},
            {0xBE, "Victreebel"}
        };

        private static readonly Dictionary<string, int[]> DictionaryBases = new Dictionary<string, int[]>
        {
            {"Bulbasaur", new int[] {45,49,49,45,65}},
            {"Ivysaur", new int[] {60,62,63,60,80}},
            {"Venusaur", new int[] {80,82,83,80,100}},
            {"Charmander", new int[] {39,52,43,65,50}},
            {"Charmeleon", new int[] {58,64,58,80,65}},
            {"Charizard", new int[] {78,84,78,100,85}},
            {"Squirtle", new int[] {44,48,65,43,50}},
            {"Wartortle", new int[] {59,63,80,58,65}},
            {"Blastoise", new int[] {79,83,100,78,85}},
            {"Caterpie", new int[] {45,30,35,45,20}},
            {"Metapod", new int[] {50,20,55,30,25}},
            {"Butterfree", new int[] {60,45,50,70,80}},
            {"Weedle", new int[] {40,35,30,50,20}},
            {"Kakuna", new int[] {45,25,50,35,25}},
            {"Beedrill", new int[] {65,80,40,75,45}},
            {"Pidgey", new int[] {40,45,40,56,35}},
            {"Pidgeotto", new int[] {63,60,55,71,50}},
            {"Pidgeot", new int[] {83,80,75,91,70}},
            {"Rattata", new int[] {30,56,35,72,25}},
            {"Raticate", new int[] {55,81,60,97,50}},
            {"Spearow", new int[] {40,60,30,70,31}},
            {"Fearow", new int[] {65,90,65,100,61}},
            {"Ekans", new int[] {35,60,44,55,40}},
            {"Arbok", new int[] {60,85,69,80,65}},
            {"Pikachu", new int[] {35,55,30,90,50}},
            {"Raichu", new int[] {60,90,55,100,90}},
            {"Sandshrew", new int[] {50,75,85,40,30}},
            {"Sandslash", new int[] {75,100,110,65,55}},
            {"Nidoran♀", new int[] {55,47,52,41,40}},
            {"Nidorina", new int[] {70,62,67,56,55}},
            {"Nidoqueen", new int[] {90,82,87,76,75}},
            {"Nidoran♂", new int[] {46,57,40,50,40}},
            {"Nidorino", new int[] {61,72,57,65,55}},
            {"Nidoking", new int[] {81,92,77,85,75}},
            {"Clefairy", new int[] {70,45,48,35,60}},
            {"Clefable", new int[] {95,70,73,60,85}},
            {"Vulpix", new int[] {38,41,40,65,65}},
            {"Ninetales", new int[] {73,76,75,100,100}},
            {"Jigglypuff", new int[] {115,45,20,20,25}},
            {"Wigglytuff", new int[] {140,70,45,45,50}},
            {"Zubat", new int[] {40,45,35,55,40}},
            {"Golbat", new int[] {75,80,70,90,75}},
            {"Oddish", new int[] {45,50,55,30,75}},
            {"Gloom", new int[] {60,65,70,40,85}},
            {"Vileplume", new int[] {75,80,85,50,100}},
            {"Paras", new int[] {35,70,55,25,55}},
            {"Parasect", new int[] {60,95,80,30,80}},
            {"Venonat", new int[] {60,55,50,45,40}},
            {"Venomoth", new int[] {70,65,60,90,90}},
            {"Diglett", new int[] {10,55,25,95,45}},
            {"Dugtrio", new int[] {35,80,50,120,70}},
            {"Meowth", new int[] {40,45,35,90,40}},
            {"Persian", new int[] {65,70,60,115,65}},
            {"Psyduck", new int[] {50,52,48,55,50}},
            {"Golduck", new int[] {80,82,78,85,80}},
            {"Mankey", new int[] {40,80,35,70,35}},
            {"Primeape", new int[] {65,105,60,95,60}},
            {"Growlithe", new int[] {55,70,45,60,50}},
            {"Arcanine", new int[] {90,110,80,95,80}},
            {"Poliwag", new int[] {40,50,40,90,40}},
            {"Poliwhirl", new int[] {65,65,65,90,50}},
            {"Poliwrath", new int[] {90,85,95,70,70}},
            {"Abra", new int[] {25,20,15,90,105}},
            {"Kadabra", new int[] {40,35,30,105,120}},
            {"Alakazam", new int[] {55,50,45,120,135}},
            {"Machop", new int[] {70,80,50,35,35}},
            {"Machoke", new int[] {80,100,70,45,50}},
            {"Machamp", new int[] {90,130,80,55,65}},
            {"Bellsprout", new int[] {50,75,35,40,70}},
            {"Weepinbell", new int[] {65,90,50,55,85}},
            {"Victreebel", new int[] {80,105,65,70,100}},
            {"Tentacool", new int[] {40,40,35,70,100}},
            {"Tentacruel", new int[] {80,70,65,100,120}},
            {"Geodude", new int[] {40,80,100,20,30}},
            {"Graveler", new int[] {55,95,115,35,45}},
            {"Golem", new int[] {80,110,130,45,55}},
            {"Ponyta", new int[] {50,85,55,90,65}},
            {"Rapidash", new int[] {65,100,70,105,80}},
            {"Slowpoke", new int[] {90,65,65,15,40}},
            {"Slowbro", new int[] {95,75,110,30,80}},
            {"Magnemite", new int[] {25,35,70,45,95}},
            {"Magneton", new int[] {50,60,95,70,120}},
            {"Farfetchd", new int[] {52,65,55,60,58}},
            {"Doduo", new int[] {35,85,45,75,35}},
            {"Dodrio", new int[] {60,110,70,100,60}},
            {"Seel", new int[] {65,45,55,45,70}},
            {"Dewgong", new int[] {90,70,80,70,95}},
            {"Grimer", new int[] {80,80,50,25,40}},
            {"Muk", new int[] {105,105,75,50,65}},
            {"Shellder", new int[] {30,65,100,40,45}},
            {"Cloyster", new int[] {50,95,180,70,85}},
            {"Gastly", new int[] {30,35,30,80,100}},
            {"Haunter", new int[] {45,50,45,95,115}},
            {"Gengar", new int[] {60,65,60,110,130}},
            {"Onix", new int[] {35,45,160,70,30}},
            {"Drowzee", new int[] {60,48,45,42,90}},
            {"Hypno", new int[] {85,73,70,67,115}},
            {"Krabby", new int[] {30,105,90,50,25}},
            {"Kingler", new int[] {55,130,115,75,50}},
            {"Voltorb", new int[] {40,30,50,100,55}},
            {"Electrode", new int[] {60,50,70,140,80}},
            {"Exeggcute", new int[] {60,40,80,40,60}},
            {"Exeggutor", new int[] {95,95,85,55,125}},
            {"Cubone", new int[] {50,50,95,35,40}},
            {"Marowak", new int[] {60,80,110,45,50}},
            {"Hitmonlee", new int[] {50,120,53,87,35}},
            {"Hitmonchan", new int[] {50,105,79,76,35}},
            {"Lickitung", new int[] {90,55,75,30,60}},
            {"Koffing", new int[] {40,65,95,35,60}},
            {"Weezing", new int[] {65,90,120,60,85}},
            {"Rhyhorn", new int[] {80,85,95,25,30}},
            {"Rhydon", new int[] {105,130,120,40,45}},
            {"Chansey", new int[] {250,5,5,50,105}},
            {"Tangela", new int[] {65,55,115,60,100}},
            {"Kangaskhan", new int[] {105,95,80,90,40}},
            {"Horsea", new int[] {30,40,70,60,70}},
            {"Seadra", new int[] {55,65,95,85,95}},
            {"Goldeen", new int[] {45,67,60,63,50}},
            {"Seaking", new int[] {80,92,65,68,80}},
            {"Staryu", new int[] {30,45,55,85,70}},
            {"Starmie", new int[] {60,75,85,115,100}},
            {"Mr. Mime", new int[] {40,45,65,90,100}},
            {"Scyther", new int[] {70,110,80,105,55}},
            {"Jynx", new int[] {65,50,35,95,95}},
            {"Electabuzz", new int[] {65,83,57,105,85}},
            {"Magmar", new int[] {65,95,57,93,85}},
            {"Pinsir", new int[] {65,125,100,85,55}},
            {"Tauros", new int[] {75,100,95,110,70}},
            {"Magikarp", new int[] {20,10,55,80,20}},
            {"Gyarados", new int[] {95,125,79,81,100}},
            {"Lapras", new int[] {130,85,80,60,95}},
            {"Ditto", new int[] {48,48,48,48,48}},
            {"Eevee", new int[] {55,55,50,55,65}},
            {"Vaporeon", new int[] {130,65,60,65,110}},
            {"Jolteon", new int[] {65,65,60,130,110}},
            {"Flareon", new int[] {65,130,60,65,110}},
            {"Porygon", new int[] {65,60,70,40,75}},
            {"Omanyte", new int[] {35,40,100,35,90}},
            {"Omastar", new int[] {70,60,125,55,115}},
            {"Kabuto", new int[] {30,80,90,55,45}},
            {"Kabutops", new int[] {60,115,105,80,70}},
            {"Aerodactyl", new int[] {80,105,65,130,60}},
            {"Snorlax", new int[] {160,110,65,30,65}},
            {"Articuno", new int[] {90,85,100,85,125}},
            {"Zapdos", new int[] {90,90,85,100,125}},
            {"Moltres", new int[] {90,100,90,90,125}},
            {"Dratini", new int[] {41,64,45,50,50}},
            {"Dragonair", new int[] {61,84,65,70,70}},
            {"Dragonite", new int[] {91,134,95,80,100}},
            {"Mewtwo", new int[] {106,110,90,130,154}},
            {"Mew", new int[] {100,100,100,100,100}}
        };

        // CONSTRUCTOR

        public PokemonData(byte species, byte level, byte[] ivs, byte[] evs)
        {
            if (ivs.Length != 2) throw new ArgumentException("IVS != 2");
            if (evs.Length != 10) throw new ArgumentException("EVS != 10");

            this.species = DictionarySpecies[species];
            bases = DictionaryBases[this.species];
            this.level = level;
            this.ivs = SetIvs(ivs);
            this.evs = SetEvs(evs);
            stats = CalculateStats();
        }

        // PRIVATE METHODS

        private int[] CalculateStats()
        {
            int[] temp = new int[5];
            temp[0] = Convert.ToInt32(Math.Floor((((bases[0] + ivs[0]) * 2 + Math.Ceiling(Math.Floor(Math.Sqrt(evs[0])) / 4)) * level) / 100.0) + level + 10);
            for (int i = 1; i < 5; i++)
                temp[i] = Convert.ToInt32(Math.Floor((((bases[i] + ivs[i]) * 2 + Math.Ceiling(Math.Floor(Math.Sqrt(evs[i])) / 4)) * level) / 100.0) + 5);
            return temp;
        }

        private int[] SetIvs(byte[] ivs)
        {
            if (ivs.Length != 2)
                throw new ArgumentException("ERROR - Input must be 2 values");

            int[] temp = [
                0,
                ((ivs[0] & 0xF0) >> 4),
                (ivs[0] & 0x0F),
                ((ivs[1] & 0xF0) >> 4),
                (ivs[1] & 0x0F)
            ];

            if (temp[1] % 2 == 1) temp[0] += 8;
            if (temp[2] % 2 == 1) temp[0] += 4;
            if (temp[3] % 2 == 1) temp[0] += 2;
            if (temp[4] % 2 == 1) temp[0] += 1;

            return temp;
        }

        private int[] SetEvs(byte[] evs)
        {
            if (evs.Length != 10)
                throw new ArgumentException("ERROR - Input must be 10 values");

            int[] temp = new int[5];
            for (int i = 0; i < 5; i++)
            {
                byte[] bytes = { evs[i * 2], evs[i * 2 + 1] };
                temp[i] = bytes[1] + (bytes[0] * 256);
            }
            return temp;
        }

        // GETTERS

        public string GetSpecies()
        {
            return species;
        }

        public int GetLevel()
        {
            return level;
        }

        public int[] GetBases()
        {
            return bases;
        }

        public int[] GetStats()
        {
            return stats;
        }

        public int[] GetIvs()
        {
            return ivs;
        }

        public int[] GetEvs()
        {
            return evs;
        }
    }
}
