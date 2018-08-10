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
    private HapticServiceAdapter mHapticServiceAdapter;
    private HapticView mHapticView;
    private HapticTexture mHapticTexture;
    private HapticMaterial mHapticMaterial;
    private HapticSprite mHapticSprite;
    //private ScreenOrientation _previousOrientation = ScreenOrientation.Unknown;
    private int _previousWidth = 0;
    private int _previousHeight = 0;

    //public GameObject hapticOnOffButton;
    //public Sprite hapticsOn;
    //public Sprite hapticsOff;

    //Called at start of application.
    void Start()
    {
        Debug.Log("executing haptic settings script");
        //Connect to the service and begin intializing the haptic resources.
        InitHaptics();
    }
    // Update is called once per frame
    void Update()
    {
        if (mHapticView != null)
        {
            //Ensure haptic view orientation matches current screen orientation.
            mHapticView.SetOrientation(Screen.orientation);

            //Retrieve x and y position of square.
            Mesh _mesh = gameObject.GetComponent<MeshFilter>().mesh;
            Vector3[] _meshVerts = _mesh.vertices;
            for (var i = 0; i < _mesh.vertexCount; ++i)
            {
                _meshVerts[i] = _camera.WorldToScreenPoint(gameObject.transform.TransformPoint(_meshVerts[i]));
            }

            //Set the size and position of the haptic sprite to correspond to square.
            mHapticSprite.SetPosition((int)(_meshVerts[0].x), (int)(_meshVerts[0].y));
            mHapticSprite.SetSize((double)_meshVerts[1].x - _meshVerts[0].x, (double)_meshVerts[1].y - _meshVerts[0].y);
        }

    }

    public sealed class HapticType
    {
        public static readonly string RIBBED = "ribbed";
        public static readonly string CLICK = "click";
        public static readonly string BUMPY = "bumpy";
    }

    void InitHaptics()
    {
        //Get the service adapter
        mHapticServiceAdapter = HapticServiceAdapter.GetInstance();

        //Create the haptic view with the service adapter instance and then activate it.
        mHapticView = HapticView.Create(mHapticServiceAdapter);
        mHapticView.Activate();

        //Set orientation of haptic view based on screen orientation.
        mHapticView.SetOrientation(Screen.orientation);

        //Retrieve texture data from bitmap.
        string imagePath = "";

        switch (this.gameObject.name)
        {
            //case "HapticSquare": // circuit A
            //    imagePath = "Textures/options/noise-sharp-circuit";
            //    break;
            //case "HapticSquare1": // circuit A high
            //    imagePath = "Textures/options/noise-sharp-circuit";
            //    break;
            //case "HapticSquare2": // circuit A medium
            //    imagePath = "Textures/options/noise-original-circuit";
            //    break;
            //case "HapticSquare3": // circuit A low
            //    imagePath = "Textures/options/noise-blur-circuit";
            //    break;
            //case "HapticSquare4": // circuit A Option 4 XXX
            //    imagePath = "";
            //    break;


            case "HapticSquare": // circuit A
                imagePath = "Textures/options/stripe-circuit";
                break;
            case "HapticSquare1": // circuit A high
                imagePath = "Textures/options/stripe-circuit";
                break;
            case "HapticSquare2": // circuit A medium
                imagePath = "Textures/options/stripe-medium-circuit";
                break;
            case "HapticSquare3": // circuit A low
                imagePath = "Textures/options/stripe-soft-circuit";
                break;

            case "HapticSquareA": // circuit A Option 1
                imagePath = "Textures/options/stripe-circuit";
                break;
            case "HapticSquareB": // circuit A Option 2
                imagePath = "Textures/options/checker-circuit";
                break;
            case "HapticSquareC": // circuit A Option 3
                imagePath = "Textures/options/dots-circuit";
                break;
            case "HapticSquareD": // circuit A Option 4
                imagePath = "Textures/options/noise-sharp-circuit";
                break;
        }
        Texture2D _texture = Resources.Load(imagePath) as Texture2D;
        byte[] textureData = TanvasTouch.HapticUtil.CreateHapticDataFromTexture(_texture, TanvasTouch.HapticUtil.Mode.Brightness);

        //Create a haptic texture with the retrieved texture data.
        mHapticTexture = HapticTexture.Create(mHapticServiceAdapter);
        mHapticTexture.SetSize(_texture.width, _texture.height);
        mHapticTexture.SetData(textureData);

        //Create a haptic material with the created haptic texture.
        mHapticMaterial = HapticMaterial.Create(mHapticServiceAdapter);
        mHapticMaterial.SetTexture(0, mHapticTexture);

        //Create a haptic sprite with the haptic material.
        mHapticSprite = HapticSprite.Create(mHapticServiceAdapter);
        mHapticSprite.SetMaterial(mHapticMaterial);

        //Add the haptic sprite to the haptic view.
        mHapticView.AddSprite(mHapticSprite);

    }

    public void SetHapticViewState()
    {

        Debug.Log("button is clicked");
        if (mHapticView != null)
        {
            if (mHapticView.IsActive())
            {
                mHapticView.Deactivate();
                Debug.Log("Haptic is deactivated");
                //hapticOnOffButton.GetComponent<Image>().sprite = hapticsOff;
                //hapticViewStateText.text = "Activate Haptics";
            }
            else
            {
                mHapticView.Activate();
                Debug.Log("Haptic is activated");
                //hapticOnOffButton.GetComponent<Image>().sprite = hapticsOn;
                //hapticViewStateText.text = "Deactivate Haptics";
            }
        }
    }

    public void ActivateHaptic()
    {
        if (mHapticView != null)
        {
            mHapticView.Activate();
        }
    }

    public void DeactivateHaptic()
    {
        if (mHapticView != null)
        {
            mHapticView.Deactivate();
        }
    }



    void OnDestroy()
    {
        if (mHapticView != null) mHapticView.Deactivate();
    }
}
