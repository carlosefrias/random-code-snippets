coin_values = [200, 100, 50, 20, 10, 5, 2, 1]
number_coins = [5, 10, 10, 20, 30, 40, 50, 50]

def get_available_amount():
    sum = 0
    for idx in range(len(coin_values)):
        sum = sum + coin_values[idx] * number_coins[idx]
    return sum

def get_change(total_amount):
    if get_available_amount() < total_amount:
        return "not enough money"
    original_amount = total_amount
    sum_change = 0
    coins = []
    for idx in range(len(coin_values)):
        value = coin_values[idx]
        while total_amount >= value and number_coins[idx] > 0:
            total_amount -= value
            coins.append(value)
            number_coins[idx] -= 1
            sum_change += value
    if sum_change < original_amount:
        return "not enough money"
    return coins

print(get_change(1050))
print(get_change(1050))
print(get_change(1050))
print(get_change(255))
print(get_change(145))

print(f"available money: {get_available_amount()}")