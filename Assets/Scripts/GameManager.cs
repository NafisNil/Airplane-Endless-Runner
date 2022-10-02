using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    [SerializeField] GameObject playbutton;
    [SerializeField] GameObject gameOver;
    [SerializeField] Text scoreText;
    public Player player;
    public InterstitialAd ins;
    public BannerAds banner;
    //[SerializeField] GameObject playerobj;
    [SerializeField] int lives;
    [SerializeField] Slider liveSlider;
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        liveSlider.value = lives;
        liveSlider.minValue = 0;
        banner.LoadBanner();
        banner.ShowBannerAd();
    }

    public void Play()
    {
        Time.timeScale = 1f;
        ins.LoadAd();
        ins.ShowAd();
        score = 0;
        scoreText.text = score.ToString();

        playbutton.SetActive(false);
        gameOver.SetActive(false);
        //playerobj.position.y = 0f;
       // playerobj.transform.position = new Vector3(0f,0f,0f);
     
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
            Destroy(pipes[i].gameObject);

        Enemy[] enemies = FindObjectsOfType<Enemy>();
        for (int i = 0; i < enemies.Length; i++)
            Destroy(enemies[i].gameObject);

        lives = 5;

    }

    public void LiverIncrease()
    {
        lives++;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }


    public void getbonus()
    {
        score += 2;
        scoreText.text = score.ToString();
    }

    public void CrashPlane()
    {
        score += 2;
        lives--;
        liveSlider.value = lives;
        if (lives < 1)
            GameOver();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playbutton.SetActive(true);
        Pause();

    }
}
