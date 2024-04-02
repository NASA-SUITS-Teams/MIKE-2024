using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MIKEFadingWidget : MIKEWidget
{
    private MaskableGraphic[] graphics;
    private float highestAlpha;
    private float startingAlpha = 0f;
    private float timer = 0f;
    private bool fade = false;
    private bool setActiveAfter = false;

    // Start is called before the first frame update
    protected override void Awake()
    {
        graphics = GetComponentsInChildren<MaskableGraphic>();
        highestAlpha = 255f;
        foreach (var graphic in graphics)
        {
            graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, startingAlpha);
        }
    }

    public override void Activate()
    {
        base.Activate();
        FadeIn();
    }

    public override void Deactivate(bool keepActive = false)
    {
        FadeOut(false);
        base.Deactivate(true);
    }

    private void FadeLerp()
    {
        timer += Time.deltaTime;

        if (timer >= MIKEResources.Main.WidgetFadeTime)
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

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            FadeLerp();
        }
    }

    public void FadeIn()
    {
        fade = true;

        foreach (MaskableGraphic graphic in graphics)
        {
            graphic.CrossFadeAlpha(highestAlpha / 255f, MIKEResources.Main.WidgetFadeTime, true);
        }
    }

    public void FadeOut(bool setActiveToFalseAfter)
    {
        setActiveAfter = setActiveToFalseAfter;
        fade = true;

        foreach (MaskableGraphic graphic in graphics)
        {
            graphic.CrossFadeAlpha(0f, MIKEResources.Main.WidgetFadeTime, true);
        }
    }
}
