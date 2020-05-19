using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;

/* 
 * @brief ROSBridgeLib
 * @author Michael Jenkin, Robert Codd-Downey, Andrew Speers and Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace geometry_msgs {
		public class TransformStampedMsg : ROSBridgeMsg {
			public HeaderMsg _header;
			public TransformMsg _transform;
			
			public TransformStampedMsg(JSONNode msg) {
				_header = new HeaderMsg(msg["header"]);
                _transform = new TransformMsg(msg["transform"]);
			}
 			
			public static string GetMessageType() {
				return "geometry_msgs/TransformPosed";
			}
			
			public HeaderMsg GetHeader() {
				return _header;
			}

			public TransformMsg GetTransform() {
				return _transform;
			}
			
			public override string ToString() {
				return "TransformStamped [header=" + _header.ToString() + ",  transform=" + _transform.ToString() + "]";
			}
			
			public override string ToYAMLString() {
				return "{\"header\" : " + _header.ToYAMLString() + ", \"transform\" : " + _transform.ToYAMLString() + "}";
			}
		}
	}
}