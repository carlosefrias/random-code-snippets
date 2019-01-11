import cmath

pi = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481

def sqrt(x):
    return cmath.sqrt(x)

def cos(phi):
    return cmath.cos(phi)

def sin(phi):
    return cmath.sin(phi)

def cis(phi):
    return cos(phi) + 1j * sin(phi)

print(pi)


#complex number
w = cis(2 * pi / 2015)

sum = 0
for k in range(1, 2014):
    sum += 1/(1 + w ** k + w ** (2 *k ))

#print(sum)

val = ((1 + cis(pi/8))/(1+cis(-1*pi/8)))**8
#print(val)

x = 0.5 + 1j * (sqrt(3)/2)

sum = (x-1/x)**2
for a in range(1, 2015):
    sum += (x**a + 1/(x**a))**2

print(sum)
