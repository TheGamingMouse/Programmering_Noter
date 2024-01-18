from socket import *
from threading import *

serverPort = 12000
sSock = socket(AF_INET, SOCK_DGRAM)
sSock.bind(('', serverPort))


def HandleClient():
    while True:
        msg, addr = sSock.recvfrom(2048)
        if 'quit' in msg.decode():
            print(f'Connection ended with client ({addr})')
            break
        userMsg = msg.decode()
        print(f'Message from {addr}: "{userMsg}"')

        serverMsg = msg.decode().upper()
        sSock.sendto(serverMsg.encode(), addr)


print('The server is ready to receive')
while True:
    Thread(target=HandleClient).start()