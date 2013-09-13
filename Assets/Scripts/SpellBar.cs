using UnityEngine;
using System.Collections;

public class SpellBar{
	
	public Spell[] currentSpells;
	public int selectedSpell;

	public SpellBar()
	{
		currentSpells = new Spell[3];
		selectedSpell = 0;
		
	}
	
	public bool activate()
	{
		if(currentSpells[selectedSpell] != null)
		{
			currentSpells[selectedSpell].activate();
			currentSpells[selectedSpell] = null;
			cycleSelectedSpell();
			return true;
		}
		else
			return false;
	}
	
	public void cycleSelectedSpell()
	{
		selectedSpell++;
		if(selectedSpell > 2)
		{
			selectedSpell = 0;
		}
	}
}
