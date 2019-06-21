
import numpy as np

sum = 0
for i in range(1,100001):
	sum += 1 / (i**2)

pi_approx = np.sqrt(6*sum)

print("pi_approx: " + str(pi_approx))
