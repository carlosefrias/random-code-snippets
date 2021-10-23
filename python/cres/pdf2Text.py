from wand.image import Image as Img  #converter pdf em imagem
import os
file = "TWM.pdf"
i = 0
with Img(filename= file, resolution=300) as img:
    img.compression_quality = 99
    i += 1
    img.save(filename=file[:-4] +  str(i) + ".jpg")