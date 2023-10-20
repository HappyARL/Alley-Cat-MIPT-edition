using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_logic : MonoBehaviour
{
    private float horizontal;
    public float speed = 50f;
	public int Respawn = 0;
    public bool OnRightSide = true;

    private GameObject currentStopStartPoint;
    private GameObject currentPlayerBorder;
    private GameObject currentPlayer;

    [SerializeField] private BoxCollider2D dogCollider;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (OnRightSide) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OnRightSide) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

		if (currentPlayerBorder != null) {
			StartCoroutine(DisableCollision());
		}

		if (currentStopStartPoint != null)
        {
            ChangeDirection();
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerBorder"))
        {
            currentPlayerBorder = collision.gameObject;
        }

		if (collision.gameObject.CompareTag("StopStartPoint"))
        {
            currentStopStartPoint = collision.gameObject;
        }
    }

	private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBorder"))
        {
            currentPlayerBorder = null;
        }

 		if (collision.gameObject.CompareTag("StopStartPoint"))
        {
            currentStopStartPoint = null;
        }
    }

    private void FixedUpdate()
    {
        if (OnRightSide) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentPlayerBorder.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(dogCollider, platformCollider);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreCollision(dogCollider, platformCollider, false);
    }

	private void ChangeDirection()
    {
        OnRightSide = !OnRightSide;
    }

}
