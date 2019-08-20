import numpy as np 
import cv2

img = cv2.imread('kP0u2.png', cv2.IMREAD_UNCHANGED)
img = np.asarray(img[0,:,:])
t = np.savetxt("foo.csv", img, delimiter = ",")

file = open("foo.csv","r")
txt = file.read()
file.close()

print(txt)
