using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 direction;
    SpriteRenderer spriteRenderer;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float strength = 5f;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject successPrefab;
    [SerializeField] GameObject deathPrefab;
    [SerializeField] AudioSource death, success, crash;
    int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
      
    }

    void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
            Instantiate(deathPrefab, new Vector3(this.transform.position.x, this.transform.position.y, -2), Quaternion.identity);
            death.Play();
        }
        else if (collision.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().increaseScore();
        }else if(collision.gameObject.tag == "Enemy")
        {
            FindObjectOfType<GameManager>().CrashPlane();
            Destroy(collision.gameObject);
            crash.Play();
        }else if(collision.gameObject.tag == "Love")
        {
            FindObjectOfType<GameManager>().LiverIncrease();
            Instantiate(successPrefab, new Vector3(this.transform.position.x, this.transform.position.y, -2), Quaternion.identity);
            Destroy(collision.gameObject);
            success.Play();
        }else if(collision.gameObject.tag == "Life")
        {
            FindObjectOfType<GameManager>().getbonus();
            Instantiate(successPrefab, new Vector3(this.transform.position.x, this.transform.position.y, -2), Quaternion.identity);
            Destroy(collision.gameObject);
            success.Play();
        }
    }
}
