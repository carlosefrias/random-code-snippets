import base64
import cv2.cv2 as cv2
import numpy as np
import codecs, json

file_path = 'FRE103579-T77583-02-aerofoil_26.000_-72.000.tif'

img = cv2.imread(file_path, cv2.IMREAD_UNCHANGED)
a = img

b = a.tolist() # nested lists with same data, indices
file_path = "path.json" ## your path variable
json.dump(b, codecs.open(file_path, 'w', encoding='utf-8'), separators=(',', ':'), sort_keys=True, indent=4) ### this saves the array in .json format

obj_text = codecs.open(file_path, 'r', encoding='utf-8').read()
b_new = json.loads(obj_text)
a_new = np.array(b_new)

print((a==a_new).all())

cv2.imwrite("res.tif", a_new)