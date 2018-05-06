//updated: 1stMay2018 - Anurag Tiwari
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Vuforia;


public class LightMatchingEnabler : MonoBehaviour {
    //open access to get variables.
    public bool _isLightMatching { get; private set; }
    public float? _lightIntensity { get; private set; }
    public float? _colorTemp { get; private set; }

    //get vuforias illumination manager
    IlluminationManager _vufIllumination;

    //chekc if vuforia ar session has started and if intensity data is available
    private bool isVuforiaOn;
    private bool isColorTempAvail;
    private bool isIntensityAvail;

    private static LightMatchingEnabler instance;

    public static LightMatchingEnabler Instance {
        get { return instance; }
    }
    //double check active and awake
	private void Awake()
	{
        instance = this;
	}

    /// <summary>
    /// /////////////////////////////
    /// </summary>
	private void OnEnable()
	{
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(MyVuforiaIsOn);
	}



    private void OnDisable()
    {
        VuforiaARController.Instance.UnregisterVuforiaStartedCallback(MyVuforiaIsOn);
    }
    /// <summary>
    /// ///////////////////////////
    /// </summary>
    public void LightMatchingCalculator(bool isActive){
        _isLightMatching = isActive;
        Debug.Log("it is working yay! = Value is: " + isActive.ToString());
    }
    /// <summary>
    /// ///////////////////////
    /// </summary>
    void MyVuforiaIsOn(){
        Debug.Log("Vuforia is on");
        var _mystate = TrackerManager.Instance.GetStateManager();
        if(_mystate==null)
        {
            Debug.LogError("Vuforia is on by cannot get the AR state");
            return;
        }
        _vufIllumination = _mystate.GetIlluminationManager();
        if(_vufIllumination == null)
        {
            Debug.LogError("Vuforia cannot connect to ios ARKIT/android arcore to get illumination perhap?");
            return;
        }
        _isLightMatching = true;
        isVuforiaOn = true;

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //////////////////
        /// chekc every frame for value changes? will this owrk? idk.. loop madness?
        if(_isLightMatching && isVuforiaOn){
            Debug.Log("is color temp there? it is: " + _vufIllumination.AmbientColorTemperature.Value);
            Debug.Log("illumination value? : " + _vufIllumination.AmbientIntensity.Value);
            SetLightMatching();
        }
            
	}
    void SetLightMatching(){
        GraphicsSettings.lightsUseLinearIntensity = true;
        GraphicsSettings.lightsUseColorTemperature = true;
        _lightIntensity = ((_vufIllumination.AmbientIntensity.Value) / 1000.0f);
        _colorTemp = _vufIllumination.AmbientColorTemperature.Value;
    }
}
