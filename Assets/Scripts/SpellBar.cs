using UnityEngine;
using System.Collections;

public class SpellBar{
	
	public Spell[] currentSpells;
	public int selectedSpell;

	public SpellBar()
	{
		currentSpells = new Spell[3];
		selectedSpell = 0;
		
		//TESTING
		currentSpells[0] = new FrostWall();
		currentSpells[1] = new FrostWall();
		currentSpells[2] = new FrostWall();
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
		if((currentSpells[0] == null)&&(currentSpells[1] == null)&&(currentSpells[2] == null))
		{
		
		}
		else
		{
			selectedSpell++;
			if(selectedSpell > 2)
			{
				selectedSpell = 0;
			}
			if(currentSpells[selectedSpell] == null)
			{
				selectedSpell++;
				if(selectedSpell > 2)
				{
					selectedSpell = 0;
				}
				if(currentSpells[selectedSpell] == null)
				{
					selectedSpell++;
					if(selectedSpell > 2)
					{
						selectedSpell = 0;
					}
				}	
			}			
		}
		
	}
}
