using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [SerializeField] private bool startVisible = false;

    private Renderer objectRenderer;

    protected float highestAlpha;

    protected float fadeDuration = 1f;

    protected float startingAlpha = 0f;
    protected float finalAlpha = 1f;
    protected float currentAlpha = 0f;
    protected float timer = 0f;

    protected bool fade = false;
    protected bool setActiveAfter = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        highestAlpha = objectRenderer.material.color.a * 255f;

        if(startVisible) 
        {
            startingAlpha = highestAlpha / 255f;
            finalAlpha = 0f;
        }
        else  
        {
            startingAlpha = 0f;
            finalAlpha = highestAlpha / 255f;
        }

        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material.color = new Color(objectRenderer.material.color.r, objectRenderer.material.color.g, objectRenderer.material.color.b, startingAlpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            FadeLerp();
        }
    }

    protected virtual void FadeLerp()
    {
        timer += Time.deltaTime;
        currentAlpha = Mathf.Lerp(startingAlpha, finalAlpha, timer / fadeDuration);
        objectRenderer.material.color = new Color(objectRenderer.material.color.r, objectRenderer.material.color.g, objectRenderer.material.color.b, currentAlpha);

        if (timer >= fadeDuration)
        {
            timer = 0f;
            fade = false;

            if (setActiveAfter)
            {
                gameObject.SetActive(false);
                setActiveAfter = false;
            }
        }
    }

    public void FadeIn(float duration)
    {
        fadeDuration = duration;
        startingAlpha = 0f;
        //finalAlpha = 1f;
        finalAlpha = highestAlpha / 255f;
        fade = true;
    }

    public void FadeOut(float duration, bool setActiveToFalseAfter)
    {
        fadeDuration = duration;
        //startingAlpha = 1f;
        startingAlpha = highestAlpha / 255f;
        finalAlpha = 0f;
        setActiveAfter = setActiveToFalseAfter;
        fade = true;
    }
}
