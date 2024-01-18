from socket import *
from threading import *
import requests
import json

serverPort = 12000
sSock = socket(AF_INET, SOCK_DGRAM)
sSock.bind(('', serverPort))

URL = 'http://localhost:5256/api/Books'

def HandleClient():
    while True:
        msg, addr = sSock.recvfrom(2048)
        userMsg = msg.decode()
        print(f'Message from {addr}: "{userMsg}"')
        
        sentence = json.loads(userMsg)

        if sentence['func'] == 'print':
            print('All books')
            books, resp = GetAll()
            print(resp.status_code)
            for book in books:
                print(book)

        elif sentence['func'] == 'printid':
            bookId = int(sentence['id'])

            print(f'Book number {bookId}')
            books, resp = GetById(bookId)
            print(resp.status_code)
            for book in books:
                if book['id'] == bookId:
                    print(book)

        elif sentence['func'] == 'update':
            bookId = int(sentence['id'])
            newName = sentence['newName']
            newPrice = int(sentence['newPrice'])
            
            values = {
                "title": newName,
                "price": newPrice
            }

            print(f'Book number {bookId} updated')
            books, resp = Put(values, bookId)
            print(resp.status_code)
            print(resp.content)

        elif sentence['func'] == 'new':
            name = sentence['name']
            price = int(sentence['price'])
            values = {
                "title": name,
                "price": price
            }
            
            print(f'Book "{name}" created')
            books, resp = Post(values)
            print(resp.status_code)
            print(resp.content)

        else:
            print('Wrong input')

def GetAll():
    response = requests.get(URL)
    data = response.json()
    return data, response

def GetById(id):
    response = requests.get(URL, f'/{id}')
    data = response.json()
    return data, response

def Post(values):
    response = requests.post(URL, json=values)
    data = response.json()
    return data, response

def Put(values, id):
    response = requests.put(f'{URL}/{id}', json=values)
    data = response.json()
    return data, response

def Delete(id):
    response = requests.delete(f'{URL}/{id}')
    data = response.json()
    return data, response

print('The server is ready to receive')
while True:
    Thread(target=HandleClient).start()