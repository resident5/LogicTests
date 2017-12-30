using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWheel : MonoBehaviour
{
	public int buttonsNum;
	public int angle;

	public float lerpAngle;

	public bool turnUp;
	public bool turnDown;
	public float turnSpeed;

	Vector3 curAngle;
	Vector3 nextAngle;

	void Start ()
	{
		CalculateAngle ();

		curAngle = new Vector3 (0, 0, 0);
		nextAngle = new Vector3 (0, 0, curAngle.z + angle);
	}

	void FixedUpdate ()
	{
		if (turnUp)
		{
			transform.eulerAngles = Vector3.Lerp (transform.eulerAngles, nextAngle, turnSpeed);

			if (Vector3.Distance (transform.eulerAngles, nextAngle) <= 0.1)
			{
				Debug.Log ("Euler: " +  transform.eulerAngles);
				Debug.Log ("Next Angle" + nextAngle);

				transform.eulerAngles = nextAngle;

				curAngle = nextAngle;

				nextAngle.z = curAngle.z + angle;

				turnUp = false;
			}
		}
		
	}

	public void TurnUp ()
	{
		turnUp = true;
	}

	public void TurnDown ()
	{
		turnDown = true;
	}

	void CalculateAngle ()
	{
		buttonsNum = transform.childCount;
		angle = 360 / buttonsNum;
	}

}