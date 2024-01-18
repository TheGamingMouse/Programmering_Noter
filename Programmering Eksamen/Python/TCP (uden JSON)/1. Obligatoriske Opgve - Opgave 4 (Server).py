from socket import *
import threading
import random
serverPort = 12000
serverSocket = socket(AF_INET, SOCK_STREAM)
serverSocket.bind(('', serverPort))
serverSocket.listen(1)


def HandleClient(connectionSocket, addr):
 connectionSocket.send('Type "Random" or "Calculator" to get the corresponding function.'.encode())
 sentence = connectionSocket.recv(1024).decode().lower()
 txt = str(f'From client {addr}: {sentence}.')
 print(txt)
 connectionSocket.send(' '.encode())

 if 'random' in sentence:
  handleRandom(connectionSocket, addr)
 
 elif 'calculator' in sentence:
  handleCalculator(connectionSocket, addr)

 else:
  handleWrongCommand(connectionSocket, addr)


def handleWrongCommand(connectionSocket, addr):
 connectionSocket.send('Wrong command, did you input a valid command word?'.encode())
 handleClose(connectionSocket, addr)
 print('Wrong command from client: ', addr)


def handleClose(connectionSocket, addr):
 connectionSocket.send('Connection ended'.encode())
 print('Connection closed for client: ', addr)
 connectionSocket.close()


def handleRandom(connectionSocket, addr):
 connectionSocket.send('Type two numbers, the server will respond with a random number between them.'.encode())
 sentence = connectionSocket.recv(1024).decode()
 txt = str(f'From client {addr}: {sentence}.')
 print(txt)
 
 num = random.randrange(int(sentence.split(' ')[0]),int(sentence.split(' ')[1]))
 numStr = str(f'Your random number between {int(sentence.split(" ")[0])} and {int(sentence.split(" ")[1])} is: {num}')
 print(f'Client random number is: {num}')
 
 connectionSocket.send(numStr.encode())
 handleClose(connectionSocket, addr)


def handleCalculator(connectionSocket, addr):
 connectionSocket.send('Type "Add", "Subtract", "Multiply", or "Divide" to get the corresponding function. Type two numbers after the command word, the server will use them for the calculation.'.encode())
 sentence = connectionSocket.recv(1024).decode()
 txt = str(f'From client {addr}: {sentence}.')
 print(txt)

 txtCalc = f''
 
 if 'add' in sentence:
  txtCalc = f'The addition of {int(sentence.split(" ")[1])} + {int(sentence.split(" ")[2])} = {int(sentence.split(" ")[1]) + int(sentence.split(" ")[2])}'
  print('To client: ', txtCalc)
 
 elif 'subtract' in sentence:
  txtCalc = f'The subtraction of {int(sentence.split(" ")[1])} - {int(sentence.split(" ")[2])} = {int(sentence.split(" ")[1]) - int(sentence.split(" ")[2])}'
  print('To client: ', txtCalc)
  
 elif 'multiply' in sentence:
  txtCalc = f'The multiplication of {int(sentence.split(" ")[1])} * {int(sentence.split(" ")[2])} = {int(sentence.split(" ")[1]) * int(sentence.split(" ")[2])}'
  print('To client: ', txtCalc)
  
 elif 'divide' in sentence:
  txtCalc = f'The divition of {int(sentence.split(" ")[1])} / {int(sentence.split(" ")[2])} = {int(sentence.split(" ")[1]) / int(sentence.split(" ")[2])}'
  print('To client: ', txtCalc)
  
 connectionSocket.send(txtCalc.encode())
 handleClose(connectionSocket, addr)
 

print('The server is ready to receive')
while True:
 connectionSocket, addr = serverSocket.accept()
 print('Connection from client, address:',addr)
 threading.Thread(target=HandleClient,args=(connectionSocket,addr)).start()
