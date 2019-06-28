import numpy as np

#I'm assuming that we know 2 points of each line (end points)
#Line AB 
A = np.array([1,2,-4])
B = np.array([-2,-1,3])

vectorAB = B - A
print(vectorAB)

#Line CD
C = np.array([-3, 5, -2])
D = np.array([1, 2, -3])
vectorCD = D - C
print(vectorCD)

#Calculate a perpendicular vector to both vectorAB and vectorCD
vectorN = np.cross(vectorAB, vectorCD)
print(vectorN)

P = A # it is indiferent to choose P as A, B or other point in the line AB
Q = C # Same...

vectorPQ = Q - P

cosTheta = np.abs(np.dot(vectorPQ, vectorN)) / (np.linalg.norm(vectorPQ) * np.linalg.norm(vectorN))

#Minimum distance
d = np.linalg.norm(vectorPQ) * cosTheta
print(d)

#or simply
d = np.abs(np.dot(vectorPQ, vectorN)) / np.linalg.norm(vectorN)
print(d)

vectorAC = C - A
num = np.dot(vectorAC, vectorAB) * np.dot(vectorAB, vectorCD) - np.dot(vectorAC, vectorCD) * np.linalg.norm(vectorAB) ** 2 
denom = (np.linalg.norm(vectorCD) * np.linalg.norm(vectorAB)) ** 2 - np.dot(vectorAB, vectorCD) ** 2

t = num / denom

num = np.dot(vectorAC, vectorAB) + t * np.dot(vectorCD, vectorAB)
denom = np.linalg.norm(vectorAB) ** 2

k = num / denom

#Point on line AB closest to line CD
P = A + k * vectorAB
print(P)
#Point on line CD cloesest to line AB
R = C + t * vectorCD
print(R)

#Minimum distance
vectorPR = R -P
d = np.linalg.norm(vectorPR)
print(d)
    
