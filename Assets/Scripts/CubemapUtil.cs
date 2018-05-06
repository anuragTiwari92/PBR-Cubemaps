//Updated5thMay2018-AnuragTiwari
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubemapUtil : MonoBehaviour {
    public Camera _sourceCam;
    public int _cubeMapResolution = 128;
    public bool _createMipMap = false;
    RenderTexture _rend;


   // public Cam2Map _thiscubemap;
   // public string[] _keywords;
    bool isCubemapSet = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!isCubemapSet){
            _renderCubemap();
            _createCubemap();
            isCubemapSet = true;
        }
	}

    void _renderCubemap(){
        _rend = new RenderTexture(_cubeMapResolution, _cubeMapResolution, 16);
        //precautions and double checks

        _rend.isCubemap = true;
        _rend.hideFlags = HideFlags.HideAndDontSave;

        _rend.autoGenerateMips = _createMipMap;

        _sourceCam.RenderToCubemap(_rend);

    }
    void _createCubemap(){
        Material _mymaterial = GetComponent<Renderer>().material;
        /*foreach(Material _mat in materials){
            foreach (string _key in _keywords)
            {
                if (_mat.HasProperty(_key))
                {
                    _mat.SetTexture(_key, _thiscubemap.GetRenderTexture());
                }
            }
        }*/
        _mymaterial.SetTexture("SpecularRef",_rend);

    }
}
