using SimpleJSON;
using UnityEngine;

public class TestSubscriber : ROSBridgeLib.ROSBridgeSubscriber {
  public new static string GetMessageTopic() {
    return "/test_object";
  }

  public new static string GetMessageType() {
    return "geometry_msgs/TransformStamped";
  }

  public new static ROSBridgeMsg ParseMessage(JSONNode msg) {
    return new ROSBridgeLib.geometry_msgs.TransformStampedMsg(msg);
  }

  // This function should fire on each received ros message
  public new static void CallBack(ROSBridgeMsg msg) {
    
    GameObject TestObject = GameObject.FindGameObjectWithTag("TestObject");

    ROSBridgeLib.geometry_msgs.TransformStampedMsg incomingMessage = (ROSBridgeLib.geometry_msgs.TransformStampedMsg)msg;
    float x = incomingMessage.GetTransform().GetTranslation().GetX();
    float y = incomingMessage.GetTransform().GetTranslation().GetY();
    float z = incomingMessage.GetTransform().GetTranslation().GetZ();

    float qx = incomingMessage.GetTransform().GetRotation().GetX();
    float qy = incomingMessage.GetTransform().GetRotation().GetY();
    float qz = incomingMessage.GetTransform().GetRotation().GetZ();
    float qw = incomingMessage.GetTransform().GetRotation().GetW();

    Vector3 IncomingPosition = new Vector3(x, z, y);
    Quaternion IncomingRotation = new Quaternion(qx, qy, qz, qw); 

    TestObject.transform.SetPositionAndRotation(IncomingPosition, IncomingRotation);
  }
}