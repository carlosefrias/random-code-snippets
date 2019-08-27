from flask import Flask, request
import cv2
import numpy as np
import base64

app = Flask(__name__)

@app.route("/Predict", methods=['POST'])
def preditc():
    frame = request.data
    image = cv2.imdecode(np.fromstring(frame, dtype=np.uint8), cv2.IMREAD_UNCHANGED)

    # TODO: call the segmentation model
    # TODO: retrieve the mask as a numpy array
    # TODO: encode it using cv2.imencode
    # TODO: send back the response to client
    
    return frame


app.run(host="0.0.0.0", port=5000)