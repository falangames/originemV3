using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject fullScreenStar;
    public GameObject panel;
    public GameObject sparkle;
    public GameObject StarDestroyerPanel;
    public GameObject SparkleParticle;

    public Camera cam;

    ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        Spawn();
        if (panel.activeSelf == true)
        {
            sparkle.SetActive(false);
            StartCoroutine(FadeTo(1f, 5.5f));
        }
    }

    int i = 0;
    void Spawn()
    {
        StartCoroutine(FadeTo(1f, 5.5f));
        if (i == 200)
        {
            fullScreenStar.transform.DOScale(50, 0.9f).OnComplete(
                () => fullScreenStar.transform.DOMove(new Vector3(1.27f, 3.18f, 5000), 0.1f).OnComplete(
                () => cam.transform.DOMove(new Vector3(1.12f, 3.88f, 3.8f), 0.7f).OnComplete(
                () => panel.SetActive(true))));
        }
        else
        {
            i += 1;
            objectPooler.SpawnFromPool("Star", new Vector3(Random.Range(transform.position.x - 600, transform.position.x + 600), Random.Range(transform.position.y - 600, transform.position.y + 600), Random.Range(transform.position.z - 600, transform.position.z + 600)), Quaternion.identity);
        }
        SparkleParticle.transform.DOScale(0.9f, 0.9f);
    }
    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = StarDestroyerPanel.GetComponent<Image>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            StarDestroyerPanel.GetComponent<Image>().color = newColor;
            yield return null;
        }
    }


    public void OnClick_PlayButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
