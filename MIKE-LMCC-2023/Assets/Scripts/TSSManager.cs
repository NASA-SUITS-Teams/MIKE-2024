using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSSManager : MonoBehaviour
{
    public static TSSManager Main { get; private set; }

    public string TELEMETRYJsonString { get; private set; }

    [SerializeField] private string host = "127.0.0.1";

    private TSScConnection TSSc;

    void Awake() 
    {
        if(Main == null)
            Main = this;
        else
            Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        TSSc = GetComponent<TSScConnection>();
        TSSc.ConnectToHost(host, MIKEResources.Main.TeamNumber);
    }

    void OnDisable()
    {
        TSSc.DisconnectFromHost();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the UIA data has been updated
        if (TSSc.isUIAUpdated())
        {
            Debug.Log("UIA Updated");
            string UIAJsonString = TSSc.GetUIAJsonString();

            // TODO: Display the data
        }

        // Check if the DCU data has been updated
        if (TSSc.isDCUUpdated())
        {
            Debug.Log("DCU Updated");

            // Get the Updated DCU Json
            string DCUJsonString = TSSc.GetDCUJsonString();

            // TODO: Display the data
        }

        // Check if the ROVER data has been updated
        if (TSSc.isROVERUpdated())
        {
            Debug.Log("ROVER Updated");

            // Get the Updated ROVER Json
            string ROVERJsonString = TSSc.GetROVERJsonString();

            // TODO: Display the data
        }

        // Check if the SPEC data has been updated
        if (TSSc.isSPECUpdated())
        {
            Debug.Log("SPEC Updated");

            // Get the Updated SPEC Json
            string SPECJsonString = TSSc.GetSPECJsonString();

            // TODO: Display the data
        }

        // Check if the TELEMETRY data has been updated
        if (TSSc.isTELEMETRYUpdated())
        {
            Debug.Log("TELEMETRY Updated");

            // Get the Updated TELEMETRY Json
            TELEMETRYJsonString = TSSc.GetTELEMETRYJsonString();

            // TODO: Display the data
        }

        // Check if the COMM data has been updated
        if (TSSc.isCOMMUpdated())
        {
            Debug.Log("COMM Updated");

            // Get the Updated COMM Json
            string COMMJsonString = TSSc.GetCOMMJsonString();

            // TODO: Display the data
        }

        // Check if the COMM data has been updated
        if (TSSc.isIMUUpdated())
        {
            Debug.Log("IMU Updated");

            // Get the Updated IMU Json
            string IMUJsonString = TSSc.GetIMUJsonString();

            // TODO: Display the data
        }
    }
}
