internal class PokemonCommand : Command, ITextHandler
{
    private PokemonFactory pokemonFactory;

    public PokemonCommand(PokemonFactory pokemonFactory)
    {
        this.pokemonFactory = pokemonFactory;
    }

    public bool HandleText(string sourceUser, string text, System.Action<string> outputFunction)
    {
        bool handled = false;

        if(text.StartsWith("!pokemon ", cmp))
        {
            string output = "";
            string name = text.Split(' ')[1];
            Pokemon pokemon = pokemonFactory.getPokemon(name);

            if (null != pokemon)
            {
                output += pokemon.Name + ": ";
                output += "[" + pokemon.Type1;

                if(null != pokemon.Type2)
                {
                    output += "/" + pokemon.Type2 + "] ";
                }
                else
                {
                    output += "] ";
                }

                output += "HP(" + pokemon.Hp + ") ";
                output += "Attack(" + pokemon.Attack + ") ";
                output += "Defense(" + pokemon.Defense + ") ";
                output += "Sp. Atk(" + pokemon.SpAttack + ") ";
                output += "Sp. Def(" + pokemon.SpDefense + ") ";
                output += "Speed(" + pokemon.Speed + ") ";

                output += "Abilities: " + pokemon.Ability1;
                if( pokemon.Ability1IsHidden )
                {
                    output += " (HA)";
                }

                if( null != pokemon.Ability2 )
                {
                    output += ", " + pokemon.Ability2;
                    if (pokemon.Ability2IsHidden)
                    {
                        output += " (HA)";
                    }
                }

                if (null != pokemon.Ability3)
                {
                    output += ", " + pokemon.Ability3;
                    if (pokemon.Ability3IsHidden)
                    {
                        output += " (HA)";
                    }
                }
            }
            else
            {
                output = "Could not find Pokemon '" + name + "'";
            }

            outputFunction(output);

            handled = true;
        }

        return handled;
    }
}