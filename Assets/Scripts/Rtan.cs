using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    public float direction = 2f;
    SpriteRenderer renderer;
    

    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 60 프레임 수를 맞추어도 되지만 그냥 Time.deltaTime을 곱해도 된다.;
        renderer = GetComponent<SpriteRenderer>();
        //Debug.Log("안녕");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX;
        }

        if(transform.position.x > 2.6f)
        {
            renderer.flipX = true;
            direction *= -1f;
        }
        if (transform.position.x < -2.6f)
        {
            renderer.flipX = false;
            direction *= -1f;
        }

        transform.position += Vector3.right * direction * Time.deltaTime;
    }
}
