using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIKEWidget : MonoBehaviour
{

    [SerializeField] protected string widgetName;
    public string WidgetName { get { return widgetName; } }

    public bool IsActivated { get; private set; }

    protected virtual void Awake()
    {
        gameObject.layer = MIKEResources.Main.MIKEWidgetLayer;
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
        IsActivated = true;
    }

    public virtual void Deactivate(bool keepActive = false)
    {
        if(!keepActive)
            gameObject.SetActive(false);
        IsActivated = false;
    }

    public virtual void OnHoverEnter()
    {
        //
    }

    public virtual void OnHoverExit()
    {
        //
    }

    public virtual void OnClickStart()
    {
        //
    }

    public virtual void OnClickEnd()
    {
        //
    }

    public string GetWidgetName()
    {
        return widgetName;
    }

    

}
