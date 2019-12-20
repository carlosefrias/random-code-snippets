coin_values = [200, 100, 50, 20, 10, 5, 2, 1]
number_coins = [5, 10, 10, 20, 30, 40, 50, 50]

def get_available_amount():
    sum = 0
    for idx in range(len(coin_values)):
        sum += coin_values[idx] * number_coins[idx]
    return sum

def get_change(total_amount):
    if get_available_amount() < total_amount:
        return "not enough money"
    coins = []
    for idx in range(len(coin_values)):
        value = coin_values[idx]
        if total_amount >= value and number_coins[idx] > 0:
            n, _ = divmod(total_amount, value)
            n_coins = n if number_coins[idx] >= n else number_coins[idx]
            total_amount -= value * n_coins
            coins.append((value, n_coins))
            number_coins[idx] -= n_coins
        if total_amount == 0:
            break
    if total_amount > 0:
        return "not enough money"
    return coins

print(get_change(2500))

print(f"available money: {get_available_amount()}")