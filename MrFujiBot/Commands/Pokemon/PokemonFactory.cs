using System.Data;
using System.Globalization;
using MrFujiBot;

internal class PokemonFactory
{
    private FujiDatabase database;

    public PokemonFactory(FujiDatabase database)
    {
        this.database = database;
    }

    public Pokemon getPokemon(string name)
    {
        Pokemon pokemon = new Pokemon();

        // sqlite > PRAGMA table_info(pokemon_v2_pokemon);
        // 0 | id | integer | 1 || 1
        // 1 | order | integer | 0 || 0
        // 2 | height | integer | 1 || 0
        // 3 | weight | integer | 1 || 0
        // 4 | base_experience | integer | 1 || 0
        // 5 | is_default | bool | 1 || 0
        // 6 | pokemon_species_id | integer | 0 || 0
        // 7 | name | varchar(100) | 1 || 0
        string query = "select id " +
                       "from pokemon_v2_pokemon " +
                       "where name = '" + name + "';";
        database.Query(query, delegate(IDataReader reader) {
            pokemon.Pokemon_id = reader.GetInt32(0);
        });

        if (0 != pokemon.Pokemon_id)
        {
            TextInfo cultureInfo = new CultureInfo("en-US", false).TextInfo;
            pokemon.Name = cultureInfo.ToTitleCase(name);

            // sqlite > pragma table_info(pokemon_v2_pokemontype);
            // 0 | id | integer | 1 || 1
            // 1 | slot | integer | 1 || 0
            // 2 | pokemon_id | integer | 0 || 0
            // 3 | type_id | integer | 0 || 0
            query = "select slot, type_id " +
                    "from pokemon_v2_pokemontype " +
                    "where pokemon_id = " + pokemon.Pokemon_id + ";";
            database.Query(query, delegate (IDataReader reader) {
                string typeName = Util.typeIdToName(reader.GetInt32(1));
                int slot = reader.GetInt32(0);
                if (1 == slot)
                {
                    pokemon.Type1 = typeName;
                }
                else if (2 == slot)
                {
                    pokemon.Type2 = typeName;
                }
            });

            // sqlite > PRAGMA table_info(pokemon_v2_pokemonstat);
            // 0 | id | integer | 1 || 1
            // 1 | base_stat | integer | 1 || 0
            // 2 | effort | integer | 1 || 0
            // 3 | pokemon_id | integer | 0 || 0
            // 4 | stat_id | integer | 0 || 0
            query = "select base_stat, stat_id " +
                    "from pokemon_v2_pokemonstat " +
                    "where pokemon_id = " + pokemon.Pokemon_id + ";";
            database.Query(query, delegate (IDataReader reader) {
                switch (reader.GetInt32(1))
                {
                    case 1:
                        pokemon.Hp = reader.GetInt32(0);
                        break;
                    case 2:
                        pokemon.Attack = reader.GetInt32(0);
                        break;
                    case 3:
                        pokemon.Defense = reader.GetInt32(0);
                        break;
                    case 4:
                        pokemon.SpAttack = reader.GetInt32(0);
                        break;
                    case 5:
                        pokemon.SpDefense = reader.GetInt32(0);
                        break;
                    case 6:
                        pokemon.Speed = reader.GetInt32(0);
                        break;
                }
            });

            // sqlite > pragma table_info(pokemon_v2_pokemonability);
            // 0 | id | integer | 1 || 1
            // 1 | is_hidden | bool | 1 || 0
            // 2 | slot | integer | 1 || 0
            // 3 | ability_id | integer | 0 || 0
            // 4 | pokemon_id | integer | 0 || 0
            query = "select is_hidden, slot, ability_id " +
                    "from pokemon_v2_pokemonability " +
                    "where pokemon_id = " + pokemon.Pokemon_id + ";";
            database.Query(query, delegate (IDataReader reader) {
                bool isHidden = ( 1 == reader.GetInt32(0) );
                int slot = reader.GetInt32(1);
                int ability_id = reader.GetInt32(2);

                // sqlite > pragma table_info(pokemon_v2_ability);
                // 0 | id | integer | 1 || 1
                // 1 | is_main_series | bool | 1 || 0
                // 2 | generation_id | integer | 0 || 0
                // 3 | name | varchar(100) | 1 || 0
                string query2 = "select name " +
                                "from pokemon_v2_ability " +
                                "where id = " + ability_id;
                database.Query(query2, delegate (IDataReader reader2) {
                    string ability = "";
                    if( 1 == slot )
                    {
                        ability = reader2.GetString(0);
                        ability = ability.Replace("-", " ");
                        pokemon.Ability1 = cultureInfo.ToTitleCase(ability);
                        pokemon.Ability1IsHidden = isHidden;
                    }
                    else if (2 == slot)
                    {
                        ability = reader2.GetString(0);
                        ability = ability.Replace("-", " ");
                        pokemon.Ability2 = cultureInfo.ToTitleCase(ability);
                        pokemon.Ability2IsHidden = isHidden;
                    }
                    else if (3 == slot)
                    {
                        ability = reader2.GetString(0);
                        ability = ability.Replace("-", " ");
                        pokemon.Ability3 = cultureInfo.ToTitleCase(ability);
                        pokemon.Ability3IsHidden = isHidden;
                    }
                });
            });
        }
        else
        {
            pokemon = null;   
        }

        return pokemon;
    }
}