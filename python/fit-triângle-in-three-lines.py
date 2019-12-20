import numpy as np 

a = np.array([0,0,0])
b = np.array([0,0,0])
c = np.array([0,0,0])

r = np.array([1,0,1])
s = np.array([1,1,1])
t = np.array([0,0,1])

d1 = 1
d2 = 1
d3 = 1

step = 0.05
error = 0.01

def dist(a, b):
    return np.sqrt((a[0] - b[0]) * (a[0] - b[0]) + (a[1] - b[1]) * (a[1] - b[1]) + (a[2] - b[2]) * (a[2] - b[2]))

for k1 in np.arange(-2, 2, step):
    for k2 in np.arange(-2, 2, step):
        for k3 in np.arange(-2, 2, step):
            p_r = a + k1 * r
            p_s = b + k2 * s
            p_t = c + k3 * t
            if np.abs(dist(p_r, p_s) - d1) < error  and np.abs(dist(p_r, p_t) - d2) < error and np.abs(dist(p_s, p_t) - d3) < error:
                print('found')
                print(f'A: {p_r}')
                print(f'B: {p_s}')
                print(f'C: {p_t}')
                break

