using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionManager : MonoBehaviour {
  private ROSBridgeLib.ROSBridgeWebSocketConnection ros = null;

  public string IP = "192.168.1.142";
    
  void Start() {
    // Where the rosbridge instance is running, could be localhost, or some external IP
    ros = new ROSBridgeLib.ROSBridgeWebSocketConnection("ws://" + IP, 9090);

    ros.AddSubscriber (typeof(TestSubscriber));
    ros.Connect ();
  }
  
  // Extremely important to disconnect from ROS. Otherwise packets continue to flow
  void OnApplicationQuit() {
    if(ros!=null) {
      ros.Disconnect ();
    }
  }
  // Update is called once per frame in Unity
  void Update () {
    ros.Render ();
  }
}
