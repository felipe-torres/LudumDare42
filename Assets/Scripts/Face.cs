using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
{
	public Vector2[] FrameCoords;
	public float speed = 0.5f;
	private int currIndex;
	public MeshRenderer r;
    // Use this for initialization
    void Start()
    {
		InvokeRepeating("Animate", 0, speed);
    }

	public void Animate()
	{
		if(currIndex == FrameCoords.Length-1)
			currIndex = 0;
		else
			currIndex++;
		r.material.SetTextureOffset("_MainTex", FrameCoords[currIndex]);
	}
}
