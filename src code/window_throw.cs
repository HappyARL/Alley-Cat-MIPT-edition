using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class window_throw : MonoBehaviour
{
    public Transform windowPoint;
    public GameObject trash;
    float cooldown;
	float startTimeBetween; 
    // Start is called before the first frame update
    void Start()
    {
		startTimeBetween = Random.Range(1f, 5f); 
        cooldown = startTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown <= 0) {
			Instantiate(trash, windowPoint.position, windowPoint.rotation);
			startTimeBetween = Random.Range(2f, 5f); 
			cooldown = startTimeBetween;
		} else {
			cooldown -= Time.deltaTime;
		}
    }
}
