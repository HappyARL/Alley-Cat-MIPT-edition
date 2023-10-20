using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
	public float speed;
	public bool OnRight;
	Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
 		rb = GetComponent<Rigidbody2D>();
		if (OnRight) {
			rb.velocity = transform.right * speed;
		} else {
			rb.velocity = transform.right * -speed;
		}
		Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
    }

	private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);      
        }
    }

}
