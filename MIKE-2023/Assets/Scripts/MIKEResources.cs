using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIKEResources : MonoBehaviour
{


    public static MIKEResources Main { get; private set; }


    [Header("Widget Resources")]
    public int MIKEWidgetLayer;
    public LayerMask MIKEWidgetLayerMask;
    public float WidgetExpandTime;

    [Header("Materials/Shaders/Colors")]
    public float DissipateTime;
    public Color PositiveNotificationColor;
    public Color WarningNotificationColor;
    public Color NegativeNotificationColor;


    void Awake()
    {
        Main = this;    
    }


}
