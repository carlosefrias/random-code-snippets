import random

def operate(val1, val2, operation):
    if operation == "sum":
        return val1 + val2
    if operation == "dif":
        return val1 - val2
    if operation == "mult":
        return val1 * val2
    if operation == "div":
        return val1 / val2

def calculate(values, operations):
    result = operate(values[0], values[1], operations[0])
    result = operate(result, values[2], operations[1])
    result = operate(result, values[3], operations[2])
    return result

def solve(a,b,c,d):
    result = 0
    values = [a, b, c, d]
    o = ["sum", "dif", "mult", "div"]
    count = 0 
    while(result != 24):
        # define uma ordem aleatória dos quatro valores
        random.shuffle(values)
        # define aleatoriamente três operações
        operations = [o[random.randint(0, 3)], o[random.randint(0, 3)], o[random.randint(0, 3)]]
        # calcula o resultado
        result = calculate(values, operations)
        # verifica se dá 24
        if(result == 24):
            print(count)
            return values, operations
        # se o número de tentativas ultrapassa as 100 000, considerar que não existe solução
        count += 1
        if(count > 100000):
            return values, []

# Testar a função para 4 valores
v, op = solve(1,11,11,13)
# Imprimir a ordem dos valores
print(v)
# Imprimir a ordem das operações
print(op)