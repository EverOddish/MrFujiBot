using System;
namespace MrFujiBot
{
    public static class Util
    {
        public static string typeIdToName(int id)
        {
            string typeName = "";

            switch(id)
            {
                case 1:
                    typeName = "Normal";
                    break;
                case 2:
                    typeName = "Fighting";
                    break;
                case 3:
                    typeName = "Flying";
                    break;
                case 4:
                    typeName = "Poison";
                    break;
                case 5:
                    typeName = "Ground";
                    break;
                case 6:
                    typeName = "Rock";
                    break;
                case 7:
                    typeName = "Bug";
                    break;
                case 8:
                    typeName = "Ghost";
                    break;
                case 9:
                    typeName = "Steel";
                    break;
                case 10:
                    typeName = "Fire";
                    break;
                case 11:
                    typeName = "Water";
                    break;
                case 12:
                    typeName = "Grass";
                    break;
                case 13:
                    typeName = "Electric";
                    break;
                case 14:
                    typeName = "Psychic";
                    break;
                case 15:
                    typeName = "Ice";
                    break;
                case 16:
                    typeName = "Dragon";
                    break;
                case 17:
                    typeName = "Dark";
                    break;
                case 18:
                    typeName = "Fairy";
                    break;
            }

            return typeName;
        }
    }
}
