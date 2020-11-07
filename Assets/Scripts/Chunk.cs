﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
	public Vector2 gravityDirection;
	[Space]
	public GameObject blockObject;
	[Space]
	[SerializeField] GameObject spikePrefab;


	public void Generate()
	{
		blockObject.GetComponent<Block>().Generate();
		Vector2 spikePos = transform.position;
		spikePos.y += GetBlockHeight() / 2f + 1.42f / 2f;
		float minObjectX = transform.position.x - GetBlockLength() / 2f + GetBlockHeight() * 3f;
		float maxObjectX = transform.position.x + GetBlockLength() / 2f - GetBlockHeight() * 2.4f;
		float step = 1.65f;
		int spikesTogether = 0;
		while (maxObjectX >= minObjectX)
		{
			int randInt = Random.Range(0, 2);
			if (randInt == 0 && spikesTogether < 5) // 50%
			{
				spikesTogether++;
				minObjectX += step;
				minObjectX = Random.Range(minObjectX, maxObjectX);
			}
			spikesTogether = 0;
			spikePos.x = minObjectX;
			minObjectX += step;
			Instantiate(spikePrefab, spikePos, Quaternion.identity, transform);
		}
	}

	public float GetBlockLength()
	{
		return blockObject.GetComponent<Block>().convertedLength;
	}
	
	public float GetBlockHeight()
	{
		return blockObject.GetComponent<Block>().convertedHeight;
	}
}
