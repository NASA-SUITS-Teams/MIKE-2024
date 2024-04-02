using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaPulse : MonoBehaviour
{
    [SerializeField] private float alpha1 = 0f;
    [SerializeField] private float alpha2 = 255f;
    [SerializeField] private float duration = 1.0f;
    [SerializeField] private bool startIncreasing = true;

    private float t = 0.0f;
    private float a1;
    private float a2;
    private bool increasing;

    private MaskableGraphic graphic;

    // Start is called before the first frame update
    void Start()
    {
        graphic = GetComponent<MaskableGraphic>();
        increasing = !startIncreasing;
        ChangeLerpDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Color c = graphic.material.color;
        c.a = Mathf.Lerp(a1, a2, t / duration);
        graphic.material.color = c;
        t += Time.deltaTime;

        // Reverse the direction of the alpha transition when reaching the end points
        if (t >= duration)
        {
            t = 0.0f;
            ChangeLerpDirection();
        }
    }

    private void ChangeLerpDirection()
    {
        increasing = !increasing;

        if (increasing)
        {
            a1 = alpha1 / 255f;
            a2 = alpha2 / 255f;
        }
        else
        {
            a2 = alpha1 / 255f;
            a1 = alpha2 / 255f;
        }
    }
}
