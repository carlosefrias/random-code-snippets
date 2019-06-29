# Inspired on https://www.youtube.com/watch?v=5mFpVDpKX70

# Problem: Given a number calculate the sequence:
# Start with a chosen number
# if the number is even, then the next element of the sequence is half of that number
# if the number is odd, then the next element is three times that number plus one
# Repeat this process until we get the value one

def is_even(number):
    '''
    Checks if a given number is even or odd
    '''
    return number % 2 == 0

def next_term(n):
    '''
    Returns the next element of the sequence 
    if the current element is n
    '''
    return int(n / 2) if is_even(n) else 3*n + 1

def get_sequence(n):
    '''
    Returns all elements of the sequence 
    that starts on n
    '''
    sequence = [n]
    while (n != 1):
        n = next_term(n)
        sequence.append(n)
    return sequence

print(get_sequence(7))
print(get_sequence(1234567890))