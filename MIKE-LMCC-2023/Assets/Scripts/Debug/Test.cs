using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Test : MonoBehaviour
{

    private AudioSource source;
    private AudioClip currentClip;
    private float[] audioData;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        foreach(string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentClip = Microphone.Start("Microphone (Yeti Stereo Microphone)", false, 30, 16000);
            timer = 0;
            source.clip = currentClip;
            source.loop = false;
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            Microphone.End("Microphone (Yeti Stereo Microphone)");
            audioData = new float[currentClip.samples * currentClip.channels];
            currentClip.GetData(audioData, 0);

            List<float> editedData = audioData.ToList().GetRange(0, (int)(16000f * timer));
            audioData = editedData.ToArray();

            SendData();
        }

        timer += Time.deltaTime;

    }

    public void SendData()
    {

        byte[] byteArray = new byte[audioData.Length * 4];
        Buffer.BlockCopy(audioData, 0, byteArray, 0, byteArray.Length);
        Debug.Log("Sending sample count: " + audioData.Length);
        CameraTest.Main.SendData(byteArray);
    }

}
