using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LMCCScreenWidget : MIKEWidget
{
    [SerializeField] private TextMeshProUGUI title;

    public string Title 
    { 
        get { return title.text; } 
        set { title.text = value; } 
    }

    public override void Activate()
    {
        base.Activate();
        title.text = this.WidgetName;
    }
}
