from socket import *
import time

serverName = 'localhost'
serverPort = 12000
clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET,SO_BROADCAST,1)

userInput = input('Input sentence: ')
message = userInput.lower()
while True:
    clientSocket.sendto(message.encode(), ('<broadcast>', serverPort))
    time.sleep(5)