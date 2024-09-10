using System;

public class Orco : Heroe
{
	private int orcPower;

    public int OrcPower { get => orcPower; set => orcPower = value; }

    public Orco(string nombre, int hp, int xp, int damage, int orcPower ) : base ( nombre, hp, xp, damage) 
	{
		OrcPower = orcPower;
	}

    public override void Ataque(Heroe target)
    {
        throw new NotImplementedException();
    }

    public override void Curar(List<Heroe> heroes,Heroe plus)
    {
    }

    public override string ToString()
    {
        return $"Esta es la informacion de tu Villano:\nNombre: {Nombre} \nPuntos de vida: {Hp}hp \nPuntos de experiencia: {XP}xp \nPuntos de ataque: {Damage}Dp \nDaño extra de Orco: {OrcPower} \n";
    }

}
