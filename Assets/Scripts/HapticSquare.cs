using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TanvasTouch.Model;

//[System.Serializable]
public class HapticSquare : MonoBehaviour
{

    [SerializeField]
    private Camera _camera;
    private HapticServiceAdapter hapticServiceAdapter;
    private HapticView hapticView;
    private HapticTexture hapticTexture;
    private HapticMaterial hapticMaterial;
    private HapticSprite hapticSprite;
    private static Dictionary<string, HapticSprite> hapticSprites = new Dictionary<string, HapticSprite>();


    //Called at start of application.
    void Start()
    {
        Debug.Log("executing haptics script");
        //_camera = Camera.main; // the camera tagged "MainCamera" 

        //Connect to the service and begin intializing the haptic resources.
        InitHaptics();
    }


    public sealed class HapticType
    {
        public static readonly string TEST = "Textures/options/noise-sharp-circuit";

        public static readonly string CHECKERS = "click";

        public static readonly string NOISEHIGH = "Textures/options/raw/noise-sharp";
        public static readonly string NOISEMED = "Textures/options/raw/noise-original";
        public static readonly string NOISELOW = "Textures/options/raw/noise-blur";

        public static readonly string STRIPEHIGH = "Textures/options/raw/stripe";
        public static readonly string STRIPEMED = "Textures/options/raw/stripe-medium";
        public static readonly string STRIPELOW = "Textures/options/raw/stripe-soft";

        public static readonly string DOTS = "Textures/options/raw/dots";


    }

    void Update()
    {

        if (hapticView != null)
        {
            //Ensure haptic view orientation matches current screen orientation.
            hapticView.SetOrientation(Screen.orientation);


            //Retrieve x and y position of square.
            Mesh _mesh = gameObject.GetComponent<MeshFilter>().mesh;
            Vector3[] _meshVerts = _mesh.vertices;
            for (var i = 0; i < _mesh.vertexCount; ++i)
            {
                _meshVerts[i] = _camera.WorldToScreenPoint(gameObject.transform.TransformPoint(_meshVerts[i]));
            }

            //Set the size and position of the haptic sprite to correspond to square.
            hapticSprite.SetPosition((int)(_meshVerts[0].x), (int)(_meshVerts[0].y));
            hapticSprite.SetSize((double)_meshVerts[1].x - _meshVerts[0].x, (double)_meshVerts[1].y - _meshVerts[0].y);

        }
    }

    void InitHaptics()
    {
        //Get the service adapter
        hapticServiceAdapter = HapticServiceAdapter.GetInstance();

        if (hapticServiceAdapter != null)
        {
            //Create the haptic view with the service adapter instance and then activate it.
            hapticView = HapticView.Create(hapticServiceAdapter);
            hapticView.Activate();
            hapticView.SetOrientation(Screen.orientation); //Set orientation of haptic view based on screen orientation.
        }

    }

    public void UpdateHaptics(string type)
    {

        if (hapticView != null)
        {
            hapticView.RemoveSprite(hapticSprite);

            if (hapticSprites.ContainsKey(type))
            {
                hapticSprite = hapticSprites[type];
                hapticView.AddSprite(hapticSprite);
            }
            else
            {
                AddHapticSprite(type);
            }
        }
    }

    private void AddHapticSprite(string type)
    {
        //HapticServiceAdapter hapticServiceAdapter = HapticServiceAdapter.GetInstance();

        Texture2D texture = Resources.Load(type) as Texture2D;
        byte[] textureData = TanvasTouch.HapticUtil.CreateHapticDataFromTexture(texture, TanvasTouch.HapticUtil.Mode.Brightness);

        HapticTexture hapticTexture = HapticTexture.Create(hapticServiceAdapter);
        hapticTexture.SetSize(texture.width, texture.height);
        hapticTexture.SetData(textureData);

        HapticMaterial hapticMaterial = HapticMaterial.Create(hapticServiceAdapter);
        hapticMaterial.SetTexture(0, hapticTexture);

        hapticSprite = HapticSprite.Create(hapticServiceAdapter);
        hapticSprite.SetMaterial(hapticMaterial);
        //hapticSprite.SetSize(texture.width, texture.height);
        //hapticSprite.SetPosition((Screen.width - texture.width) / 2, ((int)transform.localPosition.y) + (Screen.height - texture.height) / 2);

        hapticView.AddSprite(hapticSprite);

        hapticSprites.Add(type, hapticSprite);

    }

    public void SetEnabled(bool enabled)
    {
        if (hapticSprite != null)
        {
            hapticSprite.SetEnabled(enabled);
        }
    }

    // maybe switch from these two functions to SetEnabled function
    public void ActivateHaptic()
    {
        if (hapticView != null)
        {
            hapticView.Activate();
        }
    }

    public void DeactivateHaptic()
    {
        if (hapticView != null)
        {
            hapticView.Deactivate();
        }
    }

    void OnDestroy()
    {
        if (hapticView != null) hapticView.Deactivate();
    }
}
