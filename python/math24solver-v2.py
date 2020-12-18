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
    if operation == "div" and not val2 == 0:
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
    for permutation in permutations:
        for opSeq in listOpSeq:
            # Calcular os resultados operando em sequencia ((a op b) op c) op d (op pode ser +, -, x ou /)
            resultSeq = calculateSequential(permutation, opSeq)
            if resultSeq == 24:
                solutions.append(formatSolution(permutation, opSeq, True))
            # Calcular os resultados operando em partes (a op b) op (c op d) (op pode ser +, -, x ou /)
            result = calculateParted(permutation, opSeq)
            if result == 24:
                solutions.append(formatSolution(permutation, opSeq, False))
    if(len(solutions) == 0):
        return "Sem solução"
    else:
        return set(solutions)


# Testar a função para 4 valores
solutions = solve(1,11,11,13)

# Imprimir solucoes
print(solutions)