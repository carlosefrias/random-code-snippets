import cv2.cv2 as cv2

import numpy as np 
import pickle

file_path = 'FRE103579-T77583-02-aerofoil_26.000_-72.000.tif'

img = cv2.imread(file_path, cv2.IMREAD_UNCHANGED)

with open('test.pkl','wb') as f:
    pickle.dump(img, f)

