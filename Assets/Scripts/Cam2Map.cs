//updated 4thMay2018 - Anurag Tiwari

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script will be modified to generate cubemap isnead of just rendering a texture onto the model.
public class Cam2Map : MonoBehaviour {
    public Camera _sourceCam;
    public int _cubeMapResolution = 128;
    public bool _createMipMap = false;
    RenderTexture _rend;
    //private Renderer _rend;
    //public Cubemap _skymap;
	// Use this for initialization
	void Start () {
        //_rend = this.GetComponentInChildren<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //WebCamTexture _texture = 
        //_rend.material.mainTexture = _mycam

        /*
        _rend = new RenderTexture(_cubeMapResolution, _cubeMapResolution, 16);
        //precautions and double checks

        _rend.isCubemap = true;
        _rend.hideFlags = HideFlags.HideAndDontSave;

        _rend.autoGenerateMips = _createMipMap;

        _sourceCam.RenderToCubemap(_rend);
        */
	}

    public RenderTexture GetRenderTexture(){
        
        if (_rend != null) return _rend;

        _rend = new RenderTexture(_cubeMapResolution, _cubeMapResolution, 16);
        //precautions and double checks

        _rend.isCubemap = true;
        _rend.hideFlags = HideFlags.HideAndDontSave;

        _rend.autoGenerateMips = _createMipMap;

        _sourceCam.RenderToCubemap(_rend);
        return _rend;

    }
}
