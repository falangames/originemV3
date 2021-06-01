using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickControl : MonoBehaviour
{
    public static StickControl Instance;
    Vector3 pos;

    public float speed = 5f;

    public GameObject InGamePanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;

    public GameObject[] stars;
    public int star = 6;

    public Text InGameScoreText;
    public Text GameOverScoreText;
    AdmobManager[] admobManager;

    public float score;

    public AudioSource audioSource;
    /*public GameObject copyWall1;
    public GameObject copyWall2;
    public GameObject copyWall3;
    public GameObject copyWall4;*/

    bool isAudioMuted = false;

    public GameObject SoundButton;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        admobManager = Object.FindObjectsOfType<AdmobManager>();
    }
    float currentRotation;
    public void OnClick_LeftButton()
    {
        currentRotation += 45f;
        transform.localRotation = Quaternion.Euler(0, 0, currentRotation);
    }
    public void OnClick_AudioOnOff()
    {
        audioSource.mute = !isAudioMuted;
        isAudioMuted = !isAudioMuted;
    }

    public void OnClick_RightButton()
    {
        currentRotation -= 45f;
        transform.localRotation = Quaternion.Euler(0, 0, currentRotation);
    }
    float lastScore;
    void Update()
    {
        InGameScoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
        if (star > 0)
        {
            GameOverScoreText.text = "Score: " + Mathf.RoundToInt(score).ToString();
            lastScore = score;
        }
        if (Input.GetKeyDown("a"))
        {
            OnClick_LeftButton();
        }
        if (Input.GetKeyDown("d"))
        {
            OnClick_RightButton();
        }
        Move();

        if (star == 0)
        {
            stars[2].SetActive(false);
            GameOverPanel.SetActive(true);
            InGamePanel.SetActive(false);
            Time.timeScale = 0;
        }
        else if (star == 2)
        {
            stars[1].SetActive(false);
        }
        else if (star == 4)
        {
            stars[0].SetActive(false);
        }
        if (isAudioMuted)
        {
            Color tmp = SoundButton.GetComponent<Image>().color;
            tmp.a = 0.5f;
            SoundButton.GetComponent<Image>().color = tmp;
        }
        else
        {
            Color tmp = SoundButton.GetComponent<Image>().color;
            tmp.a = 1f;
            SoundButton.GetComponent<Image>().color = tmp;
        }
    }
    private void Move()
    {
        pos = transform.position;
        pos.z += speed * Time.deltaTime;
        transform.position = pos;
        score = pos.z;
    }
    private GameObject[] wall1;
    private GameObject[] wall2;
    private GameObject[] wall3;
    private GameObject[] wall4;


    public void OnClick_ReviveButton()
    {
        admobManager[0].ShowRewardVideo();
    }



    public void Revive()
    {
        wall1 = GameObject.FindGameObjectsWithTag("1");
        wall2 = GameObject.FindGameObjectsWithTag("2");
        wall3 = GameObject.FindGameObjectsWithTag("3");
        wall4 = GameObject.FindGameObjectsWithTag("4");
        Time.timeScale = 1;
        pos.z = lastScore;
        GameOverPanel.SetActive(false);
        InGamePanel.SetActive(true);
        stars[0].SetActive(true);
        star += 2;
        score = lastScore;
        for (int i = 0; i < wall1.Length; i++)
        {
            //Instantiate(copyWall1, wall1[i].transform.position, Quaternion.identity);
            Destroy(wall1[i]);
        }
        for (int i = 0; i < wall2.Length; i++)
        {
            //Instantiate(copyWall2, wall2[i].transform.position, Quaternion.identity);
            Destroy(wall2[i]);
        }
        for (int i = 0; i < wall3.Length; i++)
        {
            //Instantiate(copyWall3, wall3[i].transform.position, Quaternion.identity);
            Destroy(wall3[i]);
        }
        for (int i = 0; i < wall4.Length; i++)
        {
            //Instantiate(copyWall4, wall4[i].transform.position, Quaternion.identity);
            Destroy(wall4[i]);
        }
    }
}
