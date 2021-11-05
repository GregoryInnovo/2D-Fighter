using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
	// tiempo que va a durar el power up
	public float timePowerUp;
	// velocidad actual
	public float velCurrent=2;
	//velocidad normal
	public float velNormal = 5;
	//velocidad power up
	public float velPowerUp = 8;
	//salto actual
	public float jumpCurrent;
	public float jumpNormal = 5;
	public float jumpPowerUp = 8;

	//public Salto saltoCode;

	public void Start()
	{
		//velCurrent = this.gameObject.GetComponent<Salto>().velMove;
	//	jumpCurrent = 
	//	saltoCode.velMove = velCurrent;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("UpVel"))
		{
			StartCoroutine("PowerUpVel");
			Destroy(col.gameObject);
		}
		if (col.gameObject.CompareTag("UpJump"))
		{
			StartCoroutine("PowerUpJump");
			Destroy(col.gameObject);
		}
	}

	IEnumerator PowerUpVel()
	{
		Debug.Log("deberia funcionar");
		this.gameObject.GetComponent<Salto>().velMove = velPowerUp;
		yield return new WaitForSeconds(timePowerUp);
		this.gameObject.GetComponent<Salto>().velMove = velNormal;
	}

	IEnumerator PowerUpJump()
	{
		this.gameObject.GetComponent<Salto>().velJump = jumpPowerUp;		
		yield return new WaitForSeconds(timePowerUp);
		this.gameObject.GetComponent<Salto>().velJump = jumpNormal;
	}
}
