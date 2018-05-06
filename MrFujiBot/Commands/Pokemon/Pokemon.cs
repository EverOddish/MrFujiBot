internal class Pokemon
{
    private string name;
    private string type1;
    private string type2;
    private int pokemon_id;
    private int hp;
    private int attack;
    private int defense;
    private int spAttack;
    private int spDefense;
    private int speed;
    private string ability1;
    private string ability2;
    private string ability3;
    private bool ability1IsHidden;
    private bool ability2IsHidden;
    private bool ability3IsHidden;

    public string Name { get => name; set => name = value; }
    public string Type1 { get => type1; set => type1 = value; }
    public string Type2 { get => type2; set => type2 = value; }
    public int Pokemon_id { get => pokemon_id; set => pokemon_id = value; }
    public int Hp { get => hp; set => hp = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Defense { get => defense; set => defense = value; }
    public int SpAttack { get => spAttack; set => spAttack = value; }
    public int SpDefense { get => spDefense; set => spDefense = value; }
    public int Speed { get => speed; set => speed = value; }
    public string Ability1 { get => ability1; set => ability1 = value; }
    public string Ability2 { get => ability2; set => ability2 = value; }
    public string Ability3 { get => ability3; set => ability3 = value; }
    public bool Ability1IsHidden { get => ability1IsHidden; set => ability1IsHidden = value; }
    public bool Ability2IsHidden { get => ability2IsHidden; set => ability2IsHidden = value; }
    public bool Ability3IsHidden { get => ability3IsHidden; set => ability3IsHidden = value; }
}