jsonArray = "[{\"playerId\": \"1\",\"playerLoc\": \"Powai\"},{\"playerId\": \"2\",\"playerLoc\":\"Andheri\"},{\"playerId\": \"3\",\"playerLoc\": \"Churchgate\"}]"

jsonList = [] #List
json = ""
for i in range(len(jsonArray)):
    json += jsonArray[i]
    if(jsonArray[i] == '{'):
        json = jsonArray[i] 
    if(jsonArray[i] == '}'):
        jsonList.append(json)
# C# code version
# public List<string> Parse(string jsonArray)
# {
#     List<string> jsonList = new List<string>();
#     string json = "";
#     for(int i = 0; i < jsonArray.Length; ++i)
#     {
#         json += jsonArray[i];
#         if(jsonArray[i] == '{')
#         {
#             json = jsonArray[i];
#         }
#         if(jsonArray[i] == '}')
#         {
#             jsonList.Add(json);
#         }
#     }
#     return jsonList;
# }

print(jsonList[0])
print(jsonList[1])
print(jsonList[2])