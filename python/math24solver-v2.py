import itertools

def opSymbl(operation):
    if operation == "sum":
        return "+"
    if operation == "dif":
        return "-"
    if operation == "mult":
        return "x"
    if operation == "div":
        return "/"

def formatSolution(values, operations, sequential):
    if sequential:
        return f"(({values[0]}{opSymbl(operations[0])}{values[1]}){opSymbl(operations[1])}{values[2]}){opSymbl(operations[2])}{values[3]}"
    else:
        return f"({values[0]}{opSymbl(operations[0])}{values[1]}){opSymbl(operations[1])}({values[2]}{opSymbl(operations[2])}{values[3]})"

def operate(val1, val2, operation):
    if operation == "sum":
        return val1 + val2
    if operation == "dif":
        return val1 - val2
    if operation == "mult":
        return val1 * val2
    if operation == "div":
        return val1 / val2

def calculateSequential(values, operations):
    result = operate(values[0], values[1], operations[0])
    result = operate(result, values[2], operations[1])
    result = operate(result, values[3], operations[2])
    return result

def calculateParted(values, operations):
    first = operate(values[0], values[1], operations[0])
    second = operate(values[2], values[3], operations[2])
    return operate(first, second, operations[1])

def solve(a,b,c,d):
    values = [a,b,c,d]
    solutions = []
    # Obter todas as permutacoes dos operandos
    permutations = list(itertools.permutations(values))
    # Obter todas as escolhas de tres operacoes sequenciais (podendo haver repeticao da operacao)
    op = ["sum", "dif", "mult", "div"]
    listOpSeq = [p for p in itertools.product(op, repeat=3)]
    plusMinus = ["sum", "dif"]
    # Obter as escolhas de operacoes do tipo (a+-b)x/(c+-d)
    listOpInPartsPM = [p for p in itertools.product(plusMinus, repeat=2)]
    listOpInParts = [(p[0], 'mult', p[1]) for p in listOpInPartsPM]
    listOpInParts1 = [(p[0], 'div', p[1]) for p in listOpInPartsPM]
    listOpInParts.append(listOpInParts1)
    for permutation in permutations:
        for opSeq in listOpSeq:
            result = calculateSequential(permutation, opSeq)
            if result == 24:
                solutions.append(formatSolution(permutation, opSeq, True))
        for opSeq in listOpInParts:
            result = calculateParted(permutation, opSeq)
            if result == 24:
                solutions.append(formatSolution(permutation, opSeq, False))
    return set(solutions)


# Testar a função para 4 valores
solutions = solve(1,4,3,3)

# Imprimir solucoes
print(solutions)