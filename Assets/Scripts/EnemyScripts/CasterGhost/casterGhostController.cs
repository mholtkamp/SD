using UnityEngine;
using System.Collections;

public class casterGhostController : MonoBehaviour {
	
	Stats stats;
	public int state;
	BasicMovementScript bms;
	const float range = 3f;
	GameObject chara;
	Vector3 toChar;
	bool isAttacking;
	float timer;
	const float castTime = 1.5f;

	
	void Start () 
	{
		stats = GetComponent (typeof(Stats)) as Stats;
		bms = GetComponent (typeof(BasicMovementScript)) as BasicMovementScript;
		state = 0;
		toChar = new Vector3();
		chara = GameObject.Find ("Character") as GameObject;
		timer = 0f;
	}
	
	void Update () 
	{
		if(!stats.initialized)
			initStats ();
		if(stats.health <= 0)
			Destroy (gameObject);
		
		//Compute vector to character.
		toChar = chara.transform.position - transform.position;
		
		if(state == 0)
		{
			if(toChar.magnitude < range)
			{
				bms.disable ();
				float spellRoll = Random.Range(0f,1f);
				if(spellRoll < 0.2f)
					state = 1;
				else
					state = 2;
			}
			
			
		}
		else if(state == 1)
		{
			if(!isAttacking)
			{
				isAttacking = true;
				animation.wrapMode = WrapMode.Loop;
				animation.Play ("Attack1");
				timer = castTime;
				(Instantiate (Resources.Load ("inferno")) as GameObject).transform.position = new Vector3(chara.transform.position.x,0.1f,chara.transform.position.z);
			}
			else
			{
				timer -= Time.deltaTime;
				if( timer <= 0f)	
				{
					isAttacking = false;
					state = 0;
					bms.enable ();
				}
			}
		}
		else if(state == 2)
		{
			if(!isAttacking)
			{
				(Instantiate (Resources.Load("FireBall")) as GameObject).transform.position = transform.position;
				isAttacking = true;
				bms.disable ();
				animation.wrapMode = WrapMode.Once;
				animation.Play ("Attack2");
			}
			else
			{
				if(!animation.IsPlaying("Attack2"))
				{
					isAttacking = false;
					state = 0;
					bms.enable ();
				}
			}
		}
			
	
	}
	
	private void initStats()
	{
		stats.maxHealth = 70f;
		stats.health = stats.maxHealth;
		stats.attackSpeed = 0;
		stats.damage = 10;
		stats.speed = 120;
		stats.wisdom = 30;
		stats.initialized = true;
	}
}
