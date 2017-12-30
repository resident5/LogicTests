using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public MenuWheel wheel;

	void Start ()
	{
		wheel = FindObjectOfType<MenuWheel> ();
	}

	void Update ()
	{
		Inputs ();
	}

	void Inputs ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			wheel.TurnUp ();

		}

		if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			wheel.TurnDown ();
		}
			
	}

}
