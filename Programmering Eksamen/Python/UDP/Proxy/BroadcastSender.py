from socket import *
import time
import json

serverName = 'localhost'
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET,SO_BROADCAST,1)

userInput = input('Input sentence: ').lower()
if userInput.split(' ')[0] == 'print':
    dictJson = {
        'func' : userInput.split(' ')[0]
    }
    message = json.dumps(dictJson)
    
elif userInput.split(' ')[0] == 'printid':
    dictJson = {
        'func' : userInput.split(' ')[0],
        'id' : userInput.split(' ')[1]
    }
    message = json.dumps(dictJson)

if userInput.split(' ')[0] == 'update':
    dictJson = {
        'func' : userInput.split(' ')[0],
        'id' : userInput.split(' ')[1],
        'newName' : userInput.split(' ')[2],
        'newPrice' : userInput.split(' ')[3]
    }
    message = json.dumps(dictJson)

if userInput.split(' ')[0] == 'new':
    dictJson = {
        'func' : userInput.split(' ')[0],
        'name' : userInput.split(' ')[1],
        'price' : userInput.split(' ')[2]
    }
    message = json.dumps(dictJson)


while True:
    clientSocket.sendto(message.encode(), ('<broadcast>', serverPort))
    time.sleep(2)
    if input('Continue? (y/n): ') == 'n':
        break