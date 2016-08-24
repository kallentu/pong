using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float speed = 30;

	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 30;
	}

    float hitFactor (Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        //Returns the relative position of ball to the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        //col gives us info about its game objece, its position, and its collider info
        //So we check which collider it is
        if (col.gameObject.name == "Racket Left")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); //Every parameter needed in the function
            //then we need to make a new direction
            Vector2 dir = new Vector2(1, y).normalized; //is normalized to make length = 1 and we use 1 for x coordinate because its the left paddle and we want it to move right
            //afterwards we finally change the direction of the ball
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "Racket Right")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); //Every parameter needed in the function
            //then we need to make a new direction
            Vector2 dir = new Vector2(-1, y).normalized; //is normalized to make length = 1 and we use 1 for x coordinate because its the left paddle and we want it to move right
            //afterwards we finally change the direction of the ball
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            Debug.Log("Changed direction to" + dir);
        }
    }
}
