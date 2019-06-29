# Problem: calculate the persistence of a number
# The persistence of a number is the number os times it's digits can be multiplied
# until we get a one digit number

def is_one_digit(number):
    return len(str(number)) == 1

def product_digits(number):
    digits = [int(d) for d in str(number)]
    product = 1
    for d in digits:
        product *= d
    return product

def persistence(number):
    if (not isinstance(number, int)):
        raise ValueError('The value must be an integer')
    if (number < 0):
        raise ValueError('The value must be a non negative integer')
    persistence = 0
    while(not is_one_digit(number)):
        number = product_digits(number)
        print(number)
        persistence += 1
    return persistence