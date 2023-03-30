using TestCobbleStone.Models;

namespace TestCobbleStone.Services
{
    public class PokemonServices
    {
        private List<Pokemon> _pokemons;

        //Exclude Pokémon of Type: Ghost
        const string excludedType = "Ghost";

        //For Pokémon of Type: Steel, double their HP
        const string typeDoubledHp = "Steel"; const int incr = 2;

        //For Pokémon of Type: Fire, lower their Attack by 10%
        const string typeToLowerAttackPercent = "Fire"; const int AttackPercent = 10;

        //For Pokémon of Type: Bug & Flying, increase their Attack Speed by 10%
        const string type1 = "Bug"; const string type2 = "Flying"; const int AttackSpeedPercent = 10;

        //For Pokémon that start with the letter **G**, add +5 Defense for every letter in their name (excluding **G**)
        const char startLatter = 'G'; const int number = 5;
        public PokemonServices(List<Pokemon> pokemons)
        {
            _pokemons = pokemons;

            ExcludeLegendary();
            ExcludeByType(excludedType);
            DoubleHpByType(typeDoubledHp, incr);
            LowerAttackByType(typeToLowerAttackPercent, AttackPercent);
            IncreaseAttackSpeedByType(type1, type2, AttackSpeedPercent);
            IncreaseDefWithStartingLatter(startLatter, number);
        }

        //Exclude Legendary Pokémon
        private void ExcludeLegendary()
        {
            _pokemons = _pokemons.Where(p => !p.Legendary).ToList();
        }

        //Exclude Pokémon of Type: Ghost
        private void ExcludeByType(string exclude)
        {
            _pokemons = _pokemons.Where(p => !p.Equals(exclude)).ToList();
        }

        //For Pokémon of Type: Steel, double their HP
        private void DoubleHpByType(string type, int number)
        {
            foreach (var item in _pokemons)
            {
                if (item.Type2 == type)
                {
                    item.HP = item.HP * number;
                }
            }
        }

        //For Pokémon of Type: Fire, lower their Attack by 10%
        private void LowerAttackByType(string type, int percent)
        {
            foreach (var item in _pokemons)
            {
                if (item.Type1 == type)
                {
                    item.Attack = item.Attack - (item.Attack * percent) / 100;
                }
            }
        }

        //For Pokémon of Type: Bug & Flying, increase their Attack Speed by 10%
        private void IncreaseAttackSpeedByType(string type1, string type2, int percent)
        {
            foreach (var item in _pokemons)
            {
                if (item.Type1 == type1 && item.Type2 == type2)
                {
                    item.SpeedAtack = item.SpeedAtack + (item.SpeedAtack * percent) / 100;
                }
            }
        }

        //For Pokémon that start with the letter **G**, add +5 Defense for every letter in their name (excluding **G**)
        private void IncreaseDefWithStartingLatter(char letter, int number)
        {
            foreach (var item in _pokemons)
            {
                if (item.Name.StartsWith(letter))
                {
                    var counter = item.Name.Count(i => i == letter);
                    int lengthOfName = item.Name.Length;
                    int defIncrease = (lengthOfName - counter) * number;
                    item.Defense = item.Defense + defIncrease;
                }
            }
        }
        public List<Pokemon> Pokemons => _pokemons;

        //Pagination + search 
        public PagedList<Pokemon> GetPaged(int page, int pageSize, string name, int? hp, int? attack, int? defense)
        {
            var filteredData = _pokemons;
            if (!string.IsNullOrEmpty(name))
            {
                filteredData = filteredData.Where(f => f.Name.ToLower().Contains(name.ToLower())).ToList();
            }

            if (hp.HasValue)
            {
                filteredData = filteredData.Where(f => f.HP == hp.Value).ToList();
            }

            if (attack.HasValue)
            {
                filteredData = filteredData.Where(f => f.Attack == attack.Value).ToList();
            }

            if (defense.HasValue)
            {
                filteredData = filteredData.Where(f => f.Defense == defense.Value).ToList();
            }

            var pagedData = filteredData
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToList();
            var pagedList = new PagedList<Pokemon>
            {
                Page = page,
                Items = pagedData,
                TotalCount = filteredData.Count
            };
            return pagedList;
        }
    }
}
