using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LMCCButtonWidget : MIKEWidget
{
    public UnityEvent Clicked;

    public bool b;

    // Update is called once per frame
    void Update()
    {
        if(b)
        {
            b = false;
            Clicked.Invoke();
        }
    }

    public override void OnClickStart()
    {
        base.OnClickStart();
        Clicked.Invoke();
    }
}
