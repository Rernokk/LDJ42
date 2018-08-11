using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
	[SerializeField]
	AnimationCurve spawnRate;

	[SerializeField]
	float WaveTimer = 5f, BaseSpawnRate = 1f;

	[SerializeField]
	GameObject spawn;

	float waveProgress = 0f;
	float secondsPast = 0f;

	// Use this for initialization
	void Start () {
		//			Instantiate(spawn, new Vector3(Random.Range(0, 14f), Random.Range(0, 14f), 0), Quaternion.identity);
	}

	// Update is called once per frame
	void Update()
	{
		if (waveProgress <= WaveTimer)
		{
			waveProgress += Time.deltaTime;
			if (secondsPast >= 1f)
			{
				print("New 'Wave', Rate: " + spawnRate.Evaluate(waveProgress / WaveTimer) * BaseSpawnRate);
				for (int i = 0; i < spawnRate.Evaluate(waveProgress / WaveTimer) * BaseSpawnRate; i++)
				{
					Instantiate(spawn, new Vector3(Random.Range(1, 13f), Random.Range(1, 13f), 0), Quaternion.identity);
				}
				secondsPast -= 1f;
			}
			else
			{
				secondsPast += Time.deltaTime;
			}
		}
	}
}
