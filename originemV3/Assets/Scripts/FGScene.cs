using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FGScene : MonoBehaviour
{
    public RawImage rw;
    private void Start()
    {
        StartCoroutine(FadeTo(0f, 4f));
        ModeSelect();
    }

    public void ModeSelect()
    {
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = rw.GetComponent<RawImage>().color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
            rw.GetComponent<RawImage>().color = newColor;
            yield return null;
        }
    }
}
