import time
def countHowMany(number, digit):
    count = 0
    while(number > 0):
        count = count + 1 if number % 10 == digit else count
        number //= 10
    return count

# This one takes longer
def countHowMany2(number, digit):
    count = 0
    numStr = str(number)
    for letter in numStr:
        if letter == digit:
            count += 1
    return count

def countHowMany3(number, digit):
    count = 0
    while(number > 0):
        count = count + 1 if number % 10 ^ digit == digit else count
        number //= 10
    return count

start_time = time.time()
count_digit_2 = 0
for number in range(10002, 99992+1):
    count_digit_2 += countHowMany3(number, 2)
    # count_digit_2 += countHowMany2(number, '2')

print(count_digit_2)

print(f"{time.time() - start_time} seconds")