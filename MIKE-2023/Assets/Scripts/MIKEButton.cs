using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MIKEButton : MIKEWidget
{

    public UnityEvent Clicked;

    protected Image highlight;
    protected BoxCollider col;

    public bool b;

    private void Update()
    {
        if(b)
        {
            b = false;
            Clicked.Invoke();
        }
    }
    protected new void Awake()
    {
        base.Awake();
        col = GetComponent<BoxCollider>();
        highlight = GetComponent<Image>();
        highlight.enabled = false;
    }

    public override void OnHoverEnter()
    {
        base.OnHoverEnter();
        highlight.enabled = true;
    }

    public override void OnHoverExit()
    {
        base.OnHoverExit();
        highlight.enabled = false;
    }

    public override void OnClickStart()
    {
        base.OnClickStart();
        highlight.color = Color.green;
        Clicked.Invoke();
    }

    public override void OnClickEnd()
    {
        base.OnClickEnd();
        highlight.color = Color.white;
    }


}
