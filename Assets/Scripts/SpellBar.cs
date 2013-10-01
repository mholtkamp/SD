using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBar{
	
	public Spell[] currentSpells;
	public int selectedSpell;
	public List<Spell> spellPool;

	public SpellBar()
	{
		currentSpells = new Spell[3];
		selectedSpell = 0;
		
		setUpSpellPool();
		drawSpells();
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
	
	private void setUpSpellPool()
	{
		spellPool = new List<Spell>();
		//Put starting Spell Pool here. 
		//Add variation for different classes once they get implemented.
		spellPool.Add (new FrostWall());
		spellPool.Add (new Speed());
		spellPool.Add (new FrostWall());
		spellPool.Add (new Speed());
		spellPool.Add (new FrostWall());
	}
	
	public void drawSpells()
	{
		for(int i = 0; i < 3; i++)
			currentSpells[i] = spellPool[Random.Range(0,spellPool.Count)];
	}
	
}
