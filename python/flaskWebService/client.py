import http.client as httplib
import cv2.cv2 as cv2
import numpy as nps


file_path = 'FRE103579-T77583-02-aerofoil_26.000_-72.000.tif'

img = cv2.imread(file_path, cv2.IMREAD_UNCHANGED)

conn = httplib.HTTPConnection('127.0.0.1:5000', timeout=5)

def sendtoserver(frame):
    imencoded = cv2.imencode(".tif", frame)[1]
    headers = {"Content-type": "text/plain"}
    try:
        conn.request("POST", "/Predict", imencoded.tostring(), headers)
        response = conn.getresponse()
    except conn.timeout as e:
        print("timeout")
    return response

print(sendtoserver(img).readline())