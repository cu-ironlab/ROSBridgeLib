#!/usr/bin/env python
import rospy
import numpy
from geometry_msgs.msg import TransformStamped

def main():
   rospy.init_node("simulated_transform", anonymous=True)
   trans_pub                = rospy.Publisher("/test_object", TransformStamped, queue_size=10)
   trans                    = TransformStamped()
   rate                    = rospy.Rate(60)
   trans.header.frame_id    = "world"
   radius                  = 4.0
   radians                 = 0.0
   while not rospy.is_shutdown():
       radians                += 0.01
       trans.header.seq         = trans.header.seq + 1
       trans.header.stamp       = rospy.Time()
       trans.transform.translation.x    = numpy.cos(radians)*radius
       trans.transform.translation.y    = numpy.sin(radians)*radius
       trans.transform.translation.z	= 1+.2*numpy.cos(radians)
       trans.transform.rotation.x		= numpy.sin(radians)*radius
       trans.transform.rotation.y		= numpy.sin(2*radians)*radius
       trans.transform.rotation.z		= numpy.sin(3*radians)*radius
       trans.transform.rotation.w		= numpy.sin(4*radians)*radius
       
       trans_pub.publish(trans)
       rate.sleep()
if __name__ == "__main__":
   main()
