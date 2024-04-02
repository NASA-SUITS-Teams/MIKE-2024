using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMCCScreenContainerWidget : MIKEFadingWidget
{
    public LMCCScreenWidget CurrScreen { get; private set; }

    private Vector3 startingRotation;
    private bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        startingRotation = transform.rotation.eulerAngles;
    }

    public override void Activate()
    {
        base.Activate();
        CurrScreen = GetComponentInChildren<LMCCScreenWidget>();
        CurrScreen.Activate();
    }

    public override void OnClickStart()
    {
        base.OnClickStart();
        grabbed = true;
        Array.ForEach(LMCCMenuContainerWidget.MenuContainers, m => m.Activate());
        // HF Feedback
    }

    public override void OnClickEnd()
    {
        base.OnClickEnd();
        grabbed = false;
        Array.ForEach(LMCCMenuContainerWidget.MenuContainers, m => m.Deactivate());
        // HF Feedback
    }

    void LateUpdate()
    {
        if (this.IsActivated)
        {
            if (grabbed)
            {
                transform.forward = Vector3.ProjectOnPlane(transform.position - Camera.main.transform.position, Vector3.up);
                //transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(startingRotation.x, transform.eulerAngles.y, startingRotation.z);
            }
        }
    }
}
