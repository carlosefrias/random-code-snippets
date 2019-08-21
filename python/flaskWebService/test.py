import numpy as np 
import cv2
import base64

img = cv2.imread('kP0u2.png', cv2.IMREAD_UNCHANGED)

img_str = cv2.imencode('.png', img)[1].tostring()

print(type(img_str))
file = open("endodedImg.txt","w")
file.write(str(img_str))
file.close()

nparr = np.fromstring(img_str, np.uint8)
img2 = cv2.imdecode(nparr, 1)

print(type(img2))

cv2.imwrite("res.png", img2)