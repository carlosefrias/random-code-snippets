
from flask import Flask, request
import cv2
import numpy as np

app = Flask(__name__)

@app.route("/hello", methods=['POST'])
def hello():
    print("here...")
    return "Hello, World!"

@app.route("/predict", methods=['POST'])
def predict():
    data = request.get_json()
    s = data['image']
    print(type(s))
    a = np.fromstring(s, dtype=int, sep=',')
    print(type(a))
    a = a.reshape(2,2)
    print(a)
    return "hello"

app.run(host="0.0.0.0", port=5000)