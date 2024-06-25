using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHieght : MonoBehaviour
{
	private float qSuffix;

	void Awake()
	{
		qSuffix = GetQuality();
		ManageQuality();
	}

	private float GetQuality()
	{
		float screenH = Screen.height/Screen.width;
		Debug.Log(screenH / 1.66f);
		return (screenH/1.66f);
	}


	private void ManageQuality()
	{
		transform.localScale = new Vector3(transform.localScale.x/ qSuffix, transform.localScale.y, 0);
	}
}
