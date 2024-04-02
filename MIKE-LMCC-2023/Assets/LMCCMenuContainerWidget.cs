using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LMCCMenuContainerWidget : MIKEFadingWidget
{
    public static LMCCMenuContainerWidget[] MenuContainers { get; private set; }

    public LMCCScreenContainerWidget CurrentScreenContainer { get; private set; } = null;
    public bool IsFilled { get; set; } = false;

    private const float positionOffset = 400f;

    private Color startColor;

    protected override void Awake()
    {
        base.Awake();
        startColor = GetComponent<Image>().color;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (MenuContainers == null || MenuContainers.Length == 0)
        {
            MenuContainers = FindObjectsOfType<LMCCMenuContainerWidget>();
            Debug.Log("menuBoxWidgets: " + MenuContainers.Length);
        }
    }

    public override void Deactivate(bool keepActive = false)
    {
        if (IsFilled)
        {
            CurrentScreenContainer.transform.SetParent(this.transform);
            CurrentScreenContainer.transform.localPosition = Vector3.up * positionOffset;
            CurrentScreenContainer.transform.localRotation = Quaternion.identity;
        }

        base.Deactivate();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("MIKEWidget") && other.gameObject.tag == "ScreenContainer")
        {
            IsFilled = true;
            CurrentScreenContainer = other.gameObject.GetComponent<LMCCScreenContainerWidget>();
            GetComponent<Image>().color = Color.green;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("MIKEWidget") && other.gameObject.tag == "ScreenContainer")
        {
            IsFilled = false;
            CurrentScreenContainer = null;
            GetComponent<Image>().color = startColor;
        }
    }
}
