
from flask import Flask, request
import cv2
import numpy as np
import base64

app = Flask(__name__)

@app.route("/hello", methods=['POST'])
def hello():
    print("here...")
    return "Hello, World!"

@app.route("/predict", methods=['POST'])
def predict():
    data = request.get_json()
    s = data['image']
    print(s)
    
    nparr = np.fromstring(base64.decodestring(s), np.uint8)
    img2 = cv2.imdecode(nparr, 1)

    print(type(img2))

    cv2.imwrite("res.png", img3)

    return "hello"

app.run(host="0.0.0.0", port=5000)