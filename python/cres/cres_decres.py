from itertools import combinations


def calcNumberCres(sub_set):
	res = sub_set[0]
	for i in range(1,len(sub_set)):
		res *= 10
		res +=sub_set[i]
	return res

def calcNumberDecres(sub_set):
	res = calcNumberCres(sub_set)
	reversed = str(res)[::-1]
	return int(reversed)

numbers = set([0,1,2,3,4,5,6,7,8,9])

sub_sets_with_6_elems = list(combinations(numbers, 6))

listaC = []
listaD = []
for elem in sub_sets_with_6_elems:
	listaD.append(calcNumberDecres(elem))
	if elem[0] > 0:
		listaC.append(calcNumberCres(elem))

print("por ordem crescente:", len(listaC))
print('por ordem decrescente:', len(listaD))
print('total: ', len(listaC) + len(listaD))
