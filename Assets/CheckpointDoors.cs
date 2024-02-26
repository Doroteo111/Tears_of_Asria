using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDoors : MonoBehaviour
{
	private Vector3 checkPointAsriaDoor;

	void Start()
	{
		checkPointAsriaDoor = transform.position;
	}

	public void SpawnAsria()
	{
		transform.position = checkPointAsriaDoor;
	}
}
