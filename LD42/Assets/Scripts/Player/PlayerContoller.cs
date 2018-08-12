using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
	#region Variables
	public float playerSpeed;
	public float projectileSpeed;
	Rigidbody2D boxyBoi;
	float theFuckTimer = 0;
	public float attackSpeed;
	float theFuckLifeTime = 1f;
	//the fuck is the basic arcane attack (named by shannon)
	public GameObject theFuck;

	[SerializeField]
	float maxHealth = 100f;
	float currentHealth;

	Spellcast[] spellArray;
	#endregion

	#region Properties
	public float HealthPercent
	{
		get
		{
			return currentHealth / maxHealth;
		}
	}
	#endregion

	#region Private Methods
	// Use this for initialization yea yea yea 
	void Start()
	{
		boxyBoi = GetComponent<Rigidbody2D>();
		currentHealth = maxHealth;
		spellArray = new Spellcast[4];
		spellArray[0] = GetComponent<BlinkSpell>();
		spellArray[2] = GetComponent<TimewellSpell>();
		spellArray[3] = GetComponent<BlackholeSpell>();
	}

	// Update is called once per frame
	void Update()
	{

		theFuckTimer -= Time.deltaTime;

		FaceMouse();

		PlayerMove();

		if (theFuckTimer < 0)
		{
			PlayerTheFuck();
		}

		#region Spellcasting
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			spellArray[0].CastSpell();
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			spellArray[2].CastSpell();
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			spellArray[3].CastSpell();
		}

		for (int i = 0; i < 4; i++){
			if (spellArray[i] != null)
				spellArray[i].Tick();
		}
		#endregion
	}

	//have the player face the mouse
	void FaceMouse()
	{
		//get the mouse
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		//rotato tomato
		Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

		transform.up = direction;
	}

	//default player movment
	void PlayerMove()
	{
		//zero vector
		Vector2 direction = Vector2.zero;

		//move the player left
		if (Input.GetKey(KeyCode.A))
		{
			direction += Vector2.left;
		}
		//move the player right
		if (Input.GetKey(KeyCode.D))
		{
			direction += Vector2.right;
		}
		//move the player up
		if (Input.GetKey(KeyCode.W))
		{
			direction += Vector2.up;
		}
		//move the player down
		if (Input.GetKey(KeyCode.S))
		{
			direction += Vector2.down;
		}

		//boxyBois velocity
		boxyBoi.velocity = direction.normalized * playerSpeed;

	}

	void PlayerTheFuck()
	{
		if (Input.GetButton("Fire1"))
		{
			GameObject newTheFuck = Instantiate(theFuck, transform.position, transform.rotation);
			Destroy(newTheFuck, theFuckLifeTime);
			newTheFuck.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, projectileSpeed));
			theFuckTimer = attackSpeed;
		}
	}
	#endregion

	#region Public Methods
	public void Damage(float amnt)
	{
		currentHealth -= amnt;
	}
	#endregion
}
