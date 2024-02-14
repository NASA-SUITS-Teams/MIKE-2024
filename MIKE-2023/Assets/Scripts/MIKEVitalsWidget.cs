using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIKEVitalsWidget : MIKEExpandingWidget
{

    [Header("Vitals")]
    [SerializeField] private MIKEWidgetValue restingHeartRate;
    [SerializeField] private MIKEWidgetValue evaHeartRate;
    [Header("Suit")]
    [SerializeField] private MIKEWidgetValue habO2Pressure;
    [SerializeField] private MIKEWidgetValue habCO2Pressure;
    [SerializeField] private MIKEWidgetValue habOtherPressure;
    [Space]
    [SerializeField] private MIKEWidgetValue suitO2Pressure;
    [SerializeField] private MIKEWidgetValue suitCO2Pressure;
    [SerializeField] private MIKEWidgetValue suitOtherPressure;
    [Space]
    [SerializeField] private MIKEWidgetValue suitO2Consumption;
    [SerializeField] private MIKEWidgetValue suitCO2Production;


}
