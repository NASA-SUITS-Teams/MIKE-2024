using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIKEIntro : MonoBehaviour
{

    private Dissipate dissipate;

    // Start is called before the first frame update
    void Start()
    {
        dissipate = GetComponent<Dissipate>();
        dissipate.DissipateStart(false, 3f);
    }

}
