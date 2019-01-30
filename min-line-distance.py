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