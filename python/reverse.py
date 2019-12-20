def reverse(x):
    output = ""
    for c in x:
        output = f"{c}{output}"
    return output

reversed = reverse("random string")
print(reversed)

def find_missing(full_set, partial_set):
    missing_items = set(full_set) - set(partial_set)
    return missing_items

def find(full_set, partial_set):
    for i in full_set:
        if i not in partial_set:
            return i

def find_missing_xor(full_set, partial_set):
    xor_sum = 0
    for num in full_set:
        xor_sum ^= num
    for num in partial_set:
        xor_sum ^= num
    return xor_sum


def reverse_num(num):
    reversed = 0
    while(num >= 10):
        rest = num % 10
        reversed *= 10
        reversed += rest
        i, _ = divmod(num, 10)
        num = i
    reversed *= 10
    rest = num % 10
    reversed += rest
    return reversed

def reverse_num2(num):
    num_str = str(num)
    reversed_num_str = reverse(num_str)
    return int(reversed_num_str)


print(reverse_num2(1234))