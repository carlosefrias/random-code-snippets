import time
def countHowMany(number, digit):
    count = 0
    while(number > 0):
        count = count + 1 if number % 10 == digit else count
        number //= 10
    return count


start_time = time.time()
count_digit_2 = 0
for number in range(100000002, 999999992+1):
    count_digit_2 += countHowMany(number, 2)

print(count_digit_2)

print(f"{time.time() - start_time} seconds")