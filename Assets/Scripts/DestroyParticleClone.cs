using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleClone : MonoBehaviour
{
	void Start ()
	{
		StartCoroutine(DestroyClone());
	}

	IEnumerator DestroyClone()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
