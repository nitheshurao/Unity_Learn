using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class San : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture tex;

    public RawImage display;

    public RawImage CapImage;

    public RawImage ArImage;
    //Creteing ibject poolonh 
   
    public Text startStopText;
    public Text imgc;

    //galllery
    int n;
    List<string> imagess = new List<string>();

    public Text debug;
    #region Camere
    public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;

            // if tex is not null:
            // stop the web cam
            // start the web cam

            if (tex != null)
            {
                StopWebCam();
                StartStopCam_Clicked();
            }
        }
    }

    public void StartStopCam_Clicked()
    {
        if (tex != null) // Stop the camera
        {
            StopWebCam();
            startStopText.text = "Start Camera";
        }
        else // Start the camera
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
            startStopText.text = "Stop Camera";
            CapImage.texture = tex;
        }
    }
    
    private void StopWebCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
#endregion

    public void Take()
    { 

     
        TakePhoto(3.0f);
        StartCoroutine(TakePhoto(3.0f));
        Debug.Log("click");


    }

    #region Take Photo
    int j = 1;
    public IEnumerator TakePhoto(float t)  // Start this Coroutine on some button click
    {

        // NOTE - you almost certainly have to do this here:
        Debug.Log("hi");
        yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(tex.width, tex.height);
        photo.SetPixels(tex.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Debug.Log("done" + p);
       

        //Convet byte to base64
        string base64String = BytoBase64(bytes);
        //StoreImage(base64String, j);

        imagess.Add(base64String);
        imgc.text = "no"+imagess.Count;
        Debug.Log(imagess.Count);
       

        //string base64String = System.Convert.ToBase64String(bytes);
        Debug.Log("done" + base64String);
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(Application.dataPath + "photo.png", bytes);
        File.WriteAllText(Application.dataPath + "/Photos.png", base64String);


        //Convet String to byte
        //imgc.text = "Img1 =" + j;
        //j++;


        //byte[] imageBytes = System.Convert.FromBase64String(base64String);
        byte[] imageBytes = Base64toByte(base64String);
        //Display Pic in side reowimage
        Dispalypic(imageBytes);

        //Texture2D text = new Texture2D(2, 2);
        //text.LoadImage(imageBytes);
        //CapImage.texture = text;
    }
    #region Arrayof image
    private void StoreImage(string img)
    {
        //public string[] imagess = new string[n];
    
      

    }

    #endregion


    #endregion
    #region Display Pic in side reowimage
    private void Dispalypic(byte[] image)
    {
        Texture2D text = new Texture2D(2, 2);
        text.LoadImage(image);
        CapImage.texture = text;
        Instantiate(CapImage);
        //ArImage.texture = text;


    }

    #endregion


    #region Convert Byte toBase64 

    // 
    public static string BytoBase64(byte[] bytes) {
        string base64String = System.Convert.ToBase64String(bytes);
        return base64String;

    }
    #endregion
    #region Convert Base64 to Byte
    public static byte[] Base64toByte(string base64String)
    {
        byte[] imageBytes = System.Convert.FromBase64String(base64String);
        return imageBytes;
    }
    #endregion
}
