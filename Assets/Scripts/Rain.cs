using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f;
    int score = 1;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        float posX = Random.Range(-2.4f, 2.41f);
        float posY = Random.Range(3.0f, 5.0f);

        transform.position = new Vector3(posX, posY, 0);

        RainSizeNScore();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.name == "Ground"  부딛힌 게임 오브젝트의 이름값
        if (collision.gameObject.CompareTag("Ground")/*collosion.gameObject.tag == "Ground"역시 똑같은 기능을 한다. (대소문자 주의)*/) 
        {
            //Destroy(collision.gameObject);//부딛힌 대상을 제거
            Destroy(this.gameObject); //자기 자신을 제거
        }

        if(collision.gameObject.tag == "Player")
        {
            GameManager.Instance.AddScore(score);
            Destroy(this.gameObject);
        }
    }

    void RainSizeNScore()
    {
        renderer = GetComponent<SpriteRenderer>();
        int type = Random.Range(1, 5);

        if (type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 255 / 255f, 1f);
        }
        else if (type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 255 / 255f, 1f);
        }
        else if (type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 255 / 255f, 1f);
        }
        else if (type == 4)
        {
            size = 0.8f;
            score = -5;
            renderer.color = new Color(255/ 255f, 100 / 255f, 100 / 255f, 1f);
            //숙제에 나와있는 값으로 색을 지정하니 연한 보라색이 되어 임의로 색을 지정합니다.
        }
        transform.localScale = new Vector3(size, size, 0);
    }
}
