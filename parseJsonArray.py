jsonArray = "[{\"playerId\": \"1\",\"playerLoc\": \"Powai\"},{\"playerId\": \"2\",\"playerLoc\":\"Andheri\"},{\"playerId\": \"3\",\"playerLoc\": \"Churchgate\"}]"

jsonList = [] #List
newJson = False
endJson = False
json = ""
for i in range(len(jsonArray)):
    if(jsonArray[i] == '{'):
        newJson = True
    else:
        newJson = False
    if(jsonArray[i] == '}'):
        endJson = True
    else:
        endJson = False
    if(newJson):
        json = ""
    if(not endJson):
        json += jsonArray[i]
    if(endJson):
        json += jsonArray[i]
        jsonList.append(json)
        json = ""

print(jsonList[0])
print(jsonList[1])
print(jsonList[2])