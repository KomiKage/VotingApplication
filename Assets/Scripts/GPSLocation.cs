using System.Collections;
using TMPro;
using UnityEngine;
public class GPSLocation : MonoBehaviour
{
    public TMP_Text GPSStatus;
    public TMP_Text latitudeValue;
    public TMP_Text longitudeValue;
    public TMP_Text altitudeValue;
    public TMP_Text horizontalAccuracyValue;
    public TMP_Text timestampValue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GpsLoc());
    }

    // Update is called once per frame
    IEnumerator GpsLoc()
    {
        //check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;
            // start service before querying location.
            Input.location.Start();

            // wait untill service initialize
            int maxWait = 20;
            while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }
            /// service didn't init in 20 sec
            if (maxWait < 1)
            {
                GPSStatus.text = "Time out!";
                yield break;
            }//connection failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                GPSStatus.text = "Unable to determine device location..";
                yield break;
            }
            else
            {
                //acces granted
                GPSStatus.text = "Running";
                InvokeRepeating("UpdateGPSData", 0.5f, 1f);
            }
        }
    private void UpdateGPSData()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            GPSStatus.text = "Running";
            latitudeValue.text = Input.location.lastData.latitude.ToString();
            longitudeValue.text = Input.location.lastData.longitude.ToString();
            altitudeValue.text = Input.location.lastData.altitude.ToString();
            horizontalAccuracyValue.text = Input.location.lastData.horizontalAccuracy.ToString();
            timestampValue.text = Input.location.lastData.timestamp.ToString();
            // acces granted to GPS values and has been initalized
        }
        else
        {
            // service is stopped
           
        }
    }
}
