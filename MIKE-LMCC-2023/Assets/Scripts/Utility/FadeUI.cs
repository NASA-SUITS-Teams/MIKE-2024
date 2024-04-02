using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : Fade
{
    private MaskableGraphic imageToFade;

    // Start is called before the first frame update
    protected override void Start()
    {
        imageToFade = GetComponent<MaskableGraphic>();
        highestAlpha = GetComponent<MaskableGraphic>().color.a * 255f;
        imageToFade.color = new Color(imageToFade.color.r, imageToFade.color.g, imageToFade.color.b, startingAlpha);
    }

    protected override void FadeLerp()
    {
        timer += Time.deltaTime;
        currentAlpha = Mathf.Lerp(startingAlpha, finalAlpha, timer / fadeDuration);
        imageToFade.color = new Color(imageToFade.color.r, imageToFade.color.g, imageToFade.color.b, currentAlpha);

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
}
