using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    private Valve.VR.EVRButtonId m_GripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    public bool m_GripButtonDown = false;
    public bool m_GripButtonUp = false;
    public bool m_GripButtonPressed = false;

    private Valve.VR.EVRButtonId m_TriggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    public bool m_TriggerButtonDown = false;
    public bool m_TriggerButtonUp = false;
    public bool m_TriggerButtonPressed = false;

    private Valve.VR.EVRButtonId m_TouchpadButton = Valve.VR.EVRButtonId.k_EButt on_SteamVR_Touchpad;
    public bool m_TouchpadButtonDown = false;
    public bool m_TouchpadButtonUp = false;
    public bool m_TouchpadButtonPressed = false;

    private SteamVR_Controller.Device m_Controller {
        get{ return SteamVR_Controller.Input((int)m_TrackedObject.index);}
    }
    private SteamVR_TrackedObject m_TrackedObject;

	void Start () {
        m_TrackedObject = GetComponent<SteamVR_TrackedObject>();	
	}
	
	// Update is called once per frame
	void Update () {
		if(m_Controller == null){
            Debug.Log("Wheres yo controller my dude");
            return;
        }
        m_GripButtonDown = m_Controller.GetPressDown(m_GripButton);
        m_GripButtonUp = m_Controller.GetPressUp(m_GripButton);
        m_GripButtonPressed = m_Controller.GetPress(m_GripButton);

        m_TriggerButtonDown = m_Controller.GetPressDown(m_TriggerButton);
        m_TriggerButtonUp = m_Controller.GetPressUp(m_TriggerButton);
        m_TriggerButtonPressed = m_Controller.GetPress(m_TriggerButton);

        m_TouchpadButtonDown = m_Controller.GetPressDown(m_TouchpadButton);
        m_TouchpadButtonUp = m_Controller.GetPressUp(m_TouchpadButton);
        m_TouchpadButtonPressed = m_Controller.GetPress(m_TouchpadButton);

        if (m_GripButtonDown)
        {
            Debug.Log("Grip button of " + gameObject.name + " was just pressed.");
        }
        if (m_GripButtonUp)
        {
            Debug.Log("Grip button of " + gameObject.name + "  was just unpressed.");
        }
        if (m_TriggerButtonDown)
        {
            Debug.Log("Trigger button of " + gameObject.name + "  was just pressed.");
        }
        if (m_TriggerButtonUp)
        {
            Debug.Log("Trigger button of " + gameObject.name + "  was just unpressed.");
        }
        if (m_TouchpadButtonDown)
        {
            Debug.Log("Touchpad button of " + gameObject.name + "  was just unpressed.");
        }
        if (m_TouchpadButtonUp)
        {
            Debug.Log("Touchpad button of " + gameObject.name + "  was just unpressed.");
        }
    }
}
