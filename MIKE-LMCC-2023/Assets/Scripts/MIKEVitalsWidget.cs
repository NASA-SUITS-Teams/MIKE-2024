using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIKEVitalsWidget : MIKEExpandingWidget
{
    [SerializeField] private MIKEWidgetValue primaryO2Storage;
    [SerializeField] private MIKEWidgetValue secondaryO2Storage;
    [SerializeField] private MIKEWidgetValue primaryO2Pressure;
    [SerializeField] private MIKEWidgetValue secondaryO2Pressure;
    [SerializeField] private MIKEWidgetValue suitO2Pressure;
    [SerializeField] private MIKEWidgetValue suitCO2Pressure;
    [SerializeField] private MIKEWidgetValue suitOtherPressure;
    [SerializeField] private MIKEWidgetValue suitTotalPressure;
    [SerializeField] private MIKEWidgetValue scrubberAPressure;
    [SerializeField] private MIKEWidgetValue scrubberBPressure;
    [SerializeField] private MIKEWidgetValue H2OGasPressure;
    [SerializeField] private MIKEWidgetValue H2OLiquidPressure;
    [SerializeField] private MIKEWidgetValue O2Consumption;
    [SerializeField] private MIKEWidgetValue CO2Production;
    [SerializeField] private MIKEWidgetValue primaryFan;
    [SerializeField] private MIKEWidgetValue secondaryFan;
    [SerializeField] private MIKEWidgetValue helmetCO2Pressure;
    [SerializeField] private MIKEWidgetValue heartRate;
    [SerializeField] private MIKEWidgetValue temperature;
    [SerializeField] private MIKEWidgetValue coolant;

    void Update() 
    {
        if(IsActivated)
            UpdateVitals();
    }

    public void UpdateVitals() 
    {
        MIKEVitals data = JsonUtility.FromJson<MIKEVitals>(TSSManager.Main.TELEMETRYJsonString);
        
        primaryO2Storage.SetValue(data.oxygenPrimaryStorage);
        secondaryO2Storage.SetValue(data.oxygenSecondaryStorage);
        primaryO2Pressure.SetValue(data.oxygenPrimaryPressure);
        secondaryO2Pressure.SetValue(data.oxygenSecondaryPressure);
        suitO2Pressure.SetValue(data.suitPressureOxygen);
        suitCO2Pressure.SetValue(data.suitPressureCO2);
        suitOtherPressure.SetValue(data.suitPressureOther);
        suitTotalPressure.SetValue(data.suitPressureTotal);
        scrubberAPressure.SetValue(data.scrubberACO2Storage);
        scrubberBPressure.SetValue(data.scrubberBCO2Storage);
        H2OGasPressure.SetValue(data.coolantGasPressure);
        H2OLiquidPressure.SetValue(data.coolantLiquidPressure);
        O2Consumption.SetValue(data.oxygenConsumption);
        CO2Production.SetValue(data.co2Production);
        primaryFan.SetValue(data.fanPrimaryRPM);
        secondaryFan.SetValue(data.fanSecondaryRPM);
        helmetCO2Pressure.SetValue(data.helmetPressureCO2);
        heartRate.SetValue(data.heartRate);
        temperature.SetValue(data.temperature);
        coolant.SetValue(data.coolantML);
    }

    [System.Serializable]
    public class MIKEVitals
    {
        public float batteryTimeLeft;
        public float oxygenPrimaryStorage;
        public float oxygenSecondaryStorage;
        public float oxygenPrimaryPressure;
        public float oxygenSecondaryPressure;
        public float oxygenTimeLeft;
        public float heartRate;
        public float oxygenConsumption;
        public float co2Production;
        public float suitPressureOxygen;
        public float suitPressureCO2;
        public float suitPressureOther;
        public float suitPressureTotal;
        public float fanPrimaryRPM;
        public float fanSecondaryRPM;
        public float helmetPressureCO2;
        public float scrubberACO2Storage;
        public float scrubberBCO2Storage;
        public float temperature;
        public float coolantML;
        public float coolantGasPressure;
        public float coolantLiquidPressure;
    }
}
