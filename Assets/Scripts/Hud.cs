using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hud : MonoBehaviour
{

    //UI Text GameObjects
    public GameObject targets;
    //public UnityEngine.UI.Text targetsHitText;

    //Game Variable
    private int targetsHit;

    //Text Components
    TextMeshProUGUI targetsHitText;

    // Start is called before the first frame update

    private void Start()
    {
        targetsHitText = targets.GetComponent<TextMeshProUGUI>();

        targetsHit = 0;
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        
        //targetsssHit = targetsHit.ToString();
        targetsHitText.text = "Targets Hit: " + targetsHit.ToString() + "Test ";
    }

    public void IncreaseTargetsHit()
    {
        targetsHit++;
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        //targetsHitText.text = 
    }
}
