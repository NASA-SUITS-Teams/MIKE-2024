using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class MetaQuestISDKToMIKEWidgetBridge : MonoBehaviour
{
    private MIKEWidget[] mikeWidgets;
    private PointableUnityEventWrapper iSDKPointableEventWrapper;
    private InteractableUnityEventWrapper iSDKInteractableEventWrapper;


    // Start is called before the first frame update
    void Start()
    {
        mikeWidgets = GetComponentsInChildren<MIKEWidget>();
        iSDKPointableEventWrapper = GetComponentInChildren<PointableUnityEventWrapper>();
        iSDKInteractableEventWrapper = GetComponentInChildren<InteractableUnityEventWrapper>();

        if (iSDKPointableEventWrapper != null)
        {
            iSDKPointableEventWrapper.WhenHover.AddListener((call) =>   Array.ForEach(mikeWidgets, widget => widget.OnHoverEnter()));
            iSDKPointableEventWrapper.WhenUnhover.AddListener((call) => Array.ForEach(mikeWidgets, widget => widget.OnHoverExit()));
            iSDKPointableEventWrapper.WhenSelect.AddListener((call) =>  Array.ForEach(mikeWidgets, widget => widget.OnClickStart()));
            iSDKPointableEventWrapper.WhenRelease.AddListener((call) => Array.ForEach(mikeWidgets, widget => widget.OnClickEnd()));
        }
        
        if (iSDKInteractableEventWrapper != null)
        {
            iSDKInteractableEventWrapper.WhenHover.AddListener(() =>    Array.ForEach(mikeWidgets, widget => widget.OnHoverEnter()));
            iSDKInteractableEventWrapper.WhenUnhover.AddListener(() =>  Array.ForEach(mikeWidgets, widget => widget.OnHoverExit()));
            iSDKInteractableEventWrapper.WhenSelect.AddListener(() =>   Array.ForEach(mikeWidgets, widget => widget.OnClickStart()));
            iSDKInteractableEventWrapper.WhenUnselect.AddListener(() => Array.ForEach(mikeWidgets, widget => widget.OnClickEnd()));
        }

        if(iSDKPointableEventWrapper == null && iSDKInteractableEventWrapper == null)
        {
            Debug.LogError("No Meta Quest Interactable SDK event wrappers found on " + gameObject.name);
        }
    }
}
